using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ServerMaster.Forms.Pages.RefObjCommon
{
    /// <summary>
    /// Interaction logic for MobsAndPets.xaml
    /// </summary>
    public partial class MobsAndPets : UserControl
    {
        public MobsAndPets()
        {
            InitializeComponent();
        }

        public void RefObjCommon_Mob_AramaGuncelle()
        {
            try
            {
                if (string.IsNullOrEmpty(refobjCommon_Mob_Search.Text))
                {
                    refObjCommon_Mob.ItemsSource = Definitions.Listenings.RefObjCommon.GetMobList().OrderBy(x => x.ID);
                }
                else
                {
                    refObjCommon_Mob.ItemsSource = Definitions.Listenings.RefObjCommon.GetMobList().Where(x =>
                    x.CodeName128.IndexOf(refobjCommon_Mob_Search.Text, StringComparison.InvariantCultureIgnoreCase) >= 0 || x.ID.ToString() == refobjCommon_Mob_Search.Text
                    || x.MediaCodeName.IndexOf(refobjCommon_Mob_Search.Text, StringComparison.InvariantCultureIgnoreCase) >= 0).OrderBy(x => x.ID);
                }
            }
            catch { }
        }

        private void RefobjCommon_Mob_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefObjCommon_Mob_AramaGuncelle();
        }

        // _RefObjCommon Sekmesinde Mob listesindeki seçim değiştiğinde gerçekleşecekler
        private void RefObjCommon_Mob_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                refObjCommon_Mob_ObjCommon.DataContext = refObjCommon_Mob.SelectedItem;
                refObjCommon_Mob_ObjChar.DataContext = Definitions.Listenings.RefObjCommon.ObjChar.First((Definitions.TableData.Main.RefObjChar x) => x.ID == (refObjCommon_Mob.SelectedItem as Definitions.TableData.Main.RefObjCommon)?.Link);
            }
            catch { }
        }

        private void RefObjCommon_Mob_ObjCommon_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (refObjCommon_Mob_ObjCommon.DataContext == null)
                    return;

                Definitions.Listenings.SQL.Connection.Save(refObjCommon_Mob_ObjCommon.DataContext);

                $"[SQL][Mob][_RefObjCommon] Yapılan değişiklikler başarıyla kaydedildi. ID: {(refObjCommon_Mob_ObjCommon.DataContext as Definitions.TableData.Main.RefObjCommon)?.ID}".LogToForm();

                if (refObjCommon_Mob_ObjChar.DataContext == null)
                    return;

                Definitions.Listenings.SQL.Connection.Save(refObjCommon_Mob_ObjChar.DataContext);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RefObjCommon_Mob_ObjChar_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (refObjCommon_Mob_ObjChar.DataContext == null)
                    return;

                Definitions.Listenings.SQL.Connection.Save(refObjCommon_Mob_ObjChar.DataContext);
                $"[SQL][Mob][_RefObjChar] Yapılan değişiklikler başarıyla kaydedildi. ID: {(refObjCommon_Mob_ObjChar.DataContext as Definitions.TableData.Main.RefObjChar)?.ID}".LogToForm();

                if (refObjCommon_Mob_ObjCommon.DataContext == null)
                    return;

                Definitions.Listenings.SQL.Connection.Save(refObjCommon_Mob_ObjCommon.DataContext);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RefObjCommon_ContextMenu_Ekle_Click(object sender, RoutedEventArgs e)
        {
            foreach (var SelectedItem in refObjCommon_Mob.SelectedItems)
            {
                var ObjCommon = (SelectedItem as Definitions.TableData.Main.RefObjCommon)?.Clone() as Definitions.TableData.Main.RefObjCommon;
                var ObjChar = Definitions.Listenings.RefObjCommon.ObjChar.First(x => x.ID == ObjCommon.Link).Clone() as Definitions.TableData.Main.RefObjChar;

                ObjChar.ID = Convert.ToInt32(Definitions.Listenings.SQL.Connection.Insert(ObjChar));
                ObjCommon.Link = ObjChar.ID;
                ObjCommon.ID = Convert.ToInt32(Definitions.Listenings.SQL.Connection.Insert(ObjCommon));

                Definitions.Listenings.RefObjCommon.ObjCommon.Add(ObjCommon);
                Definitions.Listenings.RefObjCommon.ObjChar.Add(ObjChar);
            }

            RefObjCommon_Mob_AramaGuncelle();
        }

        private void RefObjCommon_ContextMenu_Sil_Click(object sender, RoutedEventArgs e)
        {
            foreach (var SelectedItem in refObjCommon_Mob.SelectedItems)
            {
                var ObjCommon = SelectedItem as Definitions.TableData.Main.RefObjCommon;
                var ObjChar = Definitions.Listenings.RefObjCommon.ObjChar.First(x => x.ID == ObjCommon.Link);

                Definitions.Listenings.SQL.Connection.Delete(ObjCommon);
                Definitions.Listenings.SQL.Connection.Delete(ObjChar);

                Definitions.Listenings.RefObjCommon.ObjCommon.Remove(ObjCommon);
                Definitions.Listenings.RefObjCommon.ObjChar.Remove(ObjChar);
            }

            RefObjCommon_Mob_AramaGuncelle();
        }

        private async void Button_SaveAll(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                foreach (var Item in Definitions.Listenings.RefObjCommon.GetMobList())
                {
                    Definitions.Listenings.SQL.Connection.Save(Item);
                    Definitions.Listenings.SQL.Connection.Save(Definitions.Listenings.RefObjCommon.ObjChar.First(x => x.ID == Item.Link));
                }
            }).ConfigureAwait(false);

            MessageBox.Show("Saved.");
        }
    }
}