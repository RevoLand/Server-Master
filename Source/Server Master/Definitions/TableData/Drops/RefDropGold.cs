using NPoco;

namespace ServerMaster.Definitions.TableData.Drops
{
    [TableName("_RefDropGold"), PrimaryKey("MonLevel")]
    public class RefDropGold
    {
        public byte MonLevel { get; set; }

        public double DropProb { get; set; }

        public int GoldMin { get; set; }

        public int GoldMax { get; set; }
    }
}