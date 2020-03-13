using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ServerMaster.Forms.Pages.Others
{
    /// <summary>
    /// Interaction logic for RefTeleportPage.xaml
    /// </summary>
    public partial class RefTeleportPage : UserControl
    {
        public RefTeleportPage()
        {
            InitializeComponent();
        }

        private void RefTeleport_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefTeleport_AramaGuncelle();
        }

        private void RefTeleport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                RefTeleportGuncelle();
            }
            catch { }
        }

        private void RefTeleportGuncelle()
        {
            try
            {
                RefTeleport_Teleport.DataContext = RefTeleport.SelectedItem;
                RefTeleLink.ItemsSource = Definitions.Listenings.Teleport.RefTeleLink.Where((Definitions.TableData.Teleport.RefTeleLink x) => x.OwnerTeleport == ((Definitions.TableData.Teleport.RefTeleport)RefTeleport.SelectedItem).ID);
            }
            catch { }
        }

        private void RefTeleLink_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefTeleport_TeleportLink.DataContext = RefTeleLink.SelectedItem;
        }

        private void RefTeleport_TeleportButton_Click(object sender, RoutedEventArgs e)
        {
            if (RefTeleport_Teleport.DataContext == null)
                return;

            if (((Definitions.TableData.Teleport.RefTeleport)RefTeleport_Teleport.DataContext).ID == 0)
            {
                Definitions.Listenings.Teleport.RefTeleport.First(x => x == RefTeleport_Teleport.DataContext).ID = System.Convert.ToInt32(Definitions.Listenings.SQL.Connection.Insert(RefTeleport_Teleport.DataContext));
            }
            else
            {
                Definitions.Listenings.SQL.Connection.Save(RefTeleport_Teleport.DataContext);
            }

            $"[SQL][Teleport][_RefTeleport] Yapılan değişiklikler başarıyla kaydedildi. ID: {(RefTeleport_Teleport.DataContext as Definitions.TableData.Teleport.RefTeleport)?.ID}".LogToForm();

            RefTeleportGuncelle();
        }

        private void RefTeleLink_TeleportButton_Click(object sender, RoutedEventArgs e)
        {
            if (RefTeleport_TeleportLink.DataContext == null)
                return;

            Definitions.Listenings.SQL.Connection.Save(RefTeleport_TeleportLink.DataContext);

            $"[SQL][Teleport][_RefTeleLink] Yapılan değişiklikler başarıyla kaydedildi. ID: {(RefTeleport_TeleportLink.DataContext as Definitions.TableData.Teleport.RefTeleLink)?.ID}".LogToForm();
        }

        private void RefTeleport_MenuItem_AddClick(object sender, RoutedEventArgs e)
        {
            switch (((MenuItem)sender).Tag.ToString())
            {
                case "RefTeleport_Teleport":
                    var teleport = (Definitions.TableData.Teleport.RefTeleport)Definitions.Listenings.Teleport.RefTeleport[0].Clone();
                    teleport.ID = 0;
                    teleport.CodeName128 = "YeniTeleport_CodeName";
                    Definitions.Listenings.Teleport.RefTeleport.Add(teleport);

                    RefTeleport_AramaGuncelle();
                    break;

                case "RefTeleport_TeleLink":
                    var teleportLink = (Definitions.TableData.Teleport.RefTeleLink)Definitions.Listenings.Teleport.RefTeleLink[1].Clone();
                    teleportLink.ID = 0;
                    teleportLink.OwnerTeleport = ((Definitions.TableData.Teleport.RefTeleport)RefTeleport_Teleport.DataContext).ID;
                    Definitions.Listenings.Teleport.RefTeleLink.Add(teleportLink);

                    RefTeleportGuncelle();
                    break;
            }
        }

        private void RefTeleport_MenuItem_RemoveClick(object sender, RoutedEventArgs e)
        {
            switch (((MenuItem)sender).Tag.ToString())
            {
                case "RefTeleport_Teleport":
                    var teleport = (Definitions.TableData.Teleport.RefTeleport)RefTeleport_Teleport.DataContext;

                    Definitions.Listenings.SQL.Connection.Delete(teleport);
                    Definitions.Listenings.Teleport.RefTeleport.Remove(teleport);
                    $"[SQL][Teleport][_RefTeleport] Teleport silindi. ID: {teleport.ID}".LogToForm();

                    foreach (var _teleportLink in Definitions.Listenings.Teleport.RefTeleLink.Where(x => x.OwnerTeleport == teleport.ID || x.TargetTeleport == teleport.ID).ToList())
                    {
                        Definitions.Listenings.SQL.Connection.Delete(_teleportLink);
                        Definitions.Listenings.Teleport.RefTeleLink.Remove(_teleportLink);

                        $"[SQL][Teleport][_RefTeleLink] Teleport bağlantısı silindi. ID: {_teleportLink.ID}".LogToForm();
                    }

                    RefTeleport_AramaGuncelle();
                    break;

                case "RefTeleport_TeleLink":
                    var teleportLink = (Definitions.TableData.Teleport.RefTeleLink)RefTeleport_TeleportLink.DataContext;

                    Definitions.Listenings.SQL.Connection.Delete(teleportLink);
                    Definitions.Listenings.Teleport.RefTeleLink.Remove(teleportLink);
                    $"[SQL][Teleport][_RefTeleLink] Teleport bağlantısı silindi. ID: {teleportLink.ID}".LogToForm();

                    RefTeleportGuncelle();
                    break;
            }
        }

        private void RefTeleport_GetPositionButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(RefTeleport_Charname.Text))
                return;

            var charInfo = Definitions.Listenings.SQL.Connection.SingleOrDefault<dynamic>("SELECT LatestRegion, PosX, PosY, PosZ, WorldID FROM _Char WHERE CharName16 = @0", RefTeleport_Charname.Text);

            if (charInfo != null)
            {
                var teleportInfo = Definitions.Listenings.Teleport.RefTeleport.SingleOrDefault(x => x == RefTeleport_Teleport.DataContext);

                teleportInfo.GenPos_X = (int)charInfo.PosX;
                teleportInfo.GenPos_Y = (int)charInfo.PosY;
                teleportInfo.GenPos_Z = (int)charInfo.PosZ;
                teleportInfo.GenRegionID = (int)charInfo.LatestRegion;
                teleportInfo.GenWorldID = (int)charInfo.WorldID;

                RefTeleportGuncelle();
            }
            else
            {
                MessageBox.Show("Belirtilen karakter bulunamadı");
            }
        }

        public void RefTeleport_AramaGuncelle()
        {
            try
            {
                if (string.IsNullOrEmpty(RefTeleport_Search.Text))
                {
                    RefTeleport.ItemsSource = Definitions.Listenings.Teleport.RefTeleport.ToList();
                }
                else
                {
                    RefTeleport.ItemsSource = Definitions.Listenings.Teleport.RefTeleport.Where(x =>
                   x.CodeName128.IndexOf(RefTeleport_Search.Text, System.StringComparison.InvariantCultureIgnoreCase) >= 0 || x.AssocRefObjCodeName128.IndexOf(RefTeleport_Search.Text, System.StringComparison.InvariantCultureIgnoreCase) >= 0 || x.ID.ToString() == RefTeleport_Search.Text
                   ).ToList();
                }
            }
            catch { }
        }
    }
}