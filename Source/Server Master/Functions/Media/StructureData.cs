using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using Path = Alphaleonis.Win32.Filesystem.Path;

namespace ServerMaster.Functions.Media
{
    internal static class StructureData
    {
        public static async void SaveAsync(List<Definitions.TableData.Main.RefObjCommon> refObjCommon)
        {
            try
            {
                const string fileName = "teleportbuilding.txt";

                using (var structureData = new StreamWriter(Path.Combine(Definitions.Directories.ServerMaster.MedyaDizini.FullName, fileName), false, System.Text.Encoding.Unicode))
                {
                    foreach (var objCommon in refObjCommon.OrderBy(x => x.ID))
                    {
                        var objStruct = Definitions.Listenings.RefObjCommon.ObjStruct.First(x => objCommon.Link == x.ID);

                        if (objStruct == null)
                        {
                            MessageBox.Show($"objStruct is not found for RefObjCommon ID: {objCommon.ID}");
                            continue;
                        }

                        await structureData.WriteLineAsync($"{(int)objCommon.Service}\t{objCommon.ID}\t{objCommon.CodeName128}\t{objCommon.ObjName128}\t{objCommon.OrgObjCodeName128}\t{objCommon.NameStrID128}\t{objCommon.DescStrID128}\t{(int)objCommon.CashItem}\t{objCommon.Bionic}\t{(int)objCommon.TypeID1}\t{objCommon.TypeID2}\t{objCommon.TypeID3}\t{objCommon.TypeID4}\t{objCommon.DecayTime}\t{(int)objCommon.Country}\t{(int)objCommon.Rarity}\t{(int)objCommon.CanTrade}\t{(int)objCommon.CanSell}\t{(int)objCommon.CanBuy}\t{(int)objCommon.CanBorrow}\t{(int)objCommon.CanDrop}\t{(int)objCommon.CanPick}\t{(int)objCommon.CanRepair}\t{(int)objCommon.CanRevive}\t{(int)objCommon.CanUse}\t{(int)objCommon.CanThrow}\t{objCommon.Price}\t{objCommon.CostRepair}\t{objCommon.CostRevive}\t{objCommon.CostBorrow}\t{objCommon.KeepingFee}\t{objCommon.SellPrice}\t{(int)objCommon.ReqLevelType1}\t{objCommon.ReqLevel1}\t{(int)objCommon.ReqLevelType2}\t{objCommon.ReqLevel2}\t{(int)objCommon.ReqLevelType3}\t{objCommon.ReqLevel3}\t{(int)objCommon.ReqLevelType4}\t{objCommon.ReqLevel4}\t{objCommon.MaxContain}\t{objCommon.RegionID}\t{objCommon.Dir}\t{objCommon.OffsetX}\t{objCommon.OffsetY}\t{objCommon.OffsetZ}\t{objCommon.Speed1}\t{objCommon.Speed2}\t{objCommon.Scale}\t{objCommon.BCHeight}\t{objCommon.BCRadius}\t{objCommon.EventID}\t{objCommon.AssocFileObj128}\t{objCommon.AssocFileDrop128}\t{objCommon.AssocFileIcon128}\t{objCommon.AssocFile1_128}\t{objCommon.AssocFile2_128}\t{objStruct.Dummy_Data}").ConfigureAwait(false);
                    }
                }
                $"[Media.PK2][Structure][{fileName}] Dosya başarıyla kayıt edildi.".LogToForm();
                "[Media.PK2][Structure] İşlem başarıyla tamamlandı.".LogToForm();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }
    }
}