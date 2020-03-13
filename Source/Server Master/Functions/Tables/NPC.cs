using System;
using System.Windows;

namespace ServerMaster.Functions.Tables
{
    internal static class NPC
    {
        public static void LoadRefShopTable()
        {
            try
            {
                Definitions.Listenings.NPC.RefShop = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.NPC.RefShop>("SELECT * FROM _RefShop");

                $"[SQL] _RefShop tablosu yüklendi. Tabloda {Definitions.Listenings.NPC.RefShop.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadRefShopGroupTable()
        {
            try
            {
                Definitions.Listenings.NPC.RefShopGroup = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.NPC.RefShopGroup>("SELECT * FROM _RefShopGroup");

                $"[SQL] _RefShopGroup tablosu yüklendi. Tabloda {Definitions.Listenings.NPC.RefShopGroup.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadRefShopItemGroupTable()
        {
            try
            {
                Definitions.Listenings.NPC.RefShopItemGroup = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.NPC.RefShopItemGroup>("SELECT * FROM _RefShopItemGroup");

                $"[SQL] _RefShopItemGroup tablosu yüklendi. Tabloda {Definitions.Listenings.NPC.RefShopItemGroup.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadRefShopTabTable()
        {
            try
            {
                Definitions.Listenings.NPC.RefShopTab = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.NPC.RefShopTab>("SELECT * FROM _RefShopTab");

                $"[SQL] _RefShopTab tablosu yüklendi. Tabloda {Definitions.Listenings.NPC.RefShopTab.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadRefShopTabGroupTable()
        {
            try
            {
                Definitions.Listenings.NPC.RefShopTabGroup = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.NPC.RefShopTabGroup>("SELECT * FROM _RefShopTabGroup");

                $"[SQL] _RefShopTabGroup tablosu yüklendi. Tabloda {Definitions.Listenings.NPC.RefShopTabGroup.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadRefMappingShopGroupTable()
        {
            try
            {
                Definitions.Listenings.NPC.RefMappingShopGroup = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.NPC.RefMappingShopGroup>("SELECT * FROM _RefMappingShopGroup");

                $"[SQL] _RefMappingShopGroup tablosu yüklendi. Tabloda {Definitions.Listenings.NPC.RefMappingShopGroup.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadRefMappingShopWithTabTable()
        {
            try
            {
                Definitions.Listenings.NPC.RefMappingShopWithTab = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.NPC.RefMappingShopWithTab>("SELECT * FROM _RefMappingShopWithTab");

                $"[SQL] _RefMappingShopWithTab tablosu yüklendi. Tabloda {Definitions.Listenings.NPC.RefMappingShopWithTab.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadRefShopGoodsTable()
        {
            try
            {
                Definitions.Listenings.NPC.RefShopGoods = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.NPC.RefShopGoods>("SELECT * FROM _RefShopGoods");

                $"[SQL] _RefShopGoods tablosu yüklendi. Tabloda {Definitions.Listenings.NPC.RefShopGoods.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadRefPackageItemTable()
        {
            try
            {
                Definitions.Listenings.NPC.RefPackageItem = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.NPC.RefPackageItem>("SELECT * FROM _RefPackageItem");

                $"[SQL] _RefPackageItem tablosu yüklendi. Tabloda {Definitions.Listenings.NPC.RefPackageItem.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadRefScrapOfPackageItemTable()
        {
            try
            {
                Definitions.Listenings.NPC.RefScrapOfPackageItem = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.NPC.RefScrapOfPackageItem>("SELECT * FROM _RefScrapOfPackageItem");

                $"[SQL] _RefScrapOfPackageItem tablosu yüklendi. Tabloda {Definitions.Listenings.NPC.RefScrapOfPackageItem.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadRefPricePolicyOfItemTable()
        {
            try
            {
                Definitions.Listenings.NPC.RefPricePolicyOfItem = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.NPC.RefPricePolicyOfItem>("SELECT * FROM _RefPricePolicyOfItem");

                $"[SQL] _RefPricePolicyOfItem tablosu yüklendi. Tabloda {Definitions.Listenings.NPC.RefPricePolicyOfItem.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}