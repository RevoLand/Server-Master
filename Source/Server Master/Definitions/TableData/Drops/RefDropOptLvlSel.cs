using NPoco;

namespace ServerMaster.Definitions.TableData.Drops
{
    [TableName("_RefDropOptLvlSel"), PrimaryKey("OptLevel")]
    public class RefDropOptLvlSel
    {
        public byte OptLevel { get; set; }

        public double Prob { get; set; }

        public int ReqOnlineTime { get; set; }
    }
}