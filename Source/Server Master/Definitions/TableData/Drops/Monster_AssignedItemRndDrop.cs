using NPoco;
using System;
using System.Linq;

namespace ServerMaster.Definitions.TableData.Drops
{
    [TableName("_RefMonster_AssignedItemRndDrop"), PrimaryKey("ID")]
    public class Monster_AssignedItemRndDrop : ICloneable
    {
        public byte Service { get; set; }

        public int RefMonsterID { get; set; }

        public int RefItemGroupID { get; set; }

        public string ItemGroupCodeName128 { get; set; }

        public byte Overlap { get; set; }

        public byte DropAmountMin { get; set; }

        public byte DropAmountMax { get; set; }

        public double DropRatio { get; set; }

        public int param1 { get; set; }

        public int param2 { get; set; }

        public int ID { get; set; }

        [Ignore]
        public string RefMonsterCodeName => Listenings.RefObjCommon.ObjCommon.Single(x => x.ID == RefMonsterID).CodeName128;

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}