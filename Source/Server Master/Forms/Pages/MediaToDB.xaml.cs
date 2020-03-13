using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ServerMaster.Forms.Pages
{
    /// <summary>
    /// Interaction logic for MediaToDB.xaml
    /// </summary>
    public partial class MediaToDB : UserControl
    {
        public MediaToDB()
        {
            InitializeComponent();
        }

        private void MediaLines_FileSelector_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var fileDialog = new OpenFileDialog()
                {
                    Multiselect = true,
                    Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
                };

                if (fileDialog.ShowDialog() == false)
                {
                    return;
                }

                switch (MediaLines_FileSelector_Type.SelectedValue)
                {
                    // Itemdata
                    default:
                        Functions.Media.DataParser.ParseItemdata(fileDialog.FileNames);
                        break;

                    case "Character data":

                        break;

                    case "Skill data":

                        break;
                }

                MediaLines.ItemsSource = Definitions.Listenings.Media.ObjCommon.OrderByDescending(x => x.Service);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public void MediaLines_ListeGuncelle()
        {
            MediaLines.ItemsSource = Definitions.Listenings.Media.ObjCommon;
        }

        private void MediaLines_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            MediaLine.DataContext = from _ObjCommon in Definitions.Listenings.Media.ObjCommon
                                    where _ObjCommon == MediaLines.SelectedItem
                                    join _ObjItem in Definitions.Listenings.Media.ObjItem on _ObjCommon.Link equals _ObjItem.ID
                                    select new { _ObjCommon, _ObjItem };
        }

        private void SaveToDB_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (MediaLine.DataContext != null)
            {
                dynamic mediaLine = MediaLine.DataContext;
                AddToDB(mediaLine._ObjCommon, mediaLine._ObjItem);
            }
        }

        private void AddToDB(Definitions.TableData.Main.RefObjCommon ObjCommon, Definitions.TableData.Main.RefObjItem ObjItem)
        {
            try
            {
                if (Definitions.Listenings.RefObjCommon.ObjCommon.Count(x => x.CodeName128 == ObjCommon.CodeName128) > 0)
                {
                    Debug.WriteLine("Item already exists in current database: " + ObjCommon.CodeName128);
                    return;
                }

                Definitions.Listenings.Media.ObjCommon.Remove(ObjCommon);
                Definitions.Listenings.Media.ObjItem.Remove(ObjItem);

                ObjCommon.Link = Convert.ToInt32(Definitions.Listenings.SQL.Connection.Insert(ObjItem));
                ObjCommon.ID = Convert.ToInt32(Definitions.Listenings.SQL.Connection.Insert(ObjCommon));

                Definitions.Listenings.RefObjCommon.ObjCommon.Add(ObjCommon);
                Definitions.Listenings.RefObjCommon.ObjItem.Add(ObjItem);

                $"[Database][_RefObjCommon & _RefObjItem] Adding item: {ObjCommon.CodeName128}".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Debug.WriteLine(ex);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            foreach (var selectedItem in MediaLines.SelectedItems)
            {
                dynamic objCommon = selectedItem;
                var objItem = Definitions.Listenings.Media.ObjItem.Find(x => x.ID == objCommon.Link);

                AddToDB(objCommon, objItem);
            }
        }

        private void MediaLines_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Definitions.Listenings.Media.ObjCommon.Clear();
            Definitions.Listenings.Media.ObjItem.Clear();

            MediaLines_ListeGuncelle();
        }
    }
}