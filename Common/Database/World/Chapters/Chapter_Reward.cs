﻿using FrameWork;
using System;

namespace Common
{
    [DataTable(PreCache = false, TableName = "chapter_rewards", DatabaseName = "World", BindMethod = EBindingMethod.StaticBound)]
    [Serializable]
    public class Chapter_Reward : DataObject
    {
        public Chapter_Info Chapter;

        public Item_Info Item;

        [PrimaryKey]
        public uint Entry { get; set; }

        [DataElement]
        public uint InfluenceCount { get; set; }

        [PrimaryKey]
        public uint ItemId { get; set; }

        [DataElement]
        public byte Realm { get; set; }
    }
}