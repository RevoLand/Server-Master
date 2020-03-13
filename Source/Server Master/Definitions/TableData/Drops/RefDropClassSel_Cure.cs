﻿using NPoco;

namespace ServerMaster.Definitions.TableData.Drops
{
    [TableName("_RefDropClassSel_Cure"), PrimaryKey("MonLevel")]
    public class RefDropClassSel_Cure
    {
        public int MonLevel { get; set; }

        public double ProbGroup1 { get; set; }

        public double ProbGroup2 { get; set; }

        public double ProbGroup3 { get; set; }

        public double ProbGroup4 { get; set; }

        public double ProbGroup5 { get; set; }

        public double ProbGroup6 { get; set; }

        public double? ProbGroup7 { get; set; }

        public double? ProbGroup8 { get; set; }

        public double? ProbGroup9 { get; set; }

        public double? ProbGroup10 { get; set; }

        public double? ProbGroup11 { get; set; }

        public double? ProbGroup12 { get; set; }

        public double? ProbGroup13 { get; set; }

        public double? ProbGroup14 { get; set; }
    }
}