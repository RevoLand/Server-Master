using NPoco;

namespace ServerMaster.Definitions.TableData.NPC
{
    [TableName("_RefScrapOfPackageItem"), PrimaryKey("Index")]
    public class RefScrapOfPackageItem
    {
        public Enums.Genel.Service Service { get; set; } = Enums.Genel.Service.Active;
        public int Country { get; set; } = 15;
        public string RefPackageItemCodeName { get; set; }
        public string RefItemCodeName { get; set; }
        public byte OptLevel { get; set; } = 0;
        public long Variance { get; set; } = 0;
        public int Data { get; set; } = 0;
        public byte MagParamNum { get; set; } = 0;
        public long MagParam1 { get; set; } = 0;
        public long MagParam2 { get; set; } = 0;
        public long MagParam3 { get; set; } = 0;
        public long MagParam4 { get; set; } = 0;
        public long MagParam5 { get; set; } = 0;
        public long MagParam6 { get; set; } = 0;
        public long MagParam7 { get; set; } = 0;
        public long MagParam8 { get; set; } = 0;
        public long MagParam9 { get; set; } = 0;
        public long MagParam10 { get; set; } = 0;
        public long MagParam11 { get; set; } = 0;
        public long MagParam12 { get; set; } = 0;
        public int Param1 { get; set; } = -1;
        public string Param1_Desc128 { get; set; } = "xxx";
        public int Param2 { get; set; } = -1;
        public string Param2_Desc128 { get; set; } = "xxx";
        public int Param3 { get; set; } = -1;
        public string Param3_Desc128 { get; set; } = "xxx";
        public int Param4 { get; set; } = -1;
        public string Param4_Desc128 { get; set; } = "xxx";
        public int Index { get; set; }
    }

}
