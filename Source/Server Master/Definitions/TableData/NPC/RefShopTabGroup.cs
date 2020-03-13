using NPoco;

namespace ServerMaster.Definitions.TableData.NPC
{
    [TableName("_RefShopTabGroup"), PrimaryKey("ID")]
    public class RefShopTabGroup
    {
        public Enums.Genel.Service Service { get; set; } = Enums.Genel.Service.Active;
        public int Country { get; set; } = 15;
        public int ID { get; set; }
        public string CodeName128 { get; set; }
        public string StrID128_Group { get; set; }

        [Ignore]
        public string StrID128_Group_Media => Functions.Media.TextData.FindFromTextData(StrID128_Group);
    }
}
