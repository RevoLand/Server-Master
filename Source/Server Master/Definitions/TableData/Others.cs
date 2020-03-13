using NPoco;
using System;

namespace ServerMaster.Definitions.TableData
{
    internal static class Others
    {
        [TableName("_RefHWANLevel"), PrimaryKey("HwanLevel")]
        public class RefHWANLevel : ICloneable
        {
            public int HwanLevel { get; set; }
            public int ParamFourcc1 { get; set; }
            public int ParamValue1 { get; set; }
            public int ParamFourcc2 { get; set; }
            public int ParamValue2 { get; set; }
            public int ParamFourcc3 { get; set; }
            public int ParamValue3 { get; set; }
            public int ParamFourcc4 { get; set; }
            public int ParamValue4 { get; set; }
            public int ParamFourcc5 { get; set; }
            public int ParamValue5 { get; set; }
            public string AssocFileObj128 { get; set; }
            public string Title_CH70 { get; set; }
            public string Title_EU70 { get; set; }

            [Ignore]
            public string Title_CH70_Media => Functions.Media.TextData.FindFromTextData(Title_CH70);

            [Ignore]
            public string Title_EU70_Media => Functions.Media.TextData.FindFromTextData(Title_EU70);

            public object Clone()
            {
                return MemberwiseClone();
            }
        }
    }
}