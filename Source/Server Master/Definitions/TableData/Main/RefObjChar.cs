using NPoco;
using System;

namespace ServerMaster.Definitions.TableData.Main
{
    [TableName("_RefObjChar"), PrimaryKey("ID")]
    public class RefObjChar : ICloneable
    {
        public int ID { get; set; }
        public int Lvl { get; set; }
        public Enums.Genel.ReqGender CharGender { get; set; }
        public int MaxHP { get; set; }
        public int MaxMP { get; set; }
        public int ResistFrozen { get; set; }
        public int ResistFrostbite { get; set; }
        public int ResistBurn { get; set; }
        public int ResistEShock { get; set; }
        public int ResistPoison { get; set; }
        public int ResistZombie { get; set; }
        public int ResistSleep { get; set; }
        public int ResistRoot { get; set; }
        public int ResistSlow { get; set; }
        public int ResistFear { get; set; }
        public int ResistMyopia { get; set; }
        public int ResistBlood { get; set; }
        public int ResistStone { get; set; }
        public int ResistDark { get; set; }
        public int ResistStun { get; set; }
        public int ResistDisea { get; set; }
        public int ResistChaos { get; set; }
        public int ResistCsePD { get; set; }
        public int ResistCseMD { get; set; }
        public int ResistCseSTR { get; set; }
        public int ResistCseINT { get; set; }
        public int ResistCseHP { get; set; }
        public int ResistCseMP { get; set; }
        public Enums.RefObjChar.Resist Resist24 { get; set; }
        public Enums.RefObjChar.Resist ResistBomb { get; set; }
        public Enums.RefObjChar.Resist Resist26 { get; set; }
        public Enums.RefObjChar.Resist Resist27 { get; set; }
        public Enums.RefObjChar.Resist Resist28 { get; set; }
        public Enums.RefObjChar.Resist Resist29 { get; set; }
        public Enums.RefObjChar.Resist Resist30 { get; set; }
        public Enums.RefObjChar.Resist Resist31 { get; set; }
        public Enums.RefObjChar.Resist Resist32 { get; set; }
        public int InventorySize { get; set; }
        public Enums.RefObjChar.CanStore_TID1_2 CanStore_TID1 { get; set; }
        public Enums.RefObjChar.CanStore_TID1_2 CanStore_TID2 { get; set; }
        public Enums.RefObjChar.CanStore_TID3 CanStore_TID3 { get; set; }
        public Enums.RefObjChar.CanStore_TID4 CanStore_TID4 { get; set; }
        public Enums.RefObjChar.CanBeVehicle CanBeVehicle { get; set; }
        public Enums.RefObjChar.CanControl CanControl { get; set; }
        public byte DamagePortion { get; set; } // 0
        public byte MaxPassenger { get; set; } // Artırmak denenebilir mi? Artırılırsa kullanıcı nasıl binebilir?
        public int AssocTactics { get; set; }
        public int PD { get; set; }  //Physical defence
        public int MD { get; set; }  //Magical defence
        public int PAR { get; set; }  //Physical absorb rate
        public int MAR { get; set; }  //Magical absorb rate
        public int ER { get; set; }  //Evasion rate (Parry rate)
        public int BR { get; set; }  //Block rate
        public int HR { get; set; }  //Hit rate (Attack rate)
        public int CHR { get; set; }  //Critical hit rate
        public int ExpToGive { get; set; }
        public Enums.RefObjChar.CreepType CreepType { get; set; }
        public int Knockdown { get; set; } // 0, 1, 2, 3, 15
        public int KO_RecoverTime { get; set; } // 0, 2000, 3000
        public int DefaultSkill_1 { get; set; }
        public int DefaultSkill_2 { get; set; }
        public int DefaultSkill_3 { get; set; }
        public int DefaultSkill_4 { get; set; }
        public int DefaultSkill_5 { get; set; }
        public int DefaultSkill_6 { get; set; }
        public int DefaultSkill_7 { get; set; }
        public int DefaultSkill_8 { get; set; }
        public int DefaultSkill_9 { get; set; }
        public int DefaultSkill_10 { get; set; }
        public Enums.RefObjChar.TextureType TextureType { get; set; }
        public int Except_1 { get; set; }
        public int Except_2 { get; set; }
        public int Except_3 { get; set; }
        public int Except_4 { get; set; }
        public int Except_5 { get; set; }
        public int Except_6 { get; set; }
        public int Except_7 { get; set; }
        public int Except_8 { get; set; }
        public int Except_9 { get; set; }
        public int Except_10 { get; set; }
        public int Link { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}