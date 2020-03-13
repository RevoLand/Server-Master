using System;
using System.Diagnostics;
using Alphaleonis.Win32.Filesystem;
using System.Linq;
using System.Windows;

namespace ServerMaster.Functions.Media
{
    public static class DataParser
    {
        public static void ParseItemdata(string[] DataFiles, bool ClearList = true)
        {
            try
            {
                if (ClearList)
                {
                    Definitions.Listenings.Media.ObjCommon.Clear();
                    Definitions.Listenings.Media.ObjItem.Clear();
                }

                foreach (var _dataFile in DataFiles)
                {
                    foreach (var _dataLine in File.ReadAllLines(_dataFile))
                    {
                        var _dataRows = _dataLine.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);

                        if (_dataRows.Length != 160)
                        {
                            Debug.WriteLine($"Not applicable item data line: {_dataLine}");
                            continue;
                        }

                        var objCommon = new Definitions.TableData.Main.RefObjCommon();
                        var objItem = new Definitions.TableData.Main.RefObjItem();
                        objCommon.Link = Definitions.Listenings.Media.ObjItem.Count + 1;

                        objCommon.Service = _dataRows[0].ParseEnum<Definitions.Enums.Genel.Service>();
                        objCommon.CodeName128 = _dataRows[2];
                        objCommon.ObjName128 = _dataRows[3];
                        objCommon.OrgObjCodeName128 = _dataRows[4];
                        objCommon.NameStrID128 = _dataRows[5];
                        objCommon.DescStrID128 = _dataRows[6];
                        objCommon.CashItem = _dataRows[7].ParseEnum<Definitions.Enums.RefObjCommon.CashItem>();
                        objCommon.Bionic = Convert.ToByte(_dataRows[8]);
                        objCommon.TypeID1 = _dataRows[9].ParseEnum<Definitions.Enums.RefObjCommon.TypeID1>();
                        objCommon.TypeID2 = Convert.ToByte(_dataRows[10]);
                        objCommon.TypeID3 = Convert.ToByte(_dataRows[11]);
                        objCommon.TypeID4 = Convert.ToByte(_dataRows[12]);
                        objCommon.DecayTime = Convert.ToInt32(_dataRows[13]);
                        objCommon.Country = _dataRows[14].ParseEnum<Definitions.Enums.Genel.Country>();
                        objCommon.Rarity = _dataRows[15].ParseEnum<Definitions.Enums.RefObjCommon.Rarity>();
                        objCommon.CanTrade = _dataRows[16].ParseEnum<Definitions.Enums.RefObjCommon.CanTrade>();
                        objCommon.CanSell = _dataRows[17].ParseEnum<Definitions.Enums.RefObjCommon.CanSell>();
                        objCommon.CanBuy = _dataRows[18].ParseEnum<Definitions.Enums.RefObjCommon.CanBuy>();
                        objCommon.CanBorrow = _dataRows[19].ParseEnum<Definitions.Enums.RefObjCommon.CanBorrow>();
                        objCommon.CanDrop = _dataRows[20].ParseEnum<Definitions.Enums.RefObjCommon.CanDrop>();
                        objCommon.CanPick = _dataRows[21].ParseEnum<Definitions.Enums.RefObjCommon.CanPick>();
                        objCommon.CanRepair = _dataRows[22].ParseEnum<Definitions.Enums.RefObjCommon.CanRepair>();
                        objCommon.CanRevive = _dataRows[23].ParseEnum<Definitions.Enums.RefObjCommon.CanRevive>();
                        objCommon.CanUse = _dataRows[24].ParseEnum<Definitions.Enums.RefObjCommon.CanUse>();
                        objCommon.CanThrow = _dataRows[25].ParseEnum<Definitions.Enums.RefObjCommon.CanThrow>();
                        objCommon.Price = Convert.ToInt32(_dataRows[26]);
                        objCommon.CostRepair = Convert.ToInt32(_dataRows[27]);
                        objCommon.CostRevive = Convert.ToInt32(_dataRows[28]);
                        objCommon.CostBorrow = Convert.ToInt32(_dataRows[29]);
                        objCommon.KeepingFee = Convert.ToInt32(_dataRows[30]);
                        objCommon.SellPrice = Convert.ToInt32(_dataRows[31]);
                        objCommon.ReqLevelType1 = _dataRows[32].ParseEnum<Definitions.Enums.RefObjCommon.ReqLevelType>();
                        objCommon.ReqLevel1 = Convert.ToByte(_dataRows[33]);
                        objCommon.ReqLevelType2 = _dataRows[34].ParseEnum<Definitions.Enums.RefObjCommon.ReqLevelType>();
                        objCommon.ReqLevel2 = Convert.ToByte(_dataRows[35]);
                        objCommon.ReqLevelType3 = _dataRows[36].ParseEnum<Definitions.Enums.RefObjCommon.ReqLevelType>();
                        objCommon.ReqLevel3 = Convert.ToByte(_dataRows[37]);
                        objCommon.ReqLevelType4 = _dataRows[38].ParseEnum<Definitions.Enums.RefObjCommon.ReqLevelType>();
                        objCommon.ReqLevel4 = Convert.ToByte(_dataRows[39]);
                        objCommon.MaxContain = Convert.ToInt32(_dataRows[40]);
                        objCommon.RegionID = Convert.ToInt32(_dataRows[41]);
                        objCommon.Dir = Convert.ToInt32(_dataRows[42]);
                        objCommon.OffsetX = Convert.ToInt32(_dataRows[43]);
                        objCommon.OffsetY = Convert.ToInt32(_dataRows[44]);
                        objCommon.OffsetZ = Convert.ToInt32(_dataRows[45]);
                        objCommon.Speed1 = Convert.ToInt32(_dataRows[46]);
                        objCommon.Speed2 = Convert.ToInt32(_dataRows[47]);
                        objCommon.Scale = Convert.ToInt32(_dataRows[48]);
                        objCommon.BCHeight = Convert.ToInt32(_dataRows[49]);
                        objCommon.BCRadius = Convert.ToInt32(_dataRows[50]);
                        objCommon.EventID = Convert.ToInt32(_dataRows[51]);
                        objCommon.AssocFileObj128 = _dataRows[52];
                        objCommon.AssocFileDrop128 = _dataRows[53];
                        objCommon.AssocFileIcon128 = _dataRows[54];
                        objCommon.AssocFile1_128 = _dataRows[55];
                        objCommon.AssocFile2_128 = _dataRows[56];

                        objItem.ID = objCommon.Link;
                        objItem.MaxStack = Convert.ToInt32(_dataRows[57]);
                        objItem.ReqGender = _dataRows[58].ParseEnum<Definitions.Enums.Genel.ReqGender>();
                        objItem.ReqStr = Convert.ToInt32(_dataRows[59]);
                        objItem.ReqInt = Convert.ToInt32(_dataRows[60]);
                        objItem.ItemClass = _dataRows[61].ParseEnum<Definitions.Enums.Genel.ItemClass>();
                        objItem.SetID = Convert.ToInt32(_dataRows[62]);
                        objItem.Dur_L = _dataRows[63];
                        objItem.Dur_U = _dataRows[64];
                        objItem.PD_L = _dataRows[65];
                        objItem.PD_U = _dataRows[66];
                        objItem.PDInc = _dataRows[67];
                        objItem.ER_L = _dataRows[68];
                        objItem.ER_U = _dataRows[69];
                        objItem.ERInc = _dataRows[70];
                        objItem.PAR_L = _dataRows[71];
                        objItem.PAR_U = _dataRows[72];
                        objItem.PARInc = _dataRows[73];
                        objItem.BR_L = _dataRows[74];
                        objItem.BR_U = _dataRows[75];
                        objItem.MD_L = _dataRows[76];
                        objItem.MD_U = _dataRows[77];
                        objItem.MDInc = _dataRows[78];
                        objItem.MAR_L = _dataRows[79];
                        objItem.MAR_U = _dataRows[80];
                        objItem.MARInc = _dataRows[81];
                        objItem.PDStr_L = _dataRows[82];
                        objItem.PDStr_U = _dataRows[83];
                        objItem.MDInt_L = _dataRows[84];
                        objItem.MDInt_U = _dataRows[85];
                        objItem.Quivered = _dataRows[86].ParseEnum<Definitions.Enums.RefObjItem.Quivered>();
                        objItem.Ammo1_TID4 = _dataRows[87].ParseEnum<Definitions.Enums.RefObjItem.Ammo1_TID4>();
                        objItem.Ammo2_TID4 = Convert.ToByte(_dataRows[88]);
                        objItem.Ammo3_TID4 = Convert.ToByte(_dataRows[89]);
                        objItem.Ammo4_TID4 = Convert.ToByte(_dataRows[90]);
                        objItem.Ammo5_TID4 = Convert.ToByte(_dataRows[91]);
                        objItem.SpeedClass = _dataRows[92].ParseEnum<Definitions.Enums.RefObjItem.SpeedClass>();
                        objItem.TwoHanded = _dataRows[93].ParseEnum<Definitions.Enums.RefObjItem.TwoHanded>();
                        objItem.Range = Convert.ToInt32(_dataRows[94]);
                        objItem.PAttackMin_L = Convert.ToDouble(_dataRows[95]);
                        objItem.PAttackMin_U = Convert.ToDouble(_dataRows[96]);
                        objItem.PAttackMax_L = Convert.ToDouble(_dataRows[97]);
                        objItem.PAttackMax_U = Convert.ToDouble(_dataRows[98]);
                        objItem.PAttackInc = Convert.ToDouble(_dataRows[99]);
                        objItem.MAttackMin_L = Convert.ToDouble(_dataRows[100]);
                        objItem.MAttackMin_U = Convert.ToDouble(_dataRows[101]);
                        objItem.MAttackMax_L = Convert.ToDouble(_dataRows[102]);
                        objItem.MAttackMax_U = Convert.ToDouble(_dataRows[103]);
                        objItem.MAttackInc = Convert.ToDouble(_dataRows[104]);
                        objItem.PAStrMin_L = Convert.ToDouble(_dataRows[105]);
                        objItem.PAStrMin_U = Convert.ToDouble(_dataRows[106]);
                        objItem.PAStrMax_L = Convert.ToDouble(_dataRows[107]);
                        objItem.PAStrMax_U = Convert.ToDouble(_dataRows[108]);
                        objItem.MAInt_Min_L = Convert.ToDouble(_dataRows[109]);
                        objItem.MAInt_Min_U = Convert.ToDouble(_dataRows[110]);
                        objItem.MAInt_Max_L = Convert.ToDouble(_dataRows[111]);
                        objItem.MAInt_Max_U = Convert.ToDouble(_dataRows[112]);
                        objItem.HR_L = Convert.ToDouble(_dataRows[113]);
                        objItem.HR_U = Convert.ToDouble(_dataRows[114]);
                        objItem.HRInc = Convert.ToDouble(_dataRows[115]);
                        objItem.CHR_L = Convert.ToDouble(_dataRows[116]);
                        objItem.CHR_U = Convert.ToDouble(_dataRows[117]);

                        objItem.Param1 = Convert.ToInt32(_dataRows[118]);
                        objItem.Desc1_128 = _dataRows[119];
                        objItem.Param2 = Convert.ToInt32(_dataRows[120]);
                        objItem.Desc2_128 = _dataRows[121];
                        objItem.Param3 = Convert.ToInt32(_dataRows[122]);
                        objItem.Desc3_128 = _dataRows[123];
                        objItem.Param4 = Convert.ToInt32(_dataRows[124]);
                        objItem.Desc4_128 = _dataRows[125];
                        objItem.Param5 = Convert.ToInt32(_dataRows[126]);
                        objItem.Desc5_128 = _dataRows[127];
                        objItem.Param6 = Convert.ToInt32(_dataRows[128]);
                        objItem.Desc6_128 = _dataRows[129];
                        objItem.Param7 = Convert.ToInt32(_dataRows[130]);
                        objItem.Desc7_128 = _dataRows[131];
                        objItem.Param8 = Convert.ToInt32(_dataRows[132]);
                        objItem.Desc8_128 = _dataRows[133];
                        objItem.Param9 = Convert.ToInt32(_dataRows[134]);
                        objItem.Desc9_128 = _dataRows[135];
                        objItem.Param10 = Convert.ToInt32(_dataRows[136]);
                        objItem.Desc10_128 = _dataRows[137];
                        objItem.Param11 = Convert.ToInt32(_dataRows[138]);
                        objItem.Desc11_128 = _dataRows[139];
                        objItem.Param12 = Convert.ToInt32(_dataRows[140]);
                        objItem.Desc12_128 = _dataRows[141];
                        objItem.Param13 = Convert.ToInt32(_dataRows[142]);
                        objItem.Desc13_128 = _dataRows[143];
                        objItem.Param14 = Convert.ToInt32(_dataRows[144]);
                        objItem.Desc14_128 = _dataRows[145];
                        objItem.Param15 = Convert.ToInt32(_dataRows[146]);
                        objItem.Desc15_128 = _dataRows[147];
                        objItem.Param16 = Convert.ToInt32(_dataRows[148]);
                        objItem.Desc16_128 = _dataRows[149];
                        objItem.Param17 = Convert.ToInt32(_dataRows[150]);
                        objItem.Desc17_128 = _dataRows[151];
                        objItem.Param18 = Convert.ToInt32(_dataRows[152]);
                        objItem.Desc18_128 = _dataRows[153];
                        objItem.Param19 = Convert.ToInt32(_dataRows[154]);
                        objItem.Desc19_128 = _dataRows[155];
                        objItem.Param20 = Convert.ToInt32(_dataRows[156]);
                        objItem.Desc20_128 = _dataRows[157];
                        objItem.MaxMagicOptCount = _dataRows[158].ParseEnum<Definitions.Enums.RefObjItem.MaxMagicOptCount>();
                        objItem.ChildItemCount = _dataRows[159].ParseEnum<Definitions.Enums.RefObjItem.ChildItemCount>();

                        if (Definitions.Listenings.RefObjCommon.ObjCommon.Any(x => x.CodeName128 == objCommon.CodeName128))
                        {
                            objCommon.Service = Definitions.Enums.Genel.Service.Passive;
                        }

                        Definitions.Listenings.Media.ObjCommon.Add(objCommon);
                        Definitions.Listenings.Media.ObjItem.Add(objItem);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Debug.WriteLine(ex);
            }
        }
    }
}