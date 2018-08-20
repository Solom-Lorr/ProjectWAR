﻿using System;
using System.Collections.Generic;
using Common;
using FrameWork;
using GameData;
using NLog;

namespace WorldServer.World.Battlefronts.Apocalypse
{
	public enum BORewardType
	{
		SMALL_CONTESTED = 0,
		SMALL_LOCKED = 1,
		BIG = 2
	}

    /// <summary>
    /// Manages rewards from RVR mechanic.
    /// </summary>
    public class RVRRewardManager
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public Dictionary<uint, XpRenown> DelayedRewards = new Dictionary<uint, XpRenown>();
        public float RewardScaleMultiplier { get; set; }
        public object PlrLevel { get; private set; }

        /// <summary>
        /// Add delayed XPR rewards for kills in RVR. 
        /// </summary>
        /// <param name="killer"></param>
        /// <param name="killed"></param>
        /// <param name="xpShare"></param>
        /// <param name="renownShare"></param>
        public void AddDelayedRewardsFrom(Player killer, Player killed, uint xpShare, uint renownShare)
        {
            if (xpShare == 0 && renownShare == 0)
                return;

            XpRenown xprEntry;

            uint renownReward = (uint)(renownShare * killer.GetKillRewardScaler(killed));

#if BattleFront_DEBUG
            player.SendClientMessage($"{ObjectiveName} storing {xpShare} XP and {renownReward} renown");
#endif
            DelayedRewards.TryGetValue(killer.CharacterId, out xprEntry);

            // Character has no record of XP/RR gain.
            if (xprEntry == null)
            {
                xprEntry = new XpRenown(xpShare, renownReward, 0, 0, TCPManager.GetTimeStamp());
                DelayedRewards.Add(killer.CharacterId, xprEntry);
            }
            else
            {
                xprEntry.XP += xpShare;
                xprEntry.Renown += renownReward;
                xprEntry.LastUpdatedTime = TCPManager.GetTimeStamp();
            }
            _logger.Debug($"Delayed Rewards for Player : {killer.Name}  - {xprEntry.ToString()}");
        }

		/// <summary>
		/// Return an additional scale value based upon who is holding a BO and how many players from either side are near.
		/// </summary>
		/// <param name="owningRealm"></param>
		/// <param name="nearOrderCount"></param>
		/// <param name="nearDestroCount"></param>
		/// <returns></returns>
		public float CalculateObjectiveRewardScale(Realms owningRealm, short nearOrderCount, short nearDestroCount)
        {
			float scale = 0.0f;
            if (owningRealm == Realms.REALMS_REALM_DESTRUCTION)
            {
				scale = (float)Math.Abs(Math.Log(nearOrderCount / 10f + 1f));
            }
            else
            {
                if (owningRealm == Realms.REALMS_REALM_ORDER)
                {
                    scale = (float)Math.Abs(Math.Log(nearDestroCount / 10f + 1f));
				}
            }
			if (scale > 1f)
				scale = 1f;
			return scale;
        }
		
        /// <summary>
        ///     Grants a small reward to all players in close range for defending.
        /// </summary>
        /// <remarks>Invoked in short periods of time</remarks>
        public VictoryPoint RewardCaptureTick(ISet<Player> playersWithinRange, Realms owningRealm, int tier, string objectiveName, float rewardScaleMultiplier, BORewardType boRewardType)
        {
            ushort influenceId;

            _logger.Trace($"Objective {objectiveName} has {playersWithinRange} players nearby");

			// Because of the Field of Glory buff, the XP value here is doubled.
			// The base reward in T4 is therefore 3000 XP.
			// Population scale factors can up this to 9000 if the region is full of people and then raise or lower it depending on population balance.
			var baseXp = (boRewardType == BORewardType.SMALL_CONTESTED || boRewardType == BORewardType.SMALL_LOCKED) ? BattleFrontConstants.FLAG_SECURE_REWARD_SCALER * tier * rewardScaleMultiplier * 10 : BattleFrontConstants.FLAG_SECURE_REWARD_SCALER * tier * rewardScaleMultiplier * 25;
            var baseRp = baseXp / 10f;
            var baseInf = baseRp / 3.2f;

            foreach (var player in playersWithinRange)
            {
                if (player.Realm != owningRealm || player.CbtInterface.IsInCombat || player.IsAFK || player.IsAutoAFK)
                    continue;

                // Bad dirty hak by Hargrim to fix Area Influence bug
                if (player.CurrentArea != null)
                {
                    if (owningRealm == Realms.REALMS_REALM_ORDER)
                        influenceId = (ushort) player.CurrentArea.OrderInfluenceId;
                    else
                        influenceId = (ushort) player.CurrentArea.DestroInfluenceId;
					
					if (boRewardType == BORewardType.SMALL_CONTESTED || boRewardType == BORewardType.SMALL_LOCKED)
						player.AddInfluence(influenceId, Math.Max((ushort)200f, (ushort)1));
					else if (boRewardType == BORewardType.BIG)
						player.AddInfluence(influenceId, Math.Max((ushort)400f, (ushort)1));
					else
						player.AddInfluence(influenceId, Math.Max((ushort)baseInf, (ushort)1));
				}

                Random rnd = new Random();
                int random = rnd.Next(-25, 25);
                var xp = (uint)Math.Max((baseXp * (1 + (random / 100))), 1);

                var rr = (uint) Math.Max((baseRp * (1 + (random / 100))), 1);

                rr = rr / 2;
                
                player.AddXp(xp, false, false);
                player.AddRenown(rr, false, RewardType.ObjectiveCapture, objectiveName);
                
                // TODO
                //Campaign.AddContribution(player, (uint)baseRp);

                _logger.Trace($"Player:{player.Name} ScaleMult:{rewardScaleMultiplier} XP:{xp} RR:{rr}");
            }

			VictoryPoint VP = new VictoryPoint(0, 0);
			switch (boRewardType)
			{
				case BORewardType.SMALL_CONTESTED: // small tick
					if (owningRealm == Realms.REALMS_REALM_ORDER)
						VP.OrderVictoryPoints += 15;
					else if (owningRealm == Realms.REALMS_REALM_DESTRUCTION)
						VP.DestructionVictoryPoints += 15;
					break;

				case BORewardType.BIG: // big tick
					if (owningRealm == Realms.REALMS_REALM_ORDER)
						VP.OrderVictoryPoints += 200;
					else if (owningRealm == Realms.REALMS_REALM_DESTRUCTION)
						VP.DestructionVictoryPoints += 200;
					break;

				case BORewardType.SMALL_LOCKED: // small tick
					if (owningRealm == Realms.REALMS_REALM_ORDER)
						VP.OrderVictoryPoints += 30;
					else if (owningRealm == Realms.REALMS_REALM_DESTRUCTION)
						VP.DestructionVictoryPoints += 30;
					break;

				default:
					break;
			}
			return VP;
		}
		
        /// <summary>
        /// For this player, calculate and send lock rewards
        /// </summary>
        public void GenerateLockReward(Player plr, Realms lockingRealm)
        {
            var influenceId = 0;
            if (lockingRealm == Realms.REALMS_REALM_ORDER)
                influenceId = (ushort)plr.CurrentArea.OrderInfluenceId;
            else
                influenceId = (ushort)plr.CurrentArea.DestroInfluenceId;

            //T1
            if (plr.Realm == lockingRealm)
            {

                Random rnd = new Random();
                int random = rnd.Next(1, 25);
                plr.AddXp((uint)(1500 * (1 + (random / 100))), false, false);
                plr.AddRenown((uint)(400 * (1 + (random / 100))), false, RewardType.ObjectiveCapture, "");


                var mailItem3 = new MailItem(208470, 2);
                Character_mail mail = new Character_mail
                {
                    Guid = CharMgr.GenerateMailGuid(),
                    CharacterId = plr.CharacterId,
                    SenderName = "RvR Reward System",
                    ReceiverName = plr.Name,
                    SendDate = (uint)TCPManager.GetTimeStamp(),
                    Title = "RvR Reward",
                    Content = "You won an RvR Reward!",
                    Money = 0,
                    Opened = false
                };

                if (plr.Level <= 15)
                {
                    mail.Items.Add(mailItem3);
                    CharMgr.AddMail(mail);
                }
            }
            else
            {
                Random rnd = new Random();
                int random = rnd.Next(1, 25);
                plr.AddXp((uint)(1500 * (1 + (random / 100))), false, false);
                plr.AddRenown((uint)(200 * (1 + (random / 100))), false, RewardType.ObjectiveCapture, "");

                var mailItem3 = new MailItem(208470, 1);
                Character_mail mail = new Character_mail
                {
                    Guid = CharMgr.GenerateMailGuid(),
                    CharacterId = plr.CharacterId,
                    SenderName = "RvR Reward System",
                    ReceiverName = plr.Name,
                    SendDate = (uint)TCPManager.GetTimeStamp(),
                    Title = "RvR Reward",
                    Content = "You won an RvR Reward!",
                    Money = 0,
                    Opened = false
                };

                if (plr.Level <= 15)
                {
                    mail.Items.Add(mailItem3);
                    CharMgr.AddMail(mail);
                }
            }



            // Tier 4

            if (plr.Realm == lockingRealm)
            {
                Random rnd = new Random();
                int random = rnd.Next(1, 25);
                plr.AddXp((uint)(4000 * (1 + (random / 100))), false, false);
                plr.AddRenown((uint)(5000 * (1 + (random / 100))), false, RewardType.ObjectiveCapture, "");
                plr.AddInfluence((ushort)influenceId, 1000);

                var mailItem3 = new MailItem(208470, 25);
                Character_mail mail = new Character_mail
                {
                    Guid = CharMgr.GenerateMailGuid(),
                    CharacterId = plr.CharacterId,
                    SenderName = "RvR Reward System",
                    ReceiverName = plr.Name,
                    SendDate = (uint)TCPManager.GetTimeStamp(),
                    Title = "RvR Reward",
                    Content = "You won an RvR Reward!",
                    Money = 0,
                    Opened = false
                };

                if (plr.Level > 15)
                {
                    mail.Items.Add(mailItem3);
                    CharMgr.AddMail(mail);
                }
            }
            else
            {

                Random rnd = new Random();
                int random = rnd.Next(1, 25);
                plr.AddXp((uint)(1500 * (1 + (random / 100))), false, false);
                plr.AddRenown((uint)(2000 * (1 + (random / 100))), false, RewardType.ObjectiveCapture, "");
                plr.AddInfluence((ushort) influenceId, 500);

                var mailItem3 = new MailItem(208470, 10);
                Character_mail mail = new Character_mail
                {
                    Guid = CharMgr.GenerateMailGuid(),
                    CharacterId = plr.CharacterId,
                    SenderName = "RvR Reward System",
                    ReceiverName = plr.Name,
                    SendDate = (uint)TCPManager.GetTimeStamp(),
                    Title = "RvR Reward",
                    Content = "You won an RvR Reward!",
                    Money = 0,
                    Opened = false
                };

                if (plr.Level > 15)
                {
                    mail.Items.Add(mailItem3);
                    CharMgr.AddMail(mail);
                }
            }

          
        }
    }
}