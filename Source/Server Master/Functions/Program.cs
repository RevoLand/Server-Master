using Alphaleonis.Win32.Filesystem;
using Microsoft.Win32;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace ServerMaster.Functions
{
    internal static class Program
    {
        [MethodTimer.Time]
        public static void OnLoaded()
        {
            try
            {
                UpdateCulture();

                UpdateClientDirectory();

                LoadClientDataAsync();

                LoadTables();
            }
            catch { }
        }

        private static void UpdateCulture()
        {
            try
            {
                var customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
                customCulture.NumberFormat.NumberDecimalSeparator = ".";

                System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            }
            catch { }
        }

        public static async void LoadClientDataAsync()
        {
            try
            {
                Media.TextData.ParseTextUISystemFile("textdataname.txt");
                Media.TextData.ParseTextUISystemFile("textuisystem.txt");

                await Task.Run(Media.Image.LoadDdjFiles).ConfigureAwait(false);
            }
            catch { }
        }

        public static void LoadTables()
        {
            try
            {
                #region Main / _RefObjCommon - _RefObjChar - _RefObjItem - _RefObjStruct - _RefSkill

                Tables.Main.LoadObjCommonTable();
                Tables.Main.LoadObjCharTable();
                Tables.Main.LoadObjItemTable();
                Tables.Main.LoadObjStructTable();
                Tables.Main.LoadRefSkillTable();

                #endregion Main / _RefObjCommon - _RefObjChar - _RefObjItem - _RefObjStruct - _RefSkill

                #region Drop related tables

                Tables.Drop.LoadMonster_AssignedItemDrop();
                Tables.Drop.LoadMonster_AssignedItemRndDrop();

                Tables.Drop.LoadRefDropClassSel_Alchemy_ATTRStone();
                Tables.Drop.LoadRefDropClassSel_Alchemy_MagicStone();
                Tables.Drop.LoadRefDropClassSel_Alchemy_Tablet();

                Tables.Drop.LoadRefDropClassSel_Ammo();
                Tables.Drop.LoadRefDropClassSel_Cure();
                Tables.Drop.LoadRefDropClassSel_Equip();
                Tables.Drop.LoadRefDropClassSel_RareEquip();
                Tables.Drop.LoadRefDropClassSel_Recover();
                Tables.Drop.LoadRefDropClassSel_Reinforce();
                Tables.Drop.LoadRefDropClassSel_Scroll();

                Tables.Drop.LoadRefDropGold();
                Tables.Drop.LoadRefDropItemAssign();
                Tables.Drop.LoadRefDropItemGroup();
                Tables.Drop.LoadRefDropOptLvlSel();

                #endregion Drop related tables

                #region Teleport

                Tables.Teleport.LoadRefTeleportTable();
                Tables.Teleport.LoadRefTeleLinkTable();

                #endregion Teleport

                #region NPC

                Tables.NPC.LoadRefShopTable();
                Tables.NPC.LoadRefShopGroupTable();
                Tables.NPC.LoadRefShopItemGroupTable();
                Tables.NPC.LoadRefShopTabTable();
                Tables.NPC.LoadRefShopTabGroupTable();
                Tables.NPC.LoadRefMappingShopGroupTable();
                Tables.NPC.LoadRefMappingShopWithTabTable();

                Tables.NPC.LoadRefShopGoodsTable();
                Tables.NPC.LoadRefPackageItemTable();
                Tables.NPC.LoadRefScrapOfPackageItemTable();
                Tables.NPC.LoadRefPricePolicyOfItemTable();

                #endregion NPC

                // Map viweer
                //Tables.Other.LoadMapViewerLines();

                // Others
                Tables.Other.LoadHwanLines();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void UpdateClientDirectory()
        {
            try
            {
                if (string.IsNullOrEmpty(Properties.Settings.Default.clientDirectory) || !Directory.Exists(Properties.Settings.Default.clientDirectory))
                {
                    var selectClientPath = MessageBox.Show("Client seçimi yapılmadı. Programın düzgün bir şekilde çalışabilmesi için clientin seçilmesi gerekiyor.\n Şimdi seçim yapmak ister misiniz?", "Client bulunamadı", MessageBoxButton.YesNo);

                    if (selectClientPath == MessageBoxResult.Yes)
                    {
                        var clientSelector = new OpenFileDialog
                        {
                            Filter = "Silkroad Client(sro_client.exe)|sro_client.exe"
                        };

                        if (clientSelector.ShowDialog() == true)
                        {
                            Properties.Settings.Default.clientDirectory = Path.GetDirectoryName(clientSelector.FileName);
                            Definitions.Directories.Client.MediaPK2 = new FileInfo(Path.Combine(Path.GetDirectoryName(clientSelector.FileName), "Media.pk2"));
                        }
                    }
                }
                else
                {
                    if (!File.Exists(Path.Combine(Properties.Settings.Default.clientDirectory, "Media.pk2")))
                    {
                        var selectPK2 = MessageBox.Show("Belirtmiş olduğunuz client dizininde Media.pk2 bulunamadı. Programın düzgün bir şekilde çalışabilmesi için Media.pk2 dosyasına ihtiyacı var.\n Media.pk2 dosyasının yerini göstermek ister misiniz?", "Media.pk2 bulunamadı", MessageBoxButton.YesNo);

                        if (selectPK2 == MessageBoxResult.Yes)
                        {
                            new OpenFileDialog().Filter = "Silkroad Client Media File (Media.pk2)|media.pk2";

                            if (new OpenFileDialog().ShowDialog() == true)
                                Definitions.Directories.Client.MediaPK2 = new FileInfo(new OpenFileDialog().FileName);
                        }
                    }
                    else
                    {
                        Definitions.Directories.Client.MediaPK2 = new FileInfo(Path.Combine(Properties.Settings.Default.clientDirectory, "Media.pk2"));
                    }
                }

                // Set Client Paths
                Definitions.Directories.Client.ServerDep = new DirectoryInfo(Path.Combine(Properties.Settings.Default.clientDirectory, "Media", "server_dep"));
                Definitions.Directories.Client.Media = new DirectoryInfo(Path.Combine(Properties.Settings.Default.clientDirectory, "Media"));
                Definitions.Directories.Client.Icon = new DirectoryInfo(Path.Combine(Properties.Settings.Default.clientDirectory, "Media", "icon"));

                // Open PK2 Reader
                Definitions.Listenings.Media.PK2 = new Framework.PK2Reader.Reader(Definitions.Directories.Client.MediaPK2.FullName, "169841");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}