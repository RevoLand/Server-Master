using NPoco;

namespace ServerMaster.Definitions.TableData.NPC
{
    [TableName("_RefShopItemGroup"), PrimaryKey("ID")]
    public class RefShopItemGroup
    {
        public Enums.Genel.Service Service { get; set; }
        public int GroupID { get; set; }
        public string CodeName128 { get; set; }
        public string StrID128_Group { get; set; }
    }
}
