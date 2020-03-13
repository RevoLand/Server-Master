using NPoco;

namespace ServerMaster.Definitions.TableData.Drops
{
    [TableName("_RefDropClassSel_Scroll"), PrimaryKey("MonLevel")]
    public class RefDropClassSel_Scroll
    {
        public int MonLevel { get; set; }

        public double ProbGroup1 { get; set; }

        public double ProbGroup2 { get; set; }

        public double ProbGroup3 { get; set; }
    }
}