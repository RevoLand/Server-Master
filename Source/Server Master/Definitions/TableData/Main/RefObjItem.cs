using NPoco;
using System;

namespace ServerMaster.Definitions.TableData.Main
{
    [TableName("_RefObjItem"), PrimaryKey("ID")]
    public class RefObjItem : ICloneable
    {
        public int ID { get; set; }
        public int MaxStack { get; set; }
        public Enums.Genel.ReqGender ReqGender { get; set; }
        public int ReqStr { get; set; }
        public int ReqInt { get; set; }
        public Enums.Genel.ItemClass ItemClass { get; set; } // 1-60 arası class var, 1 ve 60 dahil
        public int SetID { get; set; }
        public string Dur_L { get; set; }
        public string Dur_U { get; set; }
        public string PD_L { get; set; }
        public string PD_U { get; set; }
        public string PDInc { get; set; }
        public string ER_L { get; set; }
        public string ER_U { get; set; }
        public string ERInc { get; set; }
        public string PAR_L { get; set; }
        public string PAR_U { get; set; }
        public string PARInc { get; set; }
        public string BR_L { get; set; }
        public string BR_U { get; set; }
        public string MD_L { get; set; }
        public string MD_U { get; set; }
        public string MDInc { get; set; }
        public string MAR_L { get; set; }
        public string MAR_U { get; set; }
        public string MARInc { get; set; }
        public string PDStr_L { get; set; }
        public string PDStr_U { get; set; }
        public string MDInt_L { get; set; }
        public string MDInt_U { get; set; }
        public Enums.RefObjItem.Quivered Quivered { get; set; }
        public Enums.RefObjItem.Ammo1_TID4 Ammo1_TID4 { get; set; }
        public byte Ammo2_TID4 { get; set; }
        public byte Ammo3_TID4 { get; set; }
        public byte Ammo4_TID4 { get; set; }
        public byte Ammo5_TID4 { get; set; }
        public Enums.RefObjItem.SpeedClass SpeedClass { get; set; }
        public Enums.RefObjItem.TwoHanded TwoHanded { get; set; }
        public int Range { get; set; }
        public double PAttackMin_L { get; set; }
        public double PAttackMin_U { get; set; }
        public double PAttackMax_L { get; set; }
        public double PAttackMax_U { get; set; }
        public double PAttackInc { get; set; }
        public double MAttackMin_L { get; set; }
        public double MAttackMin_U { get; set; }
        public double MAttackMax_L { get; set; }
        public double MAttackMax_U { get; set; }
        public double MAttackInc { get; set; }
        public double PAStrMin_L { get; set; }
        public double PAStrMin_U { get; set; }
        public double PAStrMax_L { get; set; }
        public double PAStrMax_U { get; set; }
        public double MAInt_Min_L { get; set; }
        public double MAInt_Min_U { get; set; }
        public double MAInt_Max_L { get; set; }
        public double MAInt_Max_U { get; set; }
        public double HR_L { get; set; }
        public double HR_U { get; set; }
        public double HRInc { get; set; }
        public double CHR_L { get; set; }
        public double CHR_U { get; set; }
        public int Param1 { get; set; }
        public string Desc1_128 { get; set; }
        public int Param2 { get; set; }
        public string Desc2_128 { get; set; }
        public int Param3 { get; set; }
        public string Desc3_128 { get; set; }
        public int Param4 { get; set; }
        public string Desc4_128 { get; set; }
        public int Param5 { get; set; }
        public string Desc5_128 { get; set; }
        public int Param6 { get; set; }
        public string Desc6_128 { get; set; }
        public int Param7 { get; set; }
        public string Desc7_128 { get; set; }
        public int Param8 { get; set; }
        public string Desc8_128 { get; set; }
        public int Param9 { get; set; }
        public string Desc9_128 { get; set; }
        public int Param10 { get; set; }
        public string Desc10_128 { get; set; }
        public int Param11 { get; set; }
        public string Desc11_128 { get; set; }
        public int Param12 { get; set; }
        public string Desc12_128 { get; set; }
        public int Param13 { get; set; }
        public string Desc13_128 { get; set; }
        public int Param14 { get; set; }
        public string Desc14_128 { get; set; }
        public int Param15 { get; set; }
        public string Desc15_128 { get; set; }
        public int Param16 { get; set; }
        public string Desc16_128 { get; set; }
        public int Param17 { get; set; }
        public string Desc17_128 { get; set; }
        public int Param18 { get; set; }
        public string Desc18_128 { get; set; }
        public int Param19 { get; set; }
        public string Desc19_128 { get; set; }
        public int Param20 { get; set; }
        public string Desc20_128 { get; set; }
        public Enums.RefObjItem.MaxMagicOptCount MaxMagicOptCount { get; set; }
        public Enums.RefObjItem.ChildItemCount ChildItemCount { get; set; }
        public int Link { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}