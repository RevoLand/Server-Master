using NPoco;

namespace ServerMaster.Definitions.TableData.NPC
{
    [TableName("_RefShopGoods"), PrimaryKey("ID")]
    public class RefShopGoods
    {
        public Enums.Genel.Service Service { get; set; } = Enums.Genel.Service.Active;
        public int Country { get; set; } = 15;
        public int ID { get; set; }
        public string RefTabCodeName { get; set; }
        public string RefPackageItemCodeName { get; set; }
        public int SlotIndex { get; set; }
        public int Param1 { get; set; } = -1;
        public string Param1_Desc128 { get; set; } = "xxx";
        public int Param2 { get; set; } = -1;
        public string Param2_Desc128 { get; set; } = "xxx";
        public int Param3 { get; set; } = -1;
        public string Param3_Desc128 { get; set; } = "xxx";
        public int Param4 { get; set; } = -1;
        public string Param4_Desc128 { get; set; } = "xxx";
    }
}
