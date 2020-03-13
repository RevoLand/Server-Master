using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ServerMaster.Forms.Pages.RefObjCommon
{
    /// <summary>
    /// Interaction logic for Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        public Item()
        {
            InitializeComponent();
        }

        public void RefObjCommon_Item_AramaGuncelle()
        {
            try
            {
                if (string.IsNullOrEmpty(refobjCommon_Item_Search.Text))
                {
                    refObjCommon_Item.ItemsSource = Definitions.Listenings.RefObjCommon.GetItemList().OrderBy(x => x.ID);
                }
                else
                {
                    refObjCommon_Item.ItemsSource = Definitions.Listenings.RefObjCommon.GetItemList().Where(x =>
                   x.CodeName128.IndexOf(refobjCommon_Item_Search.Text, StringComparison.InvariantCultureIgnoreCase) >= 0 || x.ID.ToString() == refobjCommon_Item_Search.Text
                   || x.NameStrID128.IndexOf(refobjCommon_Item_Search.Text, StringComparison.InvariantCultureIgnoreCase) >= 0 || x.MediaCodeName.IndexOf(refobjCommon_Item_Search.Text, StringComparison.InvariantCultureIgnoreCase) >= 0).OrderBy(x => x.ID);
                }
            }
            catch { }
        }

        private void RefobjCommon_Item_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefObjCommon_Item_AramaGuncelle();
        }

        // _RefObjCommon Sekmesinde Item listesindeki seçim değiştiğinde gerçekleşecekler
        private void RefObjCommon_Item_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                refObjCommon_Item_ObjCommon.DataContext = refObjCommon_Item.SelectedItem;
                refObjCommon_Item_ObjItem.DataContext = Definitions.Listenings.RefObjCommon.ObjItem.First((Definitions.TableData.Main.RefObjItem x) => x.ID == (refObjCommon_Item.SelectedItem as Definitions.TableData.Main.RefObjCommon)?.Link);
            }
            catch { }
        }

        private void RefObjCommon_Item_ObjCommon_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (refObjCommon_Item_ObjCommon.DataContext == null)
                    return;

                Definitions.Listenings.SQL.Connection.Save(refObjCommon_Item_ObjCommon.DataContext);
                $"[SQL][Item][_RefObjCommon] Yapılan değişiklikler başarıyla kaydedildi. ID: {(refObjCommon_Item_ObjCommon.DataContext as Definitions.TableData.Main.RefObjCommon)?.ID}".LogToForm();

                if (refObjCommon_Item_ObjItem.DataContext == null)
                    return;

                Definitions.Listenings.SQL.Connection.Save(refObjCommon_Item_ObjItem.DataContext);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RefObjCommon_Item_ObjItem_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (refObjCommon_Item_ObjItem.DataContext == null)
                    return;

                Definitions.Listenings.SQL.Connection.Save(refObjCommon_Item_ObjItem.DataContext);
                $"[SQL][Item][_RefObjItem] Yapılan değişiklikler başarıyla kaydedildi. ID: {(refObjCommon_Item_ObjItem.DataContext as Definitions.TableData.Main.RefObjItem)?.ID}".LogToForm();

                if (refObjCommon_Item_ObjCommon.DataContext == null)
                    return;

                Definitions.Listenings.SQL.Connection.Save(refObjCommon_Item_ObjCommon.DataContext);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RefObjCommon_ContextMenu_Ekle_Click(object sender, RoutedEventArgs e)
        {
            foreach (var SelectedItem in refObjCommon_Item.SelectedItems)
            {
                var ObjCommon = (SelectedItem as Definitions.TableData.Main.RefObjCommon)?.Clone() as Definitions.TableData.Main.RefObjCommon;
                var ObjItem = Definitions.Listenings.RefObjCommon.ObjItem.First(x => x.ID == ObjCommon.Link).Clone() as Definitions.TableData.Main.RefObjItem;

                ObjItem.ID = Convert.ToInt32(Definitions.Listenings.SQL.Connection.Insert(ObjItem));
                ObjCommon.Link = ObjItem.ID;
                ObjCommon.ID = Convert.ToInt32(Definitions.Listenings.SQL.Connection.Insert(ObjCommon));

                Definitions.Listenings.RefObjCommon.ObjCommon.Add(ObjCommon);
                Definitions.Listenings.RefObjCommon.ObjItem.Add(ObjItem);
            }

            RefObjCommon_Item_AramaGuncelle();
        }

        private void RefObjCommon_ContextMenu_Sil_Click(object sender, RoutedEventArgs e)
        {
            foreach (var SelectedItem in refObjCommon_Item.SelectedItems)
            {
                var ObjCommon = SelectedItem as Definitions.TableData.Main.RefObjCommon;
                var ObjItem = Definitions.Listenings.RefObjCommon.ObjItem.First(x => x.ID == ObjCommon.Link);

                Definitions.Listenings.SQL.Connection.Delete(ObjCommon);
                Definitions.Listenings.SQL.Connection.Delete(ObjItem);

                Definitions.Listenings.RefObjCommon.ObjCommon.Remove(ObjCommon);
                Definitions.Listenings.RefObjCommon.ObjItem.Remove(ObjItem);
            }

            RefObjCommon_Item_AramaGuncelle();
        }

        private async void Button_SaveAll(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                foreach (var Item in Definitions.Listenings.RefObjCommon.GetItemList())
                {
                    Definitions.Listenings.SQL.Connection.Save(Item);
                    Definitions.Listenings.SQL.Connection.Save(Definitions.Listenings.RefObjCommon.ObjItem.First(x => x.ID == Item.Link));
                }
            }).ConfigureAwait(false);

            MessageBox.Show("Saved.");
        }
    }
}