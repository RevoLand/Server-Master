using NPoco;

namespace ServerMaster.Definitions.TableData.NPC
{
    [TableName("_RefMappingShopWithTab"), PrimaryKey("ID")]
    public class RefMappingShopWithTab
    {
        public Enums.Genel.Service Service { get; set; } = Enums.Genel.Service.Active;
        public int Country { get; set; } = 15;
        public int ID { get; set; }
        public string RefShopCodeName { get; set; }
        public string RefTabGroupCodeName { get; set; }
    }
}
