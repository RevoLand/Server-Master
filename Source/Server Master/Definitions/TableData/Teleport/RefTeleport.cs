using NPoco;
using System;

namespace ServerMaster.Definitions.TableData.Teleport
{
    [TableName("_RefTeleport"), PrimaryKey("ID", AutoIncrement = true)]
    public class RefTeleport : ICloneable
    {
        public Enums.Genel.Service Service { get; set; } = Enums.Genel.Service.Active;
        public int ID { get; set; }
        public string CodeName128 { get; set; }
        public string AssocRefObjCodeName128 { get; set; }
        public int AssocRefObjID { get; set; }
        public string ZoneName128 { get; set; }
        public int GenRegionID { get; set; }
        public int GenPos_X { get; set; }
        public int GenPos_Y { get; set; }
        public int GenPos_Z { get; set; }
        public int GenAreaRadius { get; set; }
        public int CanBeResurrectPos { get; set; }
        public int CanGotoResurrectPos { get; set; }
        public int GenWorldID { get; set; } = 1;
        public int BindInteractionMask { get; set; } = 0; // Textdata'ya eklenmeyecek
        public int FixedService { get; set; } = 0; // Textdata'ya eklenmeyecek

        [Ignore]
        public string ZoneName128_Media => Functions.Media.TextData.FindFromTextData(ZoneName128);

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
