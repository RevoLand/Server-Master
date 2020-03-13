using NPoco;
using System;

namespace ServerMaster.Definitions.TableData.Main
{
    [TableName("_RefObjStruct"), PrimaryKey("ID")]
    public class RefObjStruct : ICloneable
    {
        public int ID { get; set; }
        public int Dummy_Data { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
