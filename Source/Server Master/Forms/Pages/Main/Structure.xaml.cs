using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ServerMaster.Forms.Pages.RefObjCommon
{
    /// <summary>
    /// Interaction logic for Structure.xaml
    /// </summary>
    public partial class Structure : UserControl
    {
        public Structure()
        {
            InitializeComponent();
        }

        public void RefObjCommon_Structure_AramaGuncelle()
        {
            try
            {
                if (string.IsNullOrEmpty(refobjCommon_Structure_Search.Text))
                    refObjCommon_Structure.ItemsSource = Definitions.Listenings.RefObjCommon.GetStructureList();
                else
                    refObjCommon_Structure.ItemsSource = Definitions.Listenings.RefObjCommon.GetStructureList().Where(x => x.CodeName128.IndexOf(refobjCommon_Structure_Search.Text, StringComparison.InvariantCultureIgnoreCase) >= 0 || x.ID.ToString() == refobjCommon_Structure_Search.Text);
            }
            catch { }
        }

        private void RefobjCommon_Structure_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefObjCommon_Structure_AramaGuncelle();
        }

        // _RefObjCommon Sekmesinde Structure listesindeki seçim değiştiğinde gerçekleşecekler
        private void RefObjCommon_Structure_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                refObjCommon_Structure_ObjCommon.DataContext = refObjCommon_Structure.SelectedItem;
                refObjCommon_Structure_ObjStructure.DataContext = Definitions.Listenings.RefObjCommon.ObjStruct.First((Definitions.TableData.Main.RefObjStruct x) => x.ID == (refObjCommon_Structure.SelectedItem as Definitions.TableData.Main.RefObjCommon)?.Link);
            }
            catch { }
        }

        private void RefObjCommon_Structure_ObjCommon_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (refObjCommon_Structure_ObjCommon.DataContext == null)
                    return;

                Definitions.Listenings.SQL.Connection.Save(refObjCommon_Structure_ObjCommon.DataContext);
                $"[SQL][Structure][_RefObjCommon] Yapılan değişiklikler başarıyla kaydedildi. ID: {(refObjCommon_Structure_ObjCommon.DataContext as Definitions.TableData.Main.RefObjCommon)?.ID}".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RefObjCommon_Structure_ObjStructure_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (refObjCommon_Structure_ObjStructure.DataContext == null)
                    return;

                Definitions.Listenings.SQL.Connection.Save(refObjCommon_Structure_ObjStructure.DataContext);
                $"[SQL][Structure][_RefObjStruct] Yapılan değişiklikler başarıyla kaydedildi. ID: {(refObjCommon_Structure_ObjStructure.DataContext as Definitions.TableData.Main.RefObjStruct)?.ID}".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RefObjCommon_ContextMenu_Ekle_Click(object sender, RoutedEventArgs e)
        {
            foreach (var SelectedItem in refObjCommon_Structure.SelectedItems)
            {
                var ObjCommon = (SelectedItem as Definitions.TableData.Main.RefObjCommon)?.Clone() as Definitions.TableData.Main.RefObjCommon;
                var ObjStructure = Definitions.Listenings.RefObjCommon.ObjStruct.First(x => x.ID == ObjCommon.Link).Clone() as Definitions.TableData.Main.RefObjStruct;

                ObjStructure.ID = Convert.ToInt32(Definitions.Listenings.SQL.Connection.Insert(ObjStructure));
                ObjCommon.Link = ObjStructure.ID;
                ObjCommon.ID = Convert.ToInt32(Definitions.Listenings.SQL.Connection.Insert(ObjCommon));

                Definitions.Listenings.RefObjCommon.ObjCommon.Add(ObjCommon);
                Definitions.Listenings.RefObjCommon.ObjStruct.Add(ObjStructure);
            }

            RefObjCommon_Structure_AramaGuncelle();
        }

        private void RefObjCommon_ContextMenu_Sil_Click(object sender, RoutedEventArgs e)
        {
            foreach (var SelectedItem in refObjCommon_Structure.SelectedItems)
            {
                var ObjCommon = SelectedItem as Definitions.TableData.Main.RefObjCommon;
                var ObjStruct = Definitions.Listenings.RefObjCommon.ObjStruct.First(x => x.ID == ObjCommon.Link);

                Definitions.Listenings.SQL.Connection.Delete(ObjCommon);
                Definitions.Listenings.SQL.Connection.Delete(ObjStruct);

                Definitions.Listenings.RefObjCommon.ObjCommon.Remove(ObjCommon);
                Definitions.Listenings.RefObjCommon.ObjStruct.Remove(ObjStruct);
            }

            RefObjCommon_Structure_AramaGuncelle();
        }

        private async void Button_SaveAll(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                foreach (var Item in Definitions.Listenings.RefObjCommon.GetStructureList())
                {
                    Definitions.Listenings.SQL.Connection.Save(Item);
                    Definitions.Listenings.SQL.Connection.Save(Definitions.Listenings.RefObjCommon.ObjStruct.First(x => x.ID == Item.Link));
                }
            }).ConfigureAwait(false);

            MessageBox.Show("Saved.");
        }
    }
}