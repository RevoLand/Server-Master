using NPoco;

namespace ServerMaster.Definitions.TableData.NPC
{
    [TableName("_RefShopGroup"), PrimaryKey("ID")]
    public class RefShopGroup
    {
        public Enums.Genel.Service Service { get; set; } = Enums.Genel.Service.Active;
        public int Country { get; set; } = 15;
        public int ID { get; set; }
        public string CodeName128 { get; set; }
        public string RefNPCCodeName { get; set; } = "NPC_CH_POTION";
        public int Param1 { get; set; } = -1;
        public string Param1_Desc128 { get; set; } = "xxx";
        public int Param2 { get; set; } = -1;
        public string Param2_Desc128 { get; set; } = "xxx";
        public int Param3 { get; set; } = -1;
        public string Param3_Desc128 { get; set; } = "xxx";
        public int Param4 { get; set; } = -1;
        public string Param4_Desc128 { get; set; } = "xxx";

        [Ignore]
        public string RefNPCCodeName_Media => (RefNPCCodeName != "xxx") ? Functions.Media.TextData.FindFromTextData("SN_" + RefNPCCodeName) : "";
    }
}
