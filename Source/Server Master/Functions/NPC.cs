using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ServerMaster.Functions
{
    internal static class NPC
    {
        public static string MusaitPaketIsminiGetir(string CodeName128)
        {
            try
            {
                var packetIsim = $"PACKAGE_{CodeName128}";

                if (Definitions.Listenings.NPC.RefScrapOfPackageItem.Any(x => x.RefPackageItemCodeName == packetIsim))
                {
                    return MusaitPaketIsminiGetir($"{CodeName128}_1");
                }
                else
                {
                    return packetIsim;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        public static void NPCRefMappingShopGroupSil(Definitions.TableData.NPC.RefMappingShopGroup MappingShopGroup)
        {
            Definitions.Listenings.NPC.RefMappingShopGroup.Remove(MappingShopGroup);
            SqlSil(MappingShopGroup);

            List<Definitions.TableData.NPC.RefShopGroup> RefShopGroupListesi;

            if (MappingShopGroup.RefShopGroupCodeName == "GROUP_MALL")
                RefShopGroupListesi = Definitions.Listenings.NPC.RefShopGroup.Where(x => x.CodeName128 == string.Concat("GROUP_", MappingShopGroup.RefShopCodeName)).ToList();
            else
                RefShopGroupListesi = Definitions.Listenings.NPC.RefShopGroup.Where(x => x.CodeName128 == MappingShopGroup.RefShopGroupCodeName).ToList();

            foreach (var ShopGroup in RefShopGroupListesi)
            {
                NPCRefShopGroupSil(ShopGroup);
            }
        }

        public static void NPCRefShopGroupSil(Definitions.TableData.NPC.RefShopGroup ShopGroup)
        {
            Definitions.Listenings.NPC.RefShopGroup.Remove(ShopGroup);
            SqlSil(ShopGroup);

            foreach (var MappingTab in Definitions.Listenings.NPC.RefMappingShopWithTab.Where(x => x.RefShopCodeName == ShopGroup.CodeName128.Replace("GROUP_", "")).ToList())
            {
                NPCMappingTabSil(MappingTab, true);
            }
        }

        public static void NPCMappingTabSil(Definitions.TableData.NPC.RefMappingShopWithTab MappingTab, bool TabGruplariSil)
        {
            Definitions.Listenings.NPC.RefMappingShopWithTab.Remove(MappingTab);
            SqlSil(MappingTab);

            foreach (var ShopTabGroup in Definitions.Listenings.NPC.RefShopTabGroup.Where(x => x.CodeName128 == MappingTab.RefTabGroupCodeName).ToList())
            {
                Definitions.Listenings.NPC.RefShopTabGroup.Remove(ShopTabGroup);
                SqlSil(ShopTabGroup);
            }

            if (TabGruplariSil)
            {
                var ItemleriSil = MessageBox.Show("Tab içeriğinde bulunan itemler de silinsin mi?", "İtemler silinsin mi?", MessageBoxButton.YesNo) == MessageBoxResult.Yes;
                foreach (var ShopTab in Definitions.Listenings.NPC.RefShopTab.Where(x => x.RefTabGroupCodeName == MappingTab.RefTabGroupCodeName).ToList())
                {
                    NPCTabSil(ShopTab, ItemleriSil);
                }
            }
        }

        public static void NPCItemSil(string PaketKodIsmi)
        {
            foreach (var fiyat in Definitions.Listenings.NPC.RefPricePolicyOfItem.Where(x => x.RefPackageItemCodeName == PaketKodIsmi).ToList())
            {
                SqlSil(fiyat);
                Definitions.Listenings.NPC.RefPricePolicyOfItem.Remove(fiyat);

                $"[SQL][NPC][_RefPricePolicyOfItem] Belirtilmiş item ile ilgili veriler silindi. Item: {fiyat.RefPackageItemCodeName}".LogToForm();
            }

            foreach (var npcItem in Definitions.Listenings.NPC.RefShopGoods.Where(x => x.RefPackageItemCodeName == PaketKodIsmi).ToList())
            {
                SqlSil(npcItem);
                Definitions.Listenings.NPC.RefShopGoods.Remove(npcItem);

                $"[SQL][NPC][_RefShopGoods] Belirtilmiş item ile ilgili veriler silindi. Item: {npcItem.RefPackageItemCodeName}".LogToForm();
            }

            foreach (var packageItem in Definitions.Listenings.NPC.RefPackageItem.Where(x => x.CodeName128 == PaketKodIsmi).ToList())
            {
                SqlSil(packageItem);
                Definitions.Listenings.NPC.RefPackageItem.Remove(packageItem);

                $"[SQL][NPC][_RefPackageItem] Belirtilmiş item ile ilgili veriler silindi. Item: {packageItem.CodeName128}".LogToForm();
            }

            foreach (var scrapItem in Definitions.Listenings.NPC.RefScrapOfPackageItem.Where(x => x.RefPackageItemCodeName == PaketKodIsmi).ToList())
            {
                SqlSil(scrapItem);
                Definitions.Listenings.NPC.RefScrapOfPackageItem.Remove(scrapItem);

                $"[SQL][NPC][_RefScrapOfPackageItem] Belirtilmiş item ile ilgili veriler silindi. Item: {scrapItem.RefPackageItemCodeName}".LogToForm();
            }
        }

        public static void NPCTabSil(Definitions.TableData.NPC.RefShopTab Tab, bool ItemleriSil)
        {
            Definitions.Listenings.NPC.RefShopTab.Remove(Tab);
            SqlSil(Tab);

            if (!ItemleriSil)
                return;

            foreach (var shopGoods in Definitions.Listenings.NPC.RefShopGoods.Where(x => x.RefTabCodeName == Tab.CodeName128).ToList())
            {
                Definitions.Listenings.NPC.RefShopGoods.Remove(shopGoods);
                SqlSil(shopGoods);
            }
        }

        private static void SqlSil(object Silinecek)
        {
            Definitions.Listenings.SQL.Connection.Delete(Silinecek);
        }
    }
}