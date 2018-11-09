﻿using Common;
using FrameWork;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using WorldServer.Services.World;
using WorldServer.World.AI;

namespace WorldServer.World.Objects.Instances
{
    public class InstanceBossSpawn : Creature
    {
        public uint InstanceGroupSpawnID;
        public uint BossID;
        public ushort InstanceID;
		public Instance Instance { get; set; } = null;
		public Stopwatch BossTimer { get; set; } = null;
        public static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public List<Creature> AddList = new List<Creature>();
        public int PlayerDeathsCount { get; set; } = 0;

        public InstanceBossSpawn(Creature_spawn spawn, uint instancegroupspawnid, uint bossid, ushort Instanceid, Instance instance) : base(spawn)
        {
            InstanceGroupSpawnID = instancegroupspawnid;
            BossID = bossid;
            Instance = instance;
            InstanceID = Instanceid;
            EvtInterface.AddEventNotify(EventName.OnEnterCombat, OnEnterCombat);
            EvtInterface.AddEventNotify(EventName.OnLeaveCombat, OnLeaveCombat);
        }

        public override void OnLoad()
        {
            base.OnLoad();
            
            AddCrowdControlImmunity((int)GameData.CrowdControlTypes.All);
        }

        public override void Update(long tick)
        {
            base.Update(tick);
        }

        public override void ApplyKnockback(Unit caster, AbilityKnockbackInfo kbInfo)
        {
            // no knockdown Mob on bosses ...
        }

        public virtual bool OnEnterCombat(Object mob, object args)
        {
            Instance.Encounterinprogress = true;
            Instance.CurrentBossId = BossID;

            Unit Attacker = mob.GetCreature().CbtInterface.GetTarget(GameData.TargetTypes.TARGETTYPES_TARGET_ENEMY);

            if(InstanceGroupSpawnID > 0)
            {
                Instance.BossAttackTarget(InstanceGroupSpawnID, Attacker);
			}

			BossTimer = new Stopwatch();
			BossTimer.Start();

			return false;
        }

        public virtual bool OnLeaveCombat(Object mob, object args)
        {
            // save statistics
            InstanceService.SaveDeathCountPerBoss(Instance.ZoneID + ":" + Instance.ID, mob.GetInstanceBossSpawn(), PlayerDeathsCount);
            
            if (!mob.GetInstanceBossSpawn().IsDead)
            {
                // save statistics
                InstanceService.SaveAttemptsPerBoss(Instance.ZoneID + ":" + Instance.ID, this, 1);

                if (InstanceGroupSpawnID > 0)
                    Instance.BossRespawnInstanceGroup(InstanceGroupSpawnID);
            }
            else
            {
                PlayerDeathsCount = 0;

                // save statistics
                InstanceService.SaveTtkPerBoss(Instance.ZoneID + ":" + Instance.ID, this, BossTimer.Elapsed);
            }
            // reset add list
            AddList = new List<Creature>();

            // reset all Modify Scalers
            ModifyDmgHealScaler = 1f;
            List<Player> plrs = GetPlayersInRange(300, false);
            foreach (Player plr in plrs)
            {
                plr.ModifyDmgHealScaler = 1f;
            }

            try { StsInterface.RemoveBonusMultiplier(GameData.Stats.OutgoingDamagePercent, 1.0f, BuffClass.Standard); } catch (Exception e) { Log.Error("Exception", e.Message + "\r\n" + e.StackTrace); }
            
            if (BossTimer != null)
			{
				BossTimer.Reset();
			}

			return false;
        }

        public override bool ReceiveDamage(Unit caster, AbilityDamageInfo damageInfo)
        {
            return base.ReceiveDamage(caster, damageInfo);
        }

        public override bool ReceiveDamage(Unit caster, uint damage, float hatredScale = 1, uint mitigation = 0)
        {
            return base.ReceiveDamage(caster, damage, hatredScale, mitigation);
        }
        
        public override int ReceiveHeal(Unit caster, uint healAmount, float healHatredScale = 1)
        {
            return base.ReceiveHeal(caster, healAmount, healHatredScale);
        }

        protected override void SetRespawnTimer()
        {
            
        }

        protected override void SetDeath(Unit killer)
        {
            // reset add list
            AddList = new List<Creature>();

            base.SetDeath(killer);

            Instance.OnBossDeath(InstanceGroupSpawnID, this);

			// remove barriages from this instance
			Instance.RemoveInstanceObjectOnBossDeath(BossID);

            // handle torch of lileath on horgulul death
            if (this is SimpleHorgulul horgulul)
            {
                foreach (Player plr in horgulul.GetPlayersInRange(300, false))
                {
                    var character = CharMgr.GetCharacter(plr.CharacterId, false);
                    if (character == null)
                        continue;
                    if (!CharMgr.GetItemsForCharacter(character).Any(x => x.Entry == 11435))
                        plr.ItmInterface.CreateItem(11435, 1);
                }
            }
        }
        
        public override void TryLoot(Player player, InteractMenu menu)
		{
			if (lootContainer != null && lootContainer.IsLootable())
			{
				List<Player> subGroup = new List<Player>();

				if (player.PriorityGroup != null)
				{
                    foreach (Player member in player.PriorityGroup.Members)
                    {
                        if (!member.HasLockout((ushort)ZoneId, BossID))
                            subGroup.Add(member);
                    }
                    // used to only have items of careers in group in the lootcontainer
                    //player.PriorityGroup.SubGroupLoot(player, lootContainer, subGroup);
                    player.PriorityGroup.GroupLoot(player, lootContainer);
                }

                lootContainer.SendInteract(player, menu);

                if (!lootContainer.IsLootable())
				{
					SetLootable(false, player);

                    if (player.PriorityGroup == null)
                        Instance.ApplyLockout(new List<Player> { player });
                }
			}
		}

		public InstanceBossSpawn RezInstanceSpawn()
        {
            InstanceBossSpawn newCreature = new InstanceBossSpawn(Spawn, InstanceGroupSpawnID, BossID, InstanceID,Instance);
            Region.AddObject(newCreature, Spawn.ZoneId);
            Destroy();
            return newCreature;
        }

        public virtual void SpawnAdds(List<List<object>> listOfSpawnAdds)
        {
            List<object> Params = GetRandomSpawnParams(listOfSpawnAdds);

            List<uint> Entries = (List<uint>)Params[0];
            int X = (int)Params[1];
            int Y = (int)Params[2];
            int Z = (int)Params[3];
            ushort O = Convert.ToUInt16(Params[4]);
            
            foreach(var entry in Entries)
            {
                Creature_proto Proto = CreatureService.GetCreatureProto(entry);

                Creature_spawn Spawn = new Creature_spawn
                {
                    Guid = (uint)CreatureService.GenerateCreatureSpawnGUID()
                };
                Spawn.BuildFromProto(Proto);
                Spawn.WorldO = O;
                Spawn.WorldX = X + ShuffleWorldCoordinateOffset(20, 100);
                Spawn.WorldY = Y + ShuffleWorldCoordinateOffset(20, 100);
                Spawn.WorldZ = Z;
                Spawn.ZoneId = (ushort)ZoneId;

                Creature c = Region.CreateCreature(Spawn);
                //c.SetZone(Region.GetZoneMgr((ushort)ZoneId));
                c.EvtInterface.AddEventNotify(EventName.OnDie, RemoveAdds); // We are removing spawns from server when adds die
                c.PlayersInRange = PlayersInRange;

                // brain distribution
                switch (entry)
                {
                    //case 6861: // healerbrain for shamans
                    //    c.AiInterface.SetBrain(new SimpleLVHealerBrain(c));
                    //    //GoToMommy(c);
                    //    SetRandomTarget(c);
                    //    break;

                    default:
                        SetRandomTarget(c);
                        break;
                }

                AddList.Add(c); // Adding adds to the list for easy removal
            }
        }

        private List<object> GetRandomSpawnParams(List<List<object>> list)
        {
            Random rnd = new Random();
            int idx = rnd.Next(1, list.Count);
            return list[idx - 1];
        }
        
        public bool RemoveAdds(Object npc = null, object instigator = null)
        {
            Creature c = npc as Creature;
            c.EvtInterface.AddEvent(c.Destroy, 5 * 1000, 1);
            return false;
        }

        public virtual void SetRandomTarget(Creature c)
        {
            if (c != null)
            {
                if (c.PlayersInRange.Count > 0)
                {
                    bool haveTarget = false;
                    int playersInRange = c.PlayersInRange.Count();
                    Player player;
                    while (!haveTarget)
                    {
                        Random random = new Random();
                        int rndmPlr = random.Next(1, playersInRange + 1);
                        Object obj = c.PlayersInRange.ElementAt(rndmPlr - 1);
                        player = obj as Player;
                        if (player != null && !player.IsDead && !player.IsInvulnerable)
                        {
                            c.MvtInterface.TurnTo(player);
                            c.MvtInterface.SetBaseSpeed(100);
                            c.MvtInterface.Follow(player, 5, 10);
                            break;
                        }
                    }
                }
            }
        }

        public virtual void GoToMommy(Creature c)
        {
            if (c != null)
            {
                c.MvtInterface.TurnTo(this);
                c.MvtInterface.SetBaseSpeed(400);
                c.MvtInterface.Follow(this, 5, 10);
            }
        }

        /// <summary>
		/// calculates random offset in range of from to to
		/// </summary>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <returns></returns>
		public static int ShuffleWorldCoordinateOffset(int from, int to)
        {
            Random rnd = new Random();
            bool sign = rnd.NextDouble() > 0.5;
            int offset = Convert.ToInt32(from + rnd.NextDouble() * 100);
            if (offset > to) offset = to;
            return sign ? offset : -offset;
        }

        public override string ToString()
        {
            return "SpawnId=" + Spawn.Guid + ",Entry=" + Spawn.Entry + ",Spawngroup=" + InstanceGroupSpawnID + ",BossID=" + BossID + ",Name=" + Name + ",Level=" + Level + ",Rank=" + Rank + ",Max Health=" + MaxHealth + ",Faction=" + Faction + ",Emote=" + Spawn.Emote + "AI:" + AiInterface.State + ",Position :" + base.ToString();
        }
    }
}
