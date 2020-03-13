using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Path = Alphaleonis.Win32.Filesystem.Path;

namespace ServerMaster.Functions.Media
{
    internal static class ItemData
    {
        public static async void SaveAsync(List<Definitions.TableData.Main.RefObjCommon> refObjCommon, int DataLineCount = 5000)
        {
            try
            {
                using (var itemDataFile = new StreamWriter(Path.Combine(Definitions.Directories.ServerMaster.MedyaDizini.FullName, "itemdata.txt"), false, System.Text.Encoding.Unicode))
                {
                    for (int i = 0, j, k = 0; k < refObjCommon.Count; i = j)
                    {
                        j = i + DataLineCount;

                        if (!refObjCommon.Any(x => x.ID >= i && x.ID < j))
                            continue;

                        var fileName = $"itemdata_{j}.txt";
                        await itemDataFile.WriteLineAsync(fileName).ConfigureAwait(false);

                        using (var itemData = new StreamWriter(Path.Combine(Definitions.Directories.ServerMaster.MedyaDizini.FullName, fileName), false, System.Text.Encoding.Unicode))
                        {
                            foreach (var objCommon in refObjCommon.Where(x => x.ID >= i && x.ID < j).OrderBy(x => x.ID))
                            {
                                var objItem = Definitions.Listenings.RefObjCommon.ObjItem.First(x => objCommon.Link == x.ID);

                                if (objItem == null)
                                    continue;

                                if (objItem.Desc2_128 == "xxx                                                                                                                              ")
                                    objItem.Desc2_128 = "xxx";

                                await itemData.WriteLineAsync($"{(int)objCommon.Service}\t{objCommon.ID}\t{objCommon.CodeName128}\t{objCommon.ObjName128}\t{objCommon.OrgObjCodeName128}\t{objCommon.NameStrID128}\t{objCommon.DescStrID128}\t{(int)objCommon.CashItem}\t{objCommon.Bionic}\t{(int)objCommon.TypeID1}\t{objCommon.TypeID2}\t{objCommon.TypeID3}\t{objCommon.TypeID4}\t{objCommon.DecayTime}\t{(int)objCommon.Country}\t{(int)objCommon.Rarity}\t{(int)objCommon.CanTrade}\t{(int)objCommon.CanSell}\t{(int)objCommon.CanBuy}\t{(int)objCommon.CanBorrow}\t{(int)objCommon.CanDrop}\t{(int)objCommon.CanPick}\t{(int)objCommon.CanRepair}\t{(int)objCommon.CanRevive}\t{(int)objCommon.CanUse}\t{(int)objCommon.CanThrow}\t{objCommon.Price}\t{objCommon.CostRepair}\t{objCommon.CostRevive}\t{objCommon.CostBorrow}\t{objCommon.KeepingFee}\t{objCommon.SellPrice}\t{(int)objCommon.ReqLevelType1}\t{objCommon.ReqLevel1}\t{(int)objCommon.ReqLevelType2}\t{objCommon.ReqLevel2}\t{(int)objCommon.ReqLevelType3}\t{objCommon.ReqLevel3}\t{(int)objCommon.ReqLevelType4}\t{objCommon.ReqLevel4}\t{objCommon.MaxContain}\t{objCommon.RegionID}\t{objCommon.Dir}\t{objCommon.OffsetX}\t{objCommon.OffsetY}\t{objCommon.OffsetZ}\t{objCommon.Speed1}\t{objCommon.Speed2}\t{objCommon.Scale}\t{objCommon.BCHeight}\t{objCommon.BCRadius}\t{objCommon.EventID}\t{objCommon.AssocFileObj128}\t{objCommon.AssocFileDrop128}\t{objCommon.AssocFileIcon128}\t{objCommon.AssocFile1_128}\t{objCommon.AssocFile2_128}\t{objItem.MaxStack}\t{(int)objItem.ReqGender}\t{objItem.ReqStr}\t{objItem.ReqInt}\t{(int)objItem.ItemClass}\t{objItem.SetID}\t{objItem.Dur_L}\t{objItem.Dur_U}\t{objItem.PD_L}\t{objItem.PD_U}\t{objItem.PDInc}\t{objItem.ER_L}\t{objItem.ER_U}\t{objItem.ERInc}\t{objItem.PAR_L}\t{objItem.PAR_U}\t{objItem.PARInc}\t{objItem.BR_L}\t{objItem.BR_U}\t{objItem.MD_L}\t{objItem.MD_U}\t{objItem.MDInc}\t{objItem.MAR_L}\t{objItem.MAR_U}\t{objItem.MARInc}\t{objItem.PDStr_L}\t{objItem.PDStr_U}\t{objItem.MDInt_L}\t{objItem.MDInt_U}\t{(int)objItem.Quivered}\t{(int)objItem.Ammo1_TID4}\t{objItem.Ammo2_TID4}\t{objItem.Ammo3_TID4}\t{objItem.Ammo4_TID4}\t{objItem.Ammo5_TID4}\t{(int)objItem.SpeedClass}\t{(int)objItem.TwoHanded}\t{objItem.Range}\t{objItem.PAttackMin_L}\t{objItem.PAttackMin_U}\t{objItem.PAttackMax_L}\t{objItem.PAttackMax_U}\t{objItem.PAttackInc}\t{objItem.MAttackMin_L}\t{objItem.MAttackMin_U}\t{objItem.MAttackMax_L}\t{objItem.MAttackMax_U}\t{objItem.MAttackInc}\t{objItem.PAStrMin_L}\t{objItem.PAStrMin_U}\t{objItem.PAStrMax_L}\t{objItem.PAStrMax_U}\t{objItem.MAInt_Min_L}\t{objItem.MAInt_Min_U}\t{objItem.MAInt_Max_L}\t{objItem.MAInt_Max_U}\t{objItem.HR_L}\t{objItem.HR_U}\t{objItem.HRInc}\t{objItem.CHR_L}\t{objItem.CHR_U}\t{objItem.Param1}\t{objItem.Desc1_128}\t{objItem.Param2}\t{objItem.Desc2_128}\t{objItem.Param3}\t{objItem.Desc3_128}\t{objItem.Param4}\t{objItem.Desc4_128}\t{objItem.Param5}\t{objItem.Desc5_128}\t{objItem.Param6}\t{objItem.Desc6_128}\t{objItem.Param7}\t{objItem.Desc7_128}\t{objItem.Param8}\t{objItem.Desc8_128}\t{objItem.Param9}\t{objItem.Desc9_128}\t{objItem.Param10}\t{objItem.Desc10_128}\t{objItem.Param11}\t{objItem.Desc11_128}\t{objItem.Param12}\t{objItem.Desc12_128}\t{objItem.Param13}\t{objItem.Desc13_128}\t{objItem.Param14}\t{objItem.Desc14_128}\t{objItem.Param15}\t{objItem.Desc15_128}\t{objItem.Param16}\t{objItem.Desc16_128}\t{objItem.Param17}\t{objItem.Desc17_128}\t{objItem.Param18}\t{objItem.Desc18_128}\t{objItem.Param19}\t{objItem.Desc19_128}\t{objItem.Param20}\t{objItem.Desc20_128}\t{(int)objItem.MaxMagicOptCount}\t{(int)objItem.ChildItemCount}").ConfigureAwait(false);
                                k++;
                            }
                        }
                        $"[Media.PK2][Item][{fileName}] Dosya başarıyla kayıt edildi.".LogToForm();
                    }
                }

                "[Media.PK2][Item] İşlem başarıyla tamamlandı.".LogToForm();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }
    }
}