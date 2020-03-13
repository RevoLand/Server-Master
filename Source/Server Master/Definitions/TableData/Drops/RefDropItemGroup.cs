using NPoco;
using System;

namespace ServerMaster.Definitions.TableData.Drops
{
    [TableName("_RefDropItemGroup"), PrimaryKey("ID")]
    public class RefDropItemGroup : ICloneable
    {
        public int ID { get; set; }

        public byte Service { get; set; }

        public int RefItemGroupID { get; set; }

        public string CodeName128 { get; set; }

        public int RefItemID { get; set; }

        public double SelectRatio { get; set; }

        public int RefMagicGroupID { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}