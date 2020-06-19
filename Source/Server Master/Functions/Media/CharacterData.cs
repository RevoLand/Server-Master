using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Path = Alphaleonis.Win32.Filesystem.Path;

namespace ServerMaster.Functions.Media
{
    internal static class CharacterData
    {
        public static async void SaveAsync(List<Definitions.TableData.Main.RefObjCommon> refObjCommon, int DataLineCount = 5000)
        {
            try
            {
                using (var characterDataFile = new StreamWriter(Path.Combine(Definitions.Directories.ServerMaster.MedyaDizini.FullName, "characterdata.txt"), false, System.Text.Encoding.Unicode))
                {
                    for (int i = 0, j, k = 0; k < refObjCommon.Count; i = j)
                    {
                        j = i + DataLineCount;

                        if (!refObjCommon.Any(x => x.ID >= i && x.ID < j))
                            continue;

                        var fileName = $"characterdata_{j}.txt";
                        await characterDataFile.WriteLineAsync(fileName).ConfigureAwait(false);

                        using (var characterData = new StreamWriter(Path.Combine(Definitions.Directories.ServerMaster.MedyaDizini.FullName, fileName), false, System.Text.Encoding.Unicode))
                        {
                            foreach (var objCommon in refObjCommon.Where(x => x.ID >= i && x.ID < j).OrderBy(x => x.ID))
                            {
                                var objChar = Definitions.Listenings.RefObjCommon.ObjChar.First(x => objCommon.Link == x.ID);

                                if (objChar == null)
                                    continue;

                                await characterData.WriteLineAsync($"{(int)objCommon.Service}\t{objCommon.ID}\t{objCommon.CodeName128}\t{objCommon.ObjName128}\t{objCommon.OrgObjCodeName128}\t{objCommon.NameStrID128}\t{objCommon.DescStrID128}\t{(int)objCommon.CashItem}\t{objCommon.Bionic}\t{(int)objCommon.TypeID1}\t{objCommon.TypeID2}\t{objCommon.TypeID3}\t{objCommon.TypeID4}\t{objCommon.DecayTime}\t{(int)objCommon.Country}\t{(int)objCommon.Rarity}\t{(int)objCommon.CanTrade}\t{(int)objCommon.CanSell}\t{(int)objCommon.CanBuy}\t{(int)objCommon.CanBorrow}\t{(int)objCommon.CanDrop}\t{(int)objCommon.CanPick}\t{(int)objCommon.CanRepair}\t{(int)objCommon.CanRevive}\t{(int)objCommon.CanUse}\t{(int)objCommon.CanThrow}\t{objCommon.Price}\t{objCommon.CostRepair}\t{objCommon.CostRevive}\t{objCommon.CostBorrow}\t{objCommon.KeepingFee}\t{objCommon.SellPrice}\t{(int)objCommon.ReqLevelType1}\t{objCommon.ReqLevel1}\t{(int)objCommon.ReqLevelType2}\t{objCommon.ReqLevel2}\t{(int)objCommon.ReqLevelType3}\t{objCommon.ReqLevel3}\t{(int)objCommon.ReqLevelType4}\t{objCommon.ReqLevel4}\t{objCommon.MaxContain}\t{objCommon.RegionID}\t{objCommon.Dir}\t{objCommon.OffsetX}\t{objCommon.OffsetY}\t{objCommon.OffsetZ}\t{objCommon.Speed1}\t{objCommon.Speed2}\t{objCommon.Scale}\t{objCommon.BCHeight}\t{objCommon.BCRadius}\t{objCommon.EventID}\t{objCommon.AssocFileObj128}\t{objCommon.AssocFileDrop128}\t{objCommon.AssocFileIcon128}\t{objCommon.AssocFile1_128}\t{objCommon.AssocFile2_128}\t{objChar.Lvl}\t{(int)objChar.CharGender}\t{objChar.MaxHP}\t{objChar.MaxMP}\t{objChar.ResistFrozen}\t{objChar.ResistFrostbite}\t{objChar.ResistBurn}\t{objChar.ResistEShock}\t{objChar.ResistPoison}\t{objChar.ResistZombie}\t{objChar.ResistSleep}\t{objChar.ResistRoot}\t{objChar.ResistSlow}\t{objChar.ResistFear}\t{objChar.ResistMyopia}\t{objChar.ResistBlood}\t{objChar.ResistStone}\t{objChar.ResistDark}\t{objChar.ResistStun}\t{objChar.ResistDisea}\t{objChar.ResistChaos}\t{objChar.ResistCsePD}\t{objChar.ResistCseMD}\t{objChar.ResistCseSTR}\t{objChar.ResistCseINT}\t{objChar.ResistCseHP}\t{objChar.ResistCseMP}\t{objChar.Resist24}\t{objChar.ResistBomb}\t{objChar.Resist26}\t{objChar.Resist27}\t{objChar.Resist28}\t{objChar.Resist29}\t{objChar.Resist30}\t{objChar.Resist31}\t{objChar.Resist32}\t{objChar.InventorySize}\t{(int)objChar.CanStore_TID1}\t{(int)objChar.CanStore_TID2}\t{(int)objChar.CanStore_TID3}\t{(int)objChar.CanStore_TID4}\t{(int)objChar.CanBeVehicle}\t{(int)objChar.CanControl}\t{objChar.DamagePortion}\t{objChar.MaxPassenger}\t{objChar.AssocTactics}\t{objChar.PD}\t{objChar.MD}\t{objChar.PAR}\t{objChar.MAR}\t{objChar.ER}\t{objChar.BR}\t{objChar.HR}\t{objChar.CHR}\t{objChar.ExpToGive}\t{(int)objChar.CreepType}\t{objChar.Knockdown}\t{objChar.KO_RecoverTime}\t{objChar.DefaultSkill_1}\t{objChar.DefaultSkill_2}\t{objChar.DefaultSkill_3}\t{objChar.DefaultSkill_4}\t{objChar.DefaultSkill_5}\t{objChar.DefaultSkill_6}\t{objChar.DefaultSkill_7}\t{objChar.DefaultSkill_8}\t{objChar.DefaultSkill_9}\t{objChar.DefaultSkill_10}\t{(int)objChar.TextureType}\t{objChar.Except_1}\t{objChar.Except_2}\t{objChar.Except_3}\t{objChar.Except_4}\t{objChar.Except_5}\t{objChar.Except_6}\t{objChar.Except_7}\t{objChar.Except_8}\t{objChar.Except_9}\t{objChar.Except_10}\t{objChar.Link}").ConfigureAwait(false);
                                k++;
                            }
                        }
                        $"[Media.PK2][Karakter][{fileName}] Dosya başarıyla kayıt edildi.".LogToForm();
                    }
                }

                "[Media.PK2][Karakter] İşlem başarıyla tamamlandı.".LogToForm();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }
    }
}