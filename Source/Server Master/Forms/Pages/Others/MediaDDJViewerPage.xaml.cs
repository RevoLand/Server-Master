using System.Diagnostics;
using Alphaleonis.Win32.Filesystem;
using System.Linq;
using System.Windows.Controls;

namespace ServerMaster.Forms.Pages.Others
{
    /// <summary>
    /// Interaction logic for MediaDDJViewerPage.xaml
    /// </summary>
    public partial class MediaDDJViewerPage : UserControl
    {
        public MediaDDJViewerPage()
        {
            InitializeComponent();
        }

        private void MediaDDJList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DDJFile.DataContext = MediaDDJList.SelectedItem;
        }

        private void MediaDDJList_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            MediaDDJList_AramaGuncelle();
        }

        public void MediaDDJList_AramaGuncelle()
        {
            if (string.IsNullOrEmpty(MediaDDJList_Search.Text))
            {
                MediaDDJList.ItemsSource = Definitions.Listenings.Other.DDJFiles.ToList();
            }
            else
            {
                MediaDDJList.ItemsSource = Definitions.Listenings.Other.DDJFiles.Where(
                   x => x.FileName.ToLowerInvariant().Contains(MediaDDJList_Search.Text)
                   || x.FullName.ToLowerInvariant().Contains(MediaDDJList_Search.Text)
                   ).ToList();
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var _DDJFile = DDJFile.DataContext as Definitions.TableData.Media.DDJFiles;

            if (Directory.GetParent(_DDJFile.FullName).Exists)
            {
                Process.Start(new ProcessStartInfo()
                {
                    FileName = "explorer",
                    Arguments = $"/e, /select, \"{_DDJFile.FullName}\""
                });
            }
        }
    }
}