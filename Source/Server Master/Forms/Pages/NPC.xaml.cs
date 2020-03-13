using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ServerMaster.Forms.Pages
{
    /// <summary>
    /// Interaction logic for NPC.xaml
    /// </summary>
    public partial class NPC : UserControl
    {
        public NPC()
        {
            InitializeComponent();
        }

        private void NPCListesi_Arama_TextChanged(object sender, TextChangedEventArgs e)
        {
            NPCListesi_AramaGuncelle();
        }

        public void NPCListesi_AramaGuncelle()
        {
            try
            {
                if (string.IsNullOrEmpty(NPCListesi_Arama.Text))
                    _RefShopListesi.ItemsSource = Definitions.Listenings.NPC.RefShop;
                else
                    _RefShopListesi.ItemsSource = Definitions.Listenings.NPC.RefShop.Where(x => x.CodeName128.IndexOf(NPCListesi_Arama.Text, StringComparison.InvariantCultureIgnoreCase) >= 0 || x.ID.ToString() == NPCListesi_Arama.Text);
            }
            catch { }
        }

        #region NPC Tablo Tanımlamaları

        public void RefMappingShopGroupListesi_Guncelle()
        {
            if (_RefShopListesi.SelectedItem != null)
            {
                _RefMappingShopGroupListesi.ItemsSource = Definitions.Listenings.NPC.RefMappingShopGroup.Where((Definitions.TableData.NPC.RefMappingShopGroup x) => x.RefShopCodeName == (_RefShopListesi.SelectedItem as Definitions.TableData.NPC.RefShop)?.CodeName128);
            }
            else
            {
                _RefMappingShopGroupListesi.ItemsSource = null;
            }
        }

        public void RefShopGroupListesi_Guncelle()
        {
            if (_RefMappingShopGroupListesi.SelectedItem != null)
            {
                var kaynakGroup = _RefMappingShopGroupListesi.SelectedItem as Definitions.TableData.NPC.RefMappingShopGroup;

                if (kaynakGroup.RefShopGroupCodeName == "GROUP_MALL")
                    _RefShopGroupListesi.ItemsSource = Definitions.Listenings.NPC.RefShopGroup.Where(x => x.CodeName128 == string.Concat("GROUP_", kaynakGroup.RefShopCodeName));
                else
                    _RefShopGroupListesi.ItemsSource = Definitions.Listenings.NPC.RefShopGroup.Where(x => x.CodeName128 == kaynakGroup.RefShopGroupCodeName);

                _RefMappingShopWithTabListesi.ItemsSource = Definitions.Listenings.NPC.RefMappingShopWithTab.Where((Definitions.TableData.NPC.RefMappingShopWithTab x) => x.RefShopCodeName == (_RefShopListesi.SelectedItem as Definitions.TableData.NPC.RefShop)?.CodeName128);
            }
            else
            {
                _RefShopGroupListesi.ItemsSource = null;
                _RefMappingShopWithTabListesi.ItemsSource = null;
            }
        }

        public void RefShopTabGroupListesi_Guncelle()
        {
            if (_RefMappingShopWithTabListesi.SelectedItem != null)
            {
                _RefShopTabGroupListesi.ItemsSource = Definitions.Listenings.NPC.RefShopTabGroup.Where((Definitions.TableData.NPC.RefShopTabGroup x) => x.CodeName128 == (_RefMappingShopWithTabListesi.SelectedItem as Definitions.TableData.NPC.RefMappingShopWithTab)?.RefTabGroupCodeName);
            }
            else
            {
                _RefShopTabGroupListesi.ItemsSource = null;
            }
        }

        public void RefShopTabListesi_Guncelle()
        {
            if (_RefShopTabGroupListesi.SelectedItem != null)
            {
                _RefShopTabListesi.ItemsSource = Definitions.Listenings.NPC.RefShopTab.Where((Definitions.TableData.NPC.RefShopTab x) => x.RefTabGroupCodeName == (_RefShopTabGroupListesi.SelectedItem as Definitions.TableData.NPC.RefShopTabGroup)?.CodeName128);
            }
            else
            {
                _RefShopTabListesi.ItemsSource = null;
            }
        }

        public void ItemListesi_Guncelle()
        {
            if (_RefShopTabListesi.SelectedItem != null)
            {
                _ItemListesi.ItemsSource = from _RefShopGoods in Definitions.Listenings.NPC.RefShopGoods
                                           join _RefPackageItem in Definitions.Listenings.NPC.RefPackageItem on _RefShopGoods.RefPackageItemCodeName equals _RefPackageItem.CodeName128
                                           join _RefScrapOfPackageItem in Definitions.Listenings.NPC.RefScrapOfPackageItem on _RefShopGoods.RefPackageItemCodeName equals _RefScrapOfPackageItem.RefPackageItemCodeName
                                           where _RefShopGoods.RefTabCodeName == (_RefShopTabListesi.SelectedItem as Definitions.TableData.NPC.RefShopTab)?.CodeName128
                                           orderby _RefShopGoods.SlotIndex
                                           select new { _RefShopGoods, _RefPackageItem, _RefScrapOfPackageItem };
            }
            else
            {
                _ItemListesi.ItemsSource = null;
            }
        }

        #endregion NPC Tablo Tanımlamaları

        private void NPCListesi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                /*
                 * _RefShopListesi'ndeki seçimimizi değiştirdik. Bu doğrultuda _RefMappingShopGroupListesi'ni güncelliyoruz.
                 */

                /*
                 * NPC Listesi (_RefShop tablosu) doğrudan _RefMappingShopGroup tablosuna bağlıdır.
                 *  -> _RefShop
                 *      -> _RefMappingShopGroup
                 *          -> _RefShopGroup
                 *          -> _RefMappingShopWithTab
                 *      -> _RefShopTabGroup
                 *          -> _RefShopTab
                 *              -> _RefShopGoods (Itemler)
                 *
                 */
                if (_RefShopListesi.SelectedItem == null)
                    return;

                _RefShop.DataContext = _RefShopListesi.SelectedItem as Definitions.TableData.NPC.RefShop;
                RefMappingShopGroupListesi_Guncelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RefMappingShopGroupListesi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                /*
                 * _RefMappingShopGroupListesi'ndeki seçimimizi değiştirdik. Bu doğrultuda _RefShopGroupListesi'ni güncelliyoruz.
                 */
                /*
                 * _RefMappingShopGroup tablosu doğrudan _RefShopGroup tablosuna bağlıdır.
                 * Üst tablosu ise _RefShop tablosudur.
                 */
                if (_RefMappingShopGroupListesi.SelectedItem == null)
                {
                    _RefMappingShopGroup.DataContext = null;
                    return;
                }

                _RefMappingShopGroup.DataContext = _RefMappingShopGroupListesi.SelectedItem as Definitions.TableData.NPC.RefMappingShopGroup;

                // Aynı zamanda _RefMappingShopWithTab tablosunu da günceller.
                RefShopGroupListesi_Guncelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RefShopGroupListesi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                /*
                 * _RefShopGroupListesi'ndeki seçimimizi değiştirdik. Bu doğrultuda hiçbir şey olmasına gerek yok?
                 */
                /*
                 * _RefShopGroup tablosu herhangi bir tabloya bağlı değildir?
                 * Bağlı olduğu üst tablo ise _RefMappingShopGroup tablosudur.
                 */
                if (_RefShopGroupListesi.SelectedItem == null)
                {
                    _RefShopGroup.DataContext = null;
                    return;
                }

                _RefShopGroup.DataContext = _RefShopGroupListesi.SelectedItem as Definitions.TableData.NPC.RefShopGroup;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RefMappingShopWithTabListesi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                /*
                 * _RefMappingShopWithTabListesi'ndeki seçimimizi değiştirdik. Bu doğrultuda _RefShopTabGroupListesi'ni güncelliyoruz.
                 */

                /*
                 * _RefMappingShopWithTab tablosu doğrudan _RefShopTabGroup tablosuna bağlıdır.
                 * Bağlı olduğu üst tablo ise _RefMappingShopGroup tablosudur.
                 */
                if (_RefMappingShopWithTabListesi.SelectedItem == null)
                {
                    _RefMappingShopWithTab.DataContext = null;
                    return;
                }

                _RefMappingShopWithTab.DataContext = _RefMappingShopWithTabListesi.SelectedItem as Definitions.TableData.NPC.RefMappingShopWithTab;
                RefShopTabGroupListesi_Guncelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RefShopTabGroupListesi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                /*
                 * _RefShopTabGroupListesi'ndeki seçimimizi değiştirdik. Bu doğrultuda _RefShopTabListesi'ni güncelliyoruz.
                 */
                /*
                 * _RefShopTabGroup tablosu doğrudan _RefShopTab tablosuna bağlıdır.
                 * Bağlı olduğu üst tablo ise _RefMappingShopWithTab tablosudur.
                 */
                if (_RefShopTabGroupListesi.SelectedItem == null)
                {
                    _RefShopTabGroup.DataContext = null;
                    return;
                }

                _RefShopTabGroup.DataContext = _RefShopTabGroupListesi.SelectedItem as Definitions.TableData.NPC.RefShopTabGroup;

                RefShopTabListesi_Guncelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Devre dışı, gereksiz?
        private void RefShopItemGroupListesi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                /*
                if (_RefShopItemGroupListesi.SelectedItem == null)
                {
                    _RefShopItemGroup.DataContext = null;
                    return;
                }

                _RefShopItemGroup.DataContext = _RefShopItemGroupListesi.SelectedItem as Definitions.TableData.Main.RefShopItemGroup;

                _RefShopTabListesi.ItemsSource = Definitions.Listenings.NPC.RefShopTab.Where(x => x.RefTabGroupCodeName == (_RefShopItemGroupListesi.SelectedItem as Definitions.TableData.Main.RefShopItemGroup).CodeName128);
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RefShopTabListesi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                /*
                 * _RefShopTabListesi'ndeki seçimimizi değiştirdik. Bu doğrultuda _RefShopGoods üzerinden Item Listemizi güncelliyoruz.
                 */
                /*
                 * _RefShopTab tablosu doğrudan _RefShopGoods tablosuna bağlıdır.
                 * Bağlı olduğu üst tablo ise _RefShopTabGroup tablosudur.
                 */
                if (_RefShopTabListesi.SelectedItem == null)
                {
                    _RefShopTab.DataContext = null;
                    _ItemListesi.ItemsSource = null;
                    return;
                }

                _RefShopTab.DataContext = _RefShopTabListesi.SelectedItem as Definitions.TableData.NPC.RefShopTab;

                ItemListesi_Guncelle();
                ItemEklemeListesiGuncelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RefShop_Kayit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_RefShopListesi.SelectedItem == null)
                    return;

                Definitions.Listenings.SQL.Connection.Save(_RefShopListesi.SelectedItem);
                $"[SQL][NPC][_RefShop] Yapılan değişiklikler başarıyla kaydedildi. ID: {(_RefShopListesi.SelectedItem as Definitions.TableData.NPC.RefShop)?.ID}".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RefMappingShopGroup_Kayit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_RefMappingShopGroupListesi.SelectedItem == null)
                    return;

                Definitions.Listenings.SQL.Connection.Save(_RefMappingShopGroupListesi.SelectedItem);
                $"[SQL][NPC][_RefMappingShopGroup] Yapılan değişiklikler başarıyla kaydedildi. RefShopGroupCodeName: {(_RefMappingShopGroupListesi.SelectedItem as Definitions.TableData.NPC.RefMappingShopGroup)?.RefShopGroupCodeName}".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RefShopGroup_Kayit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_RefShopGroupListesi.SelectedItem == null)
                    return;

                Definitions.Listenings.SQL.Connection.Save(_RefShopGroupListesi.SelectedItem);
                $"[SQL][NPC][_RefShopGroup] Yapılan değişiklikler başarıyla kaydedildi. ID: {(_RefShopGroupListesi.SelectedItem as Definitions.TableData.NPC.RefShopGroup)?.ID}".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RefMappingShopWithTab_Kayit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_RefMappingShopWithTabListesi.SelectedItem == null)
                    return;

                Definitions.Listenings.SQL.Connection.Save(_RefMappingShopWithTabListesi.SelectedItem);
                $"[SQL][NPC][_RefMappingShopWithTab] Yapılan değişiklikler başarıyla kaydedildi. ID: {(_RefMappingShopWithTabListesi.SelectedItem as Definitions.TableData.NPC.RefMappingShopWithTab)?.ID}".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RefShopTabGroup_Kayit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_RefShopTabGroupListesi.SelectedItem == null)
                    return;

                Definitions.Listenings.SQL.Connection.Save(_RefShopTabGroupListesi.SelectedItem);
                $"[SQL][NPC][_RefShopTabGroup] Yapılan değişiklikler başarıyla kaydedildi. ID: {(_RefShopTabGroupListesi.SelectedItem as Definitions.TableData.NPC.RefShopTabGroup)?.ID}".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RefShopItemGroup_Kayit_Click(object sender, RoutedEventArgs e)
        {
            /*
            try
            {
                if (_RefShopItemGroupListesi.SelectedItem == null)
                    return;

                Definitions.Listenings.SQL.Connection.Save(_RefShopItemGroupListesi.SelectedItem);
                Functions.Program.logToForm($"[SQL][NPC][_RefShopItemGroup] Yapılan değişiklikler başarıyla kaydedildi. ID: {(_RefShopItemGroupListesi.SelectedItem as Definitions.TableData.Main.RefShopItemGroup).GroupID}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            */
        }

        private void RefShopTab_Kayit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_RefShopTabListesi.SelectedItem == null)
                    return;

                Definitions.Listenings.SQL.Connection.Save(_RefShopTabListesi.SelectedItem);
                $"[SQL][NPC][_RefShopTab] Yapılan değişiklikler başarıyla kaydedildi. ID: {(_RefShopTabListesi.SelectedItem as Definitions.TableData.NPC.RefShopTab)?.ID}".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                // If clicked button is left (so it will not conflict with context menu)
                if ((!SystemParameters.SwapButtons && e.ChangedButton == MouseButton.Left) || (SystemParameters.SwapButtons && e.ChangedButton == MouseButton.Right))
                {
                    // Define our picturebox from sender
                    var grid = sender as Grid;

                    // Do drag & drop with our pictureBox
                    DragDrop.DoDragDrop(grid, grid.DataContext, DragDropEffects.Move);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ItemListesi_Drop(object sender, DragEventArgs e)
        {
            try
            {
                var suruklenenItemData = e.Data.GetData(e.Data.GetFormats()[0]);
                var SuruklenenItem = suruklenenItemData.GetType().GetProperties()[0].GetValue(suruklenenItemData) as Definitions.TableData.NPC.RefShopGoods;

                if (!((sender as Grid)?.DataContext.GetType().GetProperties()[0].GetValue((sender as Grid)?.DataContext) is Definitions.TableData.NPC.RefShopGoods EskiItem) || SuruklenenItem == null)
                    return;

                if (EskiItem == SuruklenenItem)
                    return;

                var yeniItemSlot = EskiItem.SlotIndex;

                EskiItem.SlotIndex = SuruklenenItem.SlotIndex;
                SuruklenenItem.SlotIndex = yeniItemSlot;

                ItemListesi_Guncelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ItemListesi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (_ItemListesi.SelectedItem == null)
                {
                    Item_RefShopGoods.DataContext = null;
                    return;
                }
                dynamic ItemBilgisi = _ItemListesi.SelectedItem;

                Item_RefShopGoods.DataContext = ItemBilgisi._RefShopGoods;
                Item_RefPackageItem.DataContext = ItemBilgisi._RefPackageItem;
                Item_RefScrapOfPackageItem.DataContext = ItemBilgisi._RefScrapOfPackageItem;

                Item_FiyatListesiGuncelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Item_FiyatListesiGuncelle()
        {
            Item_FiyatListesi.ItemsSource = Definitions.Listenings.NPC.RefPricePolicyOfItem.Where((Definitions.TableData.NPC.RefPricePolicyOfItem x) => x.RefPackageItemCodeName == (Item_RefShopGoods.DataContext as Definitions.TableData.NPC.RefShopGoods)?.RefPackageItemCodeName);
        }

        private void ItemEklemeListesiGuncelle()
        {
            try
            {
                var aranilan = ItemEklemeListesi_ItemArama.Text.ToUpperInvariant();

                if (string.IsNullOrEmpty(aranilan))
                {
                    NPC_ItemEkleme_PackageListesi.ItemsSource = from _RefScrapOfPackageItem in Definitions.Listenings.NPC.RefScrapOfPackageItem
                                                                join _RefPackageItem in Definitions.Listenings.NPC.RefPackageItem on _RefScrapOfPackageItem.RefPackageItemCodeName equals _RefPackageItem.CodeName128
                                                                orderby _RefScrapOfPackageItem.RefItemCodeName
                                                                select new { _RefPackageItem, _RefScrapOfPackageItem };

                    NPC_ItemEkleme_ObjCommonListesi.ItemsSource = Definitions.Listenings.RefObjCommon.GetItemList();
                }
                else
                {
                    NPC_ItemEkleme_PackageListesi.ItemsSource = from _RefScrapOfPackageItem in Definitions.Listenings.NPC.RefScrapOfPackageItem
                                                                join _RefPackageItem in Definitions.Listenings.NPC.RefPackageItem on _RefScrapOfPackageItem.RefPackageItemCodeName equals _RefPackageItem.CodeName128
                                                                where _RefScrapOfPackageItem.RefPackageItemCodeName.ToUpperInvariant().Contains(aranilan)
                                                                orderby _RefScrapOfPackageItem.RefItemCodeName
                                                                select new { _RefPackageItem, _RefScrapOfPackageItem };

                    NPC_ItemEkleme_ObjCommonListesi.ItemsSource = Definitions.Listenings.RefObjCommon.GetItemList().Where(x => x.CodeName128.ToUpperInvariant().Contains(aranilan) && x.Service == Definitions.Enums.Genel.Service.Active);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Item_FiyatListesi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (Item_FiyatListesi.SelectedItem == null)
                {
                    Item_RefPricePolicy.DataContext = null;
                    return;
                }

                Item_RefPricePolicy.DataContext = Item_FiyatListesi.SelectedItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Item_Kayit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (dynamic shopGoods in _ItemListesi.ItemsSource)
                {
                    Definitions.Listenings.SQL.Connection.Save(shopGoods._RefShopGoods);
                }

                Definitions.Listenings.SQL.Connection.Save(Item_RefPackageItem.DataContext);
                Definitions.Listenings.SQL.Connection.Save(Item_RefScrapOfPackageItem.DataContext);

                foreach (var shopPrice in Item_FiyatListesi.ItemsSource)
                {
                    Definitions.Listenings.SQL.Connection.Save(shopPrice);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Tab'a item sürükle bırak ile itemin bulunduğu tab'ı değiştirme
        private void RefShopTabListesi_Drop(object sender, DragEventArgs e)
        {
            try
            {
                var suruklenenItemData = e.Data.GetData(e.Data.GetFormats()[0]);
                var SuruklenenItem = suruklenenItemData.GetType().GetProperties()[0].GetValue(suruklenenItemData) as Definitions.TableData.NPC.RefShopGoods;

                if (!((sender as Grid)?.DataContext is Definitions.TableData.NPC.RefShopTab yeniTab) || SuruklenenItem == null)
                    return;

                if (SuruklenenItem.RefTabCodeName == yeniTab.CodeName128)
                    return;

                SuruklenenItem.SlotIndex = (Definitions.Listenings.NPC.RefShopGoods.Count(x => x.RefTabCodeName == yeniTab.CodeName128) > 0) ? Definitions.Listenings.NPC.RefShopGoods.Where(x => x.RefTabCodeName == yeniTab.CodeName128).OrderByDescending(x => x.SlotIndex).First().SlotIndex + 1 : 0;
                SuruklenenItem.RefTabCodeName = yeniTab.CodeName128;

                ItemListesi_Guncelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void NPC_ContextMenu_Ekle(object sender, RoutedEventArgs e)
        {
            try
            {
                switch ((sender as MenuItem)?.Tag)
                {
                    case "_RefShop":
                        Definitions.Listenings.NPC.RefShop.Add(new Definitions.TableData.NPC.RefShop
                        {
                            CodeName128 = "NewNpcShopName"
                        });

                        NPCListesi_AramaGuncelle();
                        break;

                    case "_RefMappingShopGroupListesi":
                        if (_RefShopListesi.SelectedItem == null)
                            return;

                        Definitions.Listenings.NPC.RefMappingShopGroup.Add(new Definitions.TableData.NPC.RefMappingShopGroup
                        {
                            RefShopCodeName = (_RefShopListesi.SelectedItem as Definitions.TableData.NPC.RefShop)?.CodeName128,
                            RefShopGroupCodeName = (Definitions.Listenings.NPC.RefMappingShopGroup.Count((Definitions.TableData.NPC.RefMappingShopGroup x) => x.RefShopGroupCodeName == $"GROUP_{(_RefShopListesi.SelectedItem as Definitions.TableData.NPC.RefShop)?.CodeName128}") > 0) ? $"GROUP_{(_RefShopListesi.SelectedItem as Definitions.TableData.NPC.RefShop)?.CodeName128}_YENI" : $"GROUP_{(_RefShopListesi.SelectedItem as Definitions.TableData.NPC.RefShop)?.CodeName128}"
                        });

                        RefMappingShopGroupListesi_Guncelle();
                        break;

                    case "_RefShopGroupListesi":
                        if (_RefMappingShopGroupListesi.SelectedItem == null)
                            return;

                        Definitions.Listenings.NPC.RefShopGroup.Add(new Definitions.TableData.NPC.RefShopGroup
                        {
                            CodeName128 = (_RefMappingShopGroupListesi.SelectedItem as Definitions.TableData.NPC.RefMappingShopGroup)?.RefShopGroupCodeName
                        });

                        RefShopGroupListesi_Guncelle();
                        break;

                    case "_RefMappingShopWithTabListesi":
                    case "_RefShopTabGroupListesi":
                        if (_RefShopListesi.SelectedItem == null)
                            return;

                        var RefShop = _RefShopListesi.SelectedItem as Definitions.TableData.NPC.RefShop;

                        Definitions.Listenings.NPC.RefMappingShopWithTab.Add(new Definitions.TableData.NPC.RefMappingShopWithTab
                        {
                            RefShopCodeName = RefShop.CodeName128,
                            RefTabGroupCodeName = $"{RefShop.CodeName128}_YENIGRUP"
                        });

                        Definitions.Listenings.NPC.RefShopTabGroup.Add(new Definitions.TableData.NPC.RefShopTabGroup
                        {
                            CodeName128 = $"{RefShop.CodeName128}_YENIGRUP",
                            StrID128_Group = $"STR_{RefShop.CodeName128}_YENIGRUP"
                        });

                        RefShopTabGroupListesi_Guncelle();
                        break;

                    case "_RefShopTabListesi":
                        if (_RefShopTabGroupListesi.SelectedItem == null)
                            return;

                        Definitions.Listenings.NPC.RefShopTab.Add(new Definitions.TableData.NPC.RefShopTab
                        {
                            RefTabGroupCodeName = (_RefShopTabGroupListesi.SelectedItem as Definitions.TableData.NPC.RefShopTabGroup)?.CodeName128,
                            CodeName128 = "YENINPC_TABISMI",
                            StrID128_Tab = "STR_TAB_TABISMI"
                        });

                        RefShopTabListesi_Guncelle();
                        break;

                    case "_RefPricePolicyOfItem":
                        if (Item_RefShopGoods.DataContext == null)
                            return;

                        Definitions.Listenings.NPC.RefPricePolicyOfItem.Add(new Definitions.TableData.NPC.RefPricePolicyOfItem
                        {
                            RefPackageItemCodeName = (Item_RefShopGoods.DataContext as Definitions.TableData.NPC.RefShopGoods)?.RefPackageItemCodeName
                        });

                        Item_FiyatListesiGuncelle();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void NPC_ContextMenu_Sil(object sender, RoutedEventArgs e)
        {
            try
            {
                switch ((sender as MenuItem)?.Tag)
                {
                    case "_RefMappingShopGroupListesi":
                        if (_RefMappingShopGroupListesi.SelectedItem == null)
                            return;

                        Functions.NPC.NPCRefMappingShopGroupSil(_RefMappingShopGroupListesi.SelectedItem as Definitions.TableData.NPC.RefMappingShopGroup);

                        RefMappingShopGroupListesi_Guncelle();
                        break;

                    case "_RefShopGroupListesi":
                        if (_RefShopGroupListesi.SelectedItem == null)
                            return;

                        Functions.NPC.NPCRefShopGroupSil(_RefShopGroupListesi.SelectedItem as Definitions.TableData.NPC.RefShopGroup);

                        RefShopGroupListesi_Guncelle();
                        break;

                    case "_RefMappingShopWithTabListesi":
                    case "_RefShopTabGroupListesi":
                        if (_RefMappingShopWithTabListesi.SelectedItem == null)
                            return;

                        Functions.NPC.NPCMappingTabSil(_RefMappingShopWithTabListesi.SelectedItem as Definitions.TableData.NPC.RefMappingShopWithTab, MessageBox.Show("Gruba bağlı TABlar da silinsin mi?", "Gruba bağlı Tablar", MessageBoxButton.YesNo) == MessageBoxResult.Yes);

                        RefShopGroupListesi_Guncelle();
                        break;

                    case "_RefShopTabListesi":
                        if (_RefShopTabListesi.SelectedItem == null)
                            return;

                        if (MessageBox.Show("TAB'da bulunan itemler de silinsin mi?", "TAB'da bulunan itemler?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                            Functions.NPC.NPCTabSil(_RefShopTabListesi.SelectedItem as Definitions.TableData.NPC.RefShopTab, true);
                        else
                            Functions.NPC.NPCTabSil(_RefShopTabListesi.SelectedItem as Definitions.TableData.NPC.RefShopTab, false);

                        RefShopTabListesi_Guncelle();
                        break;

                    case "_RefPricePolicyOfItem":
                        if (Item_FiyatListesi.SelectedItem == null)
                            return;

                        Definitions.Listenings.NPC.RefPricePolicyOfItem.Remove(Item_FiyatListesi.SelectedItem as Definitions.TableData.NPC.RefPricePolicyOfItem);
                        Definitions.Listenings.SQL.Connection.Delete(Item_FiyatListesi.SelectedItem as Definitions.TableData.NPC.RefPricePolicyOfItem);

                        Item_FiyatListesiGuncelle();
                        break;

                    case "_ItemListesi_Yumusak":
                        if (_ItemListesi.SelectedItems.Count == 0)
                            return;

                        foreach (dynamic item in _ItemListesi.SelectedItems)
                        {
                            Definitions.Listenings.SQL.Connection.Delete(item._RefShopGoods);
                            Definitions.Listenings.NPC.RefShopGoods.Remove(item._RefShopGoods);
                        }

                        ItemListesi_Guncelle();
                        break;

                    case "_ItemListesi":
                        if (_ItemListesi.SelectedItems.Count == 0)
                            return;

                        foreach (dynamic item in _ItemListesi.SelectedItems)
                        {
                            Functions.NPC.NPCItemSil((string)item._RefScrapOfPackageItem.RefPackageItemCodeName);
                        }

                        ItemListesi_Guncelle();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ItemEklemeListesi_ItemArama_TextChanged(object sender, TextChangedEventArgs e)
        {
            ItemEklemeListesiGuncelle();
        }

        // Package_ olarak varolan itemi tab'a ekleme
        private void ItemEklemeListesi_Packet_ItemEkle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NPC_ItemEkleme_PackageListesi.SelectedItem == null)
                    return;

                var ItemBilgisi = NPC_ItemEkleme_PackageListesi.SelectedItem.GetType().GetProperties();

                var EklenecekItem = ItemBilgisi[0].GetValue(NPC_ItemEkleme_PackageListesi.SelectedItem) as Definitions.TableData.NPC.RefPackageItem;
                var YeniTab = (_RefShopTabListesi.SelectedItem as Definitions.TableData.NPC.RefShopTab);

                if (Definitions.Listenings.NPC.RefShopGoods.Count(x => x.RefPackageItemCodeName == EklenecekItem.CodeName128 && x.RefTabCodeName == YeniTab.CodeName128) == 0)
                {
                    Definitions.Listenings.NPC.RefShopGoods.Add(new Definitions.TableData.NPC.RefShopGoods
                    {
                        Service = Definitions.Enums.Genel.Service.Active,
                        RefPackageItemCodeName = EklenecekItem.CodeName128,
                        RefTabCodeName = YeniTab.CodeName128,
                        SlotIndex = (Definitions.Listenings.NPC.RefShopGoods.Count(x => x.RefTabCodeName == YeniTab.CodeName128) == 0) ? 0 : (Definitions.Listenings.NPC.RefShopGoods.Where(x => x.RefTabCodeName == YeniTab.CodeName128).OrderByDescending(x => x.SlotIndex).First().SlotIndex) + 1
                    });

                    ItemListesi_Guncelle();
                }
                else
                {
                    $"Belirtilen item ({EklenecekItem.CodeName128}) belirtilen tab'da zaten mevcut. Bu itemi ekleyebilmek için yeni bir paket oluşturmalısınız!".LogToForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ItemEklemeListesi_ObjCommon_ItemEkle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NPC_ItemEkleme_ObjCommonListesi.SelectedItem == null)
                    return;

                var EklenecekItem = NPC_ItemEkleme_ObjCommonListesi.SelectedItem as Definitions.TableData.Main.RefObjCommon;
                var YeniTab = (_RefShopTabListesi.SelectedItem as Definitions.TableData.NPC.RefShopTab);

                var packageIsmi = Functions.NPC.MusaitPaketIsminiGetir(EklenecekItem.CodeName128);

                if (string.IsNullOrEmpty(packageIsmi))
                    throw (new Exception("Kullanıma uygun bir paket ismi bulunamadı?!"));

                if (Definitions.Listenings.NPC.RefScrapOfPackageItem.Count(x => x.RefPackageItemCodeName == packageIsmi) == 0)
                {
                    Definitions.Listenings.NPC.RefScrapOfPackageItem.Add(new Definitions.TableData.NPC.RefScrapOfPackageItem
                    {
                        RefPackageItemCodeName = packageIsmi,
                        RefItemCodeName = EklenecekItem.CodeName128
                    });
                }
                else
                {
                    $"_RefScrapOfPackageItem tablosunda belirtilen paket zaten mevcut. Paket: {packageIsmi}".LogToForm();
                }

                if (Definitions.Listenings.NPC.RefPackageItem.Count(x => x.CodeName128 == packageIsmi) == 0)
                {
                    Definitions.Listenings.NPC.RefPackageItem.Add(new Definitions.TableData.NPC.RefPackageItem
                    {
                        CodeName128 = packageIsmi,
                        NameStrID = EklenecekItem.NameStrID128,
                        DescStrID = EklenecekItem.DescStrID128,
                        AssocFileIcon = EklenecekItem.AssocFileIcon128
                    });
                }
                else
                {
                    $"_RefPackageItem tablosunda belirtilen paket zaten mevcut. Paket: {packageIsmi}".LogToForm();
                }

                if (Definitions.Listenings.NPC.RefShopGoods.Count(x => x.RefPackageItemCodeName == packageIsmi) == 0)
                {
                    Definitions.Listenings.NPC.RefShopGoods.Add(new Definitions.TableData.NPC.RefShopGoods
                    {
                        RefPackageItemCodeName = packageIsmi,
                        RefTabCodeName = YeniTab.CodeName128,
                        SlotIndex = (Definitions.Listenings.NPC.RefShopGoods.Count(x => x.RefTabCodeName == YeniTab.CodeName128) == 0) ? 0 : (Definitions.Listenings.NPC.RefShopGoods.Where(x => x.RefTabCodeName == YeniTab.CodeName128).OrderByDescending(x => x.SlotIndex).First().SlotIndex) + 1
                    });
                }
                else
                {
                    $"_RefShopGoods tablosunda belirtilen paket zaten mevcut. Paket: {packageIsmi}".LogToForm();
                }

                ItemListesi_Guncelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}