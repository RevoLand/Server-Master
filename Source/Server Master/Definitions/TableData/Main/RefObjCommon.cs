using NPoco;
using System;

namespace ServerMaster.Definitions.TableData.Main
{
    [TableName("_RefObjCommon"), PrimaryKey("ID")]
    public class RefObjCommon : ICloneable
    {
        public Enums.Genel.Service Service { get; set; }
        public int ID { get; set; }
        public string CodeName128 { get; set; }
        public string ObjName128 { get; set; }
        public string OrgObjCodeName128 { get; set; }
        public string NameStrID128 { get; set; }
        public string DescStrID128 { get; set; }
        public Enums.RefObjCommon.CashItem CashItem { get; set; }
        public byte Bionic { get; set; }
        public Enums.RefObjCommon.TypeID1 TypeID1 { get; set; }
        public byte TypeID2 { get; set; }
        public byte TypeID3 { get; set; }
        public byte TypeID4 { get; set; }
        public int DecayTime { get; set; }
        public Enums.Genel.Country Country { get; set; }
        public Enums.RefObjCommon.Rarity Rarity { get; set; }
        public Enums.RefObjCommon.CanTrade CanTrade { get; set; }
        public Enums.RefObjCommon.CanSell CanSell { get; set; }
        public Enums.RefObjCommon.CanBuy CanBuy { get; set; }
        public Enums.RefObjCommon.CanBorrow CanBorrow { get; set; }
        public Enums.RefObjCommon.CanDrop CanDrop { get; set; }
        public Enums.RefObjCommon.CanPick CanPick { get; set; }
        public Enums.RefObjCommon.CanRepair CanRepair { get; set; }
        public Enums.RefObjCommon.CanRevive CanRevive { get; set; }
        public Enums.RefObjCommon.CanUse CanUse { get; set; }
        public Enums.RefObjCommon.CanThrow CanThrow { get; set; }
        public int Price { get; set; }
        public int CostRepair { get; set; }
        public int CostRevive { get; set; }
        public int CostBorrow { get; set; }
        public int KeepingFee { get; set; }
        public int SellPrice { get; set; }
        public Enums.RefObjCommon.ReqLevelType ReqLevelType1 { get; set; }
        public byte ReqLevel1 { get; set; }
        public Enums.RefObjCommon.ReqLevelType ReqLevelType2 { get; set; }
        public byte ReqLevel2 { get; set; }
        public Enums.RefObjCommon.ReqLevelType ReqLevelType3 { get; set; }
        public byte ReqLevel3 { get; set; }
        public Enums.RefObjCommon.ReqLevelType ReqLevelType4 { get; set; }
        public byte ReqLevel4 { get; set; }
        public int MaxContain { get; set; } // Unique vs'nin en fazla çıkartabileceği mob sayısı?
        public int RegionID { get; set; }
        public int Dir { get; set; }
        public int OffsetX { get; set; }
        public int OffsetY { get; set; }
        public int OffsetZ { get; set; }
        public int Speed1 { get; set; }
        public int Speed2 { get; set; }
        public int Scale { get; set; }
        public int BCHeight { get; set; }
        public int BCRadius { get; set; } // saldırı menzili? en yüksek değer roc'da?
        public int EventID { get; set; }
        public string AssocFileObj128 { get; set; }
        public string AssocFileDrop128 { get; set; }
        public string AssocFileIcon128 { get; set; }
        public string AssocFile1_128 { get; set; }
        public string AssocFile2_128 { get; set; }
        public int Link { get; set; }

        private System.Windows.Media.ImageSource _MediaImage;
        private string _MediaCodeName;

        [Ignore]
        public System.Windows.Media.ImageSource MediaImage
        {
            get
            {
                if (_MediaImage == null)
                {
                    var fileName = AssocFileIcon128.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
                    _MediaImage = Functions.Media.Image.GetItemImage(fileName[fileName.Length - 1]);
                }

                return _MediaImage;
            }
        }

        [Ignore]
        public string MediaCodeName
        {
            get
            {
                if (string.IsNullOrEmpty(_MediaCodeName))
                    _MediaCodeName = Functions.Media.TextData.FindFromTextData(NameStrID128);

                return _MediaCodeName;
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}