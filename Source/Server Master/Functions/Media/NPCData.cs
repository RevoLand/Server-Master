using System;
using System.IO;
using System.Linq;
using System.Windows;
using Path = Alphaleonis.Win32.Filesystem.Path;

namespace ServerMaster.Functions.Media
{
    internal static class NPCData
    {
        public static void Save()
        {
            SaveRefShop();
            SaveRefMappingShopGroup();

            SaveRefShopGroup();
            SaveRefMappingShopWithTab();

            SaveRefShopTabGroup();
            SaveRefShopTab();

            /*
             * _RefShopGoods
             * _RefPackageItem
             * _RefScrapOfPackageItem
             * _RefPricePolicyOfItem
             */
            SaveNPCShopContent();
        }

        private static async void SaveRefShop()
        {
            try
            {
                const string fileName = "RefShop.txt";

                using (var FileStream = new StreamWriter(Path.Combine(Definitions.Directories.ServerMaster.MedyaDizini.FullName, fileName), false, System.Text.Encoding.Unicode))
                {
                    foreach (var refShop in Definitions.Listenings.NPC.RefShop.Where(x => x.Service == Definitions.Enums.Genel.Service.Active).OrderBy(x => x.ID))
                    {
                        await FileStream.WriteLineAsync($"{(int)refShop.Service}\t{refShop.Country}\t{refShop.ID}\t{refShop.CodeName128}\t{refShop.Param1}\t{refShop.Param1_Desc128}\t{refShop.Param2}\t{refShop.Param2_Desc128}\t{refShop.Param3}\t{refShop.Param3_Desc128}\t{refShop.Param4}\t{refShop.Param4_Desc128}").ConfigureAwait(false);
                    }
                }

                $"[Media.PK2][NPC][{fileName}] Dosya başarıyla kayıt edildi.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static async void SaveRefMappingShopGroup()
        {
            try
            {
                const string fileName = "RefMappingShopGroup.txt";

                using (var FileStream = new StreamWriter(Path.Combine(Definitions.Directories.ServerMaster.MedyaDizini.FullName, fileName), false, System.Text.Encoding.Unicode))
                {
                    foreach (var mappingShopGroup in Definitions.Listenings.NPC.RefMappingShopGroup.Where(x => x.Service == Definitions.Enums.Genel.Service.Active).OrderBy(x => x.RefShopGroupCodeName))
                    {
                        await FileStream.WriteLineAsync($"{(int)mappingShopGroup.Service}\t{mappingShopGroup.Country}\t{mappingShopGroup.RefShopGroupCodeName}\t{mappingShopGroup.RefShopCodeName}").ConfigureAwait(false);
                    }
                }

                $"[Media.PK2][NPC][{fileName}] Dosya başarıyla kayıt edildi.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static async void SaveRefShopGroup()
        {
            try
            {
                const string fileName = "RefShopGroup.txt";

                using (var FileStream = new StreamWriter(Path.Combine(Definitions.Directories.ServerMaster.MedyaDizini.FullName, fileName), false, System.Text.Encoding.Unicode))
                {
                    foreach (var shopGroup in Definitions.Listenings.NPC.RefShopGroup.Where(x => x.Service == Definitions.Enums.Genel.Service.Active).OrderBy(x => x.ID))
                    {
                        await FileStream.WriteLineAsync($"{(int)shopGroup.Service}\t{shopGroup.Country}\t{shopGroup.ID}\t{shopGroup.CodeName128}\t{shopGroup.RefNPCCodeName}\t{shopGroup.Param1}\t{shopGroup.Param1_Desc128}\t{shopGroup.Param2}\t{shopGroup.Param2_Desc128}\t{shopGroup.Param3}\t{shopGroup.Param3_Desc128}\t{shopGroup.Param4}\t{shopGroup.Param4_Desc128}").ConfigureAwait(false);
                    }
                }

                $"[Media.PK2][NPC][{fileName}] Dosya başarıyla kayıt edildi.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static async void SaveRefMappingShopWithTab()
        {
            try
            {
                const string fileName = "RefMappingShopWithTab.txt";

                using (var FileStream = new StreamWriter(Path.Combine(Definitions.Directories.ServerMaster.MedyaDizini.FullName, fileName), false, System.Text.Encoding.Unicode))
                {
                    foreach (var mappingShopWithTab in Definitions.Listenings.NPC.RefMappingShopWithTab.Where(x => x.Service == Definitions.Enums.Genel.Service.Active).OrderBy(x => x.RefShopCodeName))
                    {
                        await FileStream.WriteLineAsync($"{(int)mappingShopWithTab.Service}\t{mappingShopWithTab.Country}\t{mappingShopWithTab.RefShopCodeName}\t{mappingShopWithTab.RefTabGroupCodeName}").ConfigureAwait(false);
                    }
                }

                $"[Media.PK2][NPC][{fileName}] Dosya başarıyla kayıt edildi.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static async void SaveRefShopTabGroup()
        {
            try
            {
                const string fileName = "RefShopTabGroup.txt";

                using (var FileStream = new StreamWriter(Path.Combine(Definitions.Directories.ServerMaster.MedyaDizini.FullName, fileName), false, System.Text.Encoding.Unicode))
                {
                    foreach (var shopTabGroup in Definitions.Listenings.NPC.RefShopTabGroup.Where(x => x.Service == Definitions.Enums.Genel.Service.Active).OrderBy(x => x.ID))
                    {
                        await FileStream.WriteLineAsync($"{(int)shopTabGroup.Service}\t{shopTabGroup.Country}\t{shopTabGroup.ID}\t{shopTabGroup.CodeName128}\t{shopTabGroup.StrID128_Group}").ConfigureAwait(false);
                    }
                }

                $"[Media.PK2][NPC][{fileName}] Dosya başarıyla kayıt edildi.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static async void SaveRefShopTab()
        {
            try
            {
                const string fileName = "RefShopTab.txt";

                using (var FileStream = new StreamWriter(Path.Combine(Definitions.Directories.ServerMaster.MedyaDizini.FullName, fileName), false, System.Text.Encoding.Unicode))
                {
                    foreach (var shopTab in Definitions.Listenings.NPC.RefShopTab.Where(x => x.Service == Definitions.Enums.Genel.Service.Active).OrderBy(x => x.ID))
                    {
                        await FileStream.WriteLineAsync($"{(int)shopTab.Service}\t{shopTab.Country}\t{shopTab.ID}\t{shopTab.CodeName128}\t{shopTab.RefTabGroupCodeName}\t{shopTab.StrID128_Tab}\txxx").ConfigureAwait(false);
                    }
                }

                $"[Media.PK2][NPC][{fileName}] Dosya başarıyla kayıt edildi.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static void SaveNPCShopContent()
        {
            SaveRefShopGoods();
            SaveRefScrapOfPackageItem();
            SaveRefPackageItem();
            SaveRefPricePolicyOfItem();
        }

        private static async void SaveRefShopGoods()
        {
            try
            {
                const string fileName = "RefShopGoods.txt";

                var slotIndex = 0;
                var latestTab = "";

                using (var FileStream = new StreamWriter(Path.Combine(Definitions.Directories.ServerMaster.MedyaDizini.FullName, fileName), false, System.Text.Encoding.Unicode))
                {
                    foreach (var shopGoods in Definitions.Listenings.NPC.RefShopGoods.Where(x => x.ID > 0 && x.Service == Definitions.Enums.Genel.Service.Active && Definitions.Listenings.NPC.RefScrapOfPackageItem.Count(y => y.RefPackageItemCodeName == x.RefPackageItemCodeName) > 0).OrderBy(x => x.RefTabCodeName).ThenBy(x => x.SlotIndex).ToList())
                    {
                        if (latestTab == shopGoods.RefTabCodeName)
                        {
                            slotIndex++;
                        }
                        else
                        {
                            slotIndex = 0;
                        }

                        latestTab = shopGoods.RefTabCodeName;
                        shopGoods.SlotIndex = slotIndex;

                        await FileStream.WriteLineAsync($"{(int)shopGoods.Service}\t{shopGoods.Country}\t{shopGoods.RefTabCodeName}\t{shopGoods.RefPackageItemCodeName}\t{shopGoods.SlotIndex}\t{shopGoods.Param1}\t{shopGoods.Param1_Desc128}\t{shopGoods.Param2}\t{shopGoods.Param2_Desc128}\t{shopGoods.Param3}\t{shopGoods.Param3_Desc128}\t{shopGoods.Param4}\t{shopGoods.Param4_Desc128}").ConfigureAwait(false);
                        await System.Threading.Tasks.Task.Run(() => Definitions.Listenings.SQL.Connection.Save(shopGoods)).ConfigureAwait(false);
                    }
                }

                $"[Media.PK2][NPC][{fileName}] Dosya başarıyla kayıt edildi.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static async void SaveRefScrapOfPackageItem()
        {
            try
            {
                const string fileName = "RefScrapOfPackageItem.txt";

                using (var FileStream = new StreamWriter(Path.Combine(Definitions.Directories.ServerMaster.MedyaDizini.FullName, fileName), false, System.Text.Encoding.Unicode))
                {
                    foreach (var scrapItem in Definitions.Listenings.NPC.RefScrapOfPackageItem.Where(x => x.Service == Definitions.Enums.Genel.Service.Active && Definitions.Listenings.RefObjCommon.ObjCommon.Count(y => y.CodeName128 == x.RefItemCodeName) > 0).OrderBy(x => x.RefPackageItemCodeName))
                    {
                        await FileStream.WriteLineAsync($"{(int)scrapItem.Service}\t{scrapItem.Country}\t{scrapItem.RefPackageItemCodeName}\t{scrapItem.RefItemCodeName}\t{scrapItem.OptLevel}\t{scrapItem.Variance}\t{scrapItem.Data}\t{scrapItem.MagParamNum}\t{scrapItem.MagParam1}\t{scrapItem.MagParam2}\t{scrapItem.MagParam3}\t{scrapItem.MagParam4}\t{scrapItem.MagParam5}\t{scrapItem.MagParam6}\t{scrapItem.MagParam7}\t{scrapItem.MagParam8}\t{scrapItem.MagParam9}\t{scrapItem.MagParam10}\t{scrapItem.MagParam11}\t{scrapItem.MagParam12}\t{scrapItem.Param1}\t{scrapItem.Param1_Desc128}\t{scrapItem.Param2}\t{scrapItem.Param2_Desc128}\t{scrapItem.Param3}\t{scrapItem.Param3_Desc128}\t{scrapItem.Param4}\t{scrapItem.Param4_Desc128}\t{scrapItem.Index}").ConfigureAwait(false);
                    }
                }

                $"[Media.PK2][NPC][{fileName}] Dosya başarıyla kayıt edildi.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static async void SaveRefPackageItem()
        {
            try
            {
                const string fileName = "RefPackageItem.txt";

                using (var FileStream = new StreamWriter(Path.Combine(Definitions.Directories.ServerMaster.MedyaDizini.FullName, fileName), false, System.Text.Encoding.Unicode))
                {
                    foreach (var packageItem in Definitions.Listenings.NPC.RefPackageItem.Where(x => x.Service == Definitions.Enums.Genel.Service.Active && Definitions.Listenings.NPC.RefScrapOfPackageItem.Count(y => y.RefPackageItemCodeName == x.CodeName128) > 0).OrderBy(x => x.ID))
                    {
                        await FileStream.WriteLineAsync($"{(int)packageItem.Service}\t{packageItem.Country}\t{packageItem.ID}\t{packageItem.CodeName128}\t{packageItem.SaleTag}\t{packageItem.ExpandTerm}\t{packageItem.NameStrID}\t{packageItem.DescStrID}\t{packageItem.AssocFileIcon}\t{packageItem.Param1}\t{packageItem.Param1_Desc128}\t{packageItem.Param2}\t{packageItem.Param2_Desc128}\t{packageItem.Param3}\t{packageItem.Param3_Desc128}\t{packageItem.Param4}\t{packageItem.Param4_Desc128}").ConfigureAwait(false);
                    }
                }

                $"[Media.PK2][NPC][{fileName}] Dosya başarıyla kayıt edildi.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static async void SaveRefPricePolicyOfItem()
        {
            try
            {
                const string fileName = "RefPricePolicyOfItem.txt";

                using (var FileStream = new StreamWriter(Path.Combine(Definitions.Directories.ServerMaster.MedyaDizini.FullName, fileName), false, System.Text.Encoding.Unicode))
                {
                    foreach (var pricePolicy in Definitions.Listenings.NPC.RefPricePolicyOfItem.Where(x => x.Service == Definitions.Enums.Genel.Service.Active && Definitions.Listenings.NPC.RefScrapOfPackageItem.Count(y => y.RefPackageItemCodeName == x.RefPackageItemCodeName) > 0).OrderBy(x => x.RefPackageItemCodeName))
                    {
                        await FileStream.WriteLineAsync($"{(int)pricePolicy.Service}\t{pricePolicy.Country}\t{pricePolicy.RefPackageItemCodeName}\t{(int)pricePolicy.PaymentDevice}\t{pricePolicy.PreviousCost}\t{pricePolicy.Cost}\t{pricePolicy.Param1}\t{pricePolicy.Param1_Desc128}\t{pricePolicy.Param2}\t{pricePolicy.Param2_Desc128}\t{pricePolicy.Param3}\t{pricePolicy.Param3_Desc128}\t{pricePolicy.Param4}\t{pricePolicy.Param4_Desc128}").ConfigureAwait(false);
                    }
                }

                $"[Media.PK2][NPC][{fileName}] Dosya başarıyla kayıt edildi.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}