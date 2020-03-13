using NPoco;
using System.Collections.Generic;

namespace ServerMaster.Definitions
{
    internal static class Listenings
    {
        public static class RefObjCommon
        {
            public static List<TableData.Main.RefObjCommon> ObjCommon { get; set; }
            public static List<TableData.Main.RefObjItem> ObjItem { get; set; }
            public static List<TableData.Main.RefObjChar> ObjChar { get; set; }
            public static List<TableData.Main.RefObjStruct> ObjStruct { get; set; }

            public static List<TableData.Main.RefObjCommon> GetMobList()
            {
                return ObjCommon.FindAll(x => x.TypeID1 == Enums.RefObjCommon.TypeID1.Mob);
            }

            public static List<TableData.Main.RefObjCommon> GetItemList()
            {
                return ObjCommon.FindAll(x => x.TypeID1 == Enums.RefObjCommon.TypeID1.Item);
            }

            public static List<TableData.Main.RefObjCommon> GetStructureList()
            {
                return ObjCommon.FindAll(x => x.TypeID1 == Enums.RefObjCommon.TypeID1.Object);
            }
        }

        public static List<TableData.Main.RefSkill> RefSkill { get; set; }

        public static class NPC
        {
            public static List<TableData.NPC.RefShop> RefShop { get; set; }
            public static List<TableData.NPC.RefShopGroup> RefShopGroup { get; set; }
            public static List<TableData.NPC.RefShopItemGroup> RefShopItemGroup { get; set; }
            public static List<TableData.NPC.RefShopTab> RefShopTab { get; set; }
            public static List<TableData.NPC.RefShopTabGroup> RefShopTabGroup { get; set; }
            public static List<TableData.NPC.RefMappingShopGroup> RefMappingShopGroup { get; set; }
            public static List<TableData.NPC.RefMappingShopWithTab> RefMappingShopWithTab { get; set; }
            public static List<TableData.NPC.RefShopGoods> RefShopGoods { get; set; }
            public static List<TableData.NPC.RefPackageItem> RefPackageItem { get; set; }
            public static List<TableData.NPC.RefScrapOfPackageItem> RefScrapOfPackageItem { get; set; }
            public static List<TableData.NPC.RefPricePolicyOfItem> RefPricePolicyOfItem { get; set; }
        }

        public static class Drop
        {
            public static List<TableData.Drops.Monster_AssignedItemDrop> Monster_AssignedItemDrop { get; set; }
            public static List<TableData.Drops.Monster_AssignedItemRndDrop> Monster_AssignedItemRndDrop { get; set; }

            public static List<TableData.Drops.RefDropClassSel_Alchemy_ATTRStone> RefDropClassSel_Alchemy_ATTRStone { get; set; }
            public static List<TableData.Drops.RefDropClassSel_Alchemy_MagicStone> RefDropClassSel_Alchemy_MagicStone { get; set; }
            public static List<TableData.Drops.RefDropClassSel_Alchemy_Tablet> RefDropClassSel_Alchemy_Tablet { get; set; }
            public static List<TableData.Drops.RefDropClassSel_Ammo> RefDropClassSel_Ammo { get; set; }
            public static List<TableData.Drops.RefDropClassSel_Cure> RefDropClassSel_Cure { get; set; }
            public static List<TableData.Drops.RefDropClassSel_Equip> RefDropClassSel_Equip { get; set; }
            public static List<TableData.Drops.RefDropClassSel_RareEquip> RefDropClassSel_RareEquip { get; set; }
            public static List<TableData.Drops.RefDropClassSel_Recover> RefDropClassSel_Recover { get; set; }
            public static List<TableData.Drops.RefDropClassSel_Reinforce> RefDropClassSel_Reinforce { get; set; }
            public static List<TableData.Drops.RefDropClassSel_Scroll> RefDropClassSel_Scroll { get; set; }
            public static List<TableData.Drops.RefDropGold> RefDropGold { get; set; }
            public static List<TableData.Drops.RefDropItemAssign> RefDropItemAssign { get; set; }
            public static List<TableData.Drops.RefDropItemGroup> RefDropItemGroup { get; set; }
            public static List<TableData.Drops.RefDropOptLvlSel> RefDropOptLvlSel { get; set; }
        }

        public static class Teleport
        {
            public static List<TableData.Teleport.RefTeleport> RefTeleport { get; set; }
            public static List<TableData.Teleport.RefTeleLink> RefTeleLink { get; set; }
        }

        public static class Media
        {
            public static List<TableData.Media.TextUISystem> TextUISystem { get; set; } = new List<TableData.Media.TextUISystem>();
            public static List<TableData.Main.RefObjCommon> ObjCommon { get; set; } = new List<TableData.Main.RefObjCommon>();
            public static List<TableData.Main.RefObjItem> ObjItem { get; set; } = new List<TableData.Main.RefObjItem>();
            public static Framework.PK2Reader.Reader PK2;
            public static List<MediaData.MapFile> MapFiles = new List<MediaData.MapFile>();
        }

        public static class Other
        {
            public static List<TableData.Media.DDJFiles> DDJFiles = new List<TableData.Media.DDJFiles>();
            public static List<TableData.Others.RefHWANLevel> HWANLevels;
        }

        public static class SQL
        {
            public static IDatabase Connection = new Database(Properties.Settings.Default.Connection_ShardDB, DatabaseType.SqlServer2012);
        }
    }
}