﻿using FrameWork;
using System;

namespace Common
{
    [DataTable(PreCache = false, TableName = "pquest_spawns", DatabaseName = "World", BindMethod = EBindingMethod.StaticBound)]
    [Serializable]
    public class PQuest_Spawn : DataObject
    {
        public int _WorldO;
        public int _WorldX;
        public int _WorldY;
        public int _WorldZ;
        private byte _Emote;
        private uint _Entry;
        private byte _Level;
        private uint _Objective;
        private string _pquest_spawns_ID;
        private byte _Type;
        private uint _Unk3;
        private ushort _ZoneId;
        [DataElement()]
        public uint AllowVfxUpdate { get; set; }

        [DataElement(AllowDbNull = false)]
        public byte Emote
        {
            get { return _Emote; }
            set { _Emote = value; Dirty = true; }
        }

        /// <summary>Create prototype primart key.</summary>
        [DataElement(AllowDbNull = false)]
        public uint Entry
        {
            get { return _Entry; }
            set { _Entry = value; Dirty = true; }
        }

        //Added to allow setting NPC Level for PQ stage and avoid usage of creature_protos table
        [DataElement(AllowDbNull = false)]
        public byte Level
        {
            get { return _Level; }
            set { _Level = value; Dirty = true; }
        }

        [DataElement(AllowDbNull = false)]
        public uint Objective
        {
            get { return _Objective; }
            set { _Objective = value; Dirty = true; }
        }

        /// <summary>
        /// Spawn quest UID, hexa value, identifing Creature object in game.
        /// Never null, cannot be empty.
        /// </summary>
        [PrimaryKey(AutoIncrement = false)]
        public string pquest_spawns_ID
        {
            get { return _pquest_spawns_ID; }
            set { _pquest_spawns_ID = value; Dirty = true; }
        }
        [DataElement()]
        public uint SoundId { get; set; }

        [DataElement(AllowDbNull = false)]
        public byte Type
        {
            get { return _Type; }
            set { _Type = value; Dirty = true; }
        }

        [DataElement(AllowDbNull = true)]
        public uint Unk3
        {
            get { return _Unk3; }
            set { _Unk3 = value; Dirty = true; }
        }

        [DataElement(AllowDbNull = true)]
        public ushort[] Unks { get; set; } = new ushort[6];

        [DataElement()]
        public uint VfxState { get; set; }

        [DataElement(AllowDbNull = false)]
        public int WorldO
        {
            get { return _WorldO; }
            set { _WorldO = value; Dirty = true; }
        }

        [DataElement(AllowDbNull = false)]
        public int WorldX
        {
            get { return _WorldX; }
            set { _WorldX = value; Dirty = true; }
        }

        [DataElement(AllowDbNull = false)]
        public int WorldY
        {
            get { return _WorldY; }
            set { _WorldY = value; Dirty = true; }
        }

        [DataElement(AllowDbNull = false)]
        public int WorldZ
        {
            get { return _WorldZ; }
            set { _WorldZ = value; Dirty = true; }
        }

        [DataElement(AllowDbNull = false)]
        public ushort ZoneId
        {
            get { return _ZoneId; }
            set { _ZoneId = value; Dirty = true; }
        }
        public ushort GetUnk(int Id)
        {
            if (Id >= Unks.Length)
                return 0;

            return Unks[Id];
        }
    }
}