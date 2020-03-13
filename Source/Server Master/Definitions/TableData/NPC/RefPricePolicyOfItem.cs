using NPoco;

namespace ServerMaster.Definitions.TableData.NPC
{
    [TableName("_RefPricePolicyOfItem"), PrimaryKey("ID")]
    public class RefPricePolicyOfItem
    {
        public Enums.Genel.Service Service { get; set; } = Enums.Genel.Service.Active;
        public int Country { get; set; } = 15;
        public int ID { get; set; }
        public string RefPackageItemCodeName { get; set; }
        public Enums.Genel.PaymentDevice PaymentDevice { get; set; } = Enums.Genel.PaymentDevice.Gold;
        public int PreviousCost { get; set; } = 0;
        public int Cost { get; set; } = 0;
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