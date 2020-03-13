using NPoco;

namespace ServerMaster.Definitions.TableData.Drops
{
    [TableName("_RefDropClassSel_Reinforce"), PrimaryKey("MonLevel")]
    public class RefDropClassSel_Reinforce
    {
        public int MonLevel { get; set; }

        public double ProbGroup1 { get; set; }

        public double ProbGroup2 { get; set; }
    }
}