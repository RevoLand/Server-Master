using NPoco;
using System;

namespace ServerMaster.Definitions.TableData.NPC
{
    [TableName("_RefPackageItem"), PrimaryKey("ID")]
    public class RefPackageItem
    {
        public Enums.Genel.Service Service { get; set; } = Enums.Genel.Service.Active;
        public int Country { get; set; } = 15;
        public int ID { get; set; }
        public string CodeName128 { get; set; }
        public int SaleTag { get; set; } = 0;
        public string ExpandTerm { get; set; } = "EXPAND_TERM_ALL";
        public string NameStrID { get; set; }
        public string DescStrID { get; set; }
        public string AssocFileIcon { get; set; }
        public int Param1 { get; set; } = -1;
        public string Param1_Desc128 { get; set; } = "xxx";
        public int Param2 { get; set; } = -1;
        public string Param2_Desc128 { get; set; } = "xxx";
        public int Param3 { get; set; } = -1;
        public string Param3_Desc128 { get; set; } = "xxx";
        public int Param4 { get; set; } = -1;
        public string Param4_Desc128 { get; set; } = "xxx";

        private System.Windows.Media.ImageSource _MediaImage;

        [Ignore]
        public System.Windows.Media.ImageSource MediaImage
        {
            get
            {
                if (_MediaImage == null)
                {
                    var fileName = AssocFileIcon.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
                    _MediaImage = Functions.Media.Image.GetItemImage(fileName[fileName.Length - 1]);
                }

                return _MediaImage;
            }
        }
    }
}