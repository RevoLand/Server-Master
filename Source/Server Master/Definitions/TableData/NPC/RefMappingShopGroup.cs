using NPoco;

namespace ServerMaster.Definitions.TableData.NPC
{
    [TableName("_RefMappingShopGroup"), PrimaryKey("ID")]
    public class RefMappingShopGroup
    {
        public Enums.Genel.Service Service { get; set; } = Enums.Genel.Service.Active;
        public int Country { get; set; } = 15;
        public int ID { get; set; }
        public string RefShopGroupCodeName { get; set; }
        public string RefShopCodeName { get; set; }
    }
}
