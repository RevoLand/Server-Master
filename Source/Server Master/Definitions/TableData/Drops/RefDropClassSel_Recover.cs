using NPoco;

namespace ServerMaster.Definitions.TableData.Drops
{
    [TableName("_RefDropClassSel_Recover"), PrimaryKey("MonLevel")]
    public class RefDropClassSel_Recover
    {
        public int MonLevel { get; set; }

        public double ProbGroup1 { get; set; }

        public double ProbGroup2 { get; set; }

        public double ProbGroup3 { get; set; }

        public double ProbGroup4 { get; set; }

        public double ProbGroup5 { get; set; }

        public double ProbGroup6 { get; set; }

        public double ProbGroup7 { get; set; }

    }
}