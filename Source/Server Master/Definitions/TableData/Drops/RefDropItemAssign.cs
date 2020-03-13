using NPoco;
using System.Linq;

namespace ServerMaster.Definitions.TableData.Drops
{
    [TableName("_RefDropItemAssign"), PrimaryKey("ID")]
    public class RefDropItemAssign
    {
        public int Service { get; set; }

        public int RefItemID { get; set; }

        public int Prob_Relative { get; set; }

        public int Prob_Absolute { get; set; }

        public int AssignedGroup { get; set; }

        public int DropCount { get; set; }

        public int ID { get; set; }

        [Ignore]
        private string _CodeName128;
        [Ignore]
        public string CodeName128
        {
            get
            {
                if (string.IsNullOrEmpty(_CodeName128))
                    _CodeName128 = Listenings.RefObjCommon.ObjCommon.FirstOrDefault(x => x.ID == ID).CodeName128;

                return _CodeName128;
            }
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}