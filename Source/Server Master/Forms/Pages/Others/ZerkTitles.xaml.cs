using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ServerMaster.Forms.Pages.Others
{
    /// <summary>
    /// Interaction logic for ZerkTitles.xaml
    /// </summary>
    public partial class ZerkTitles : UserControl
    {
        public ZerkTitles()
        {
            InitializeComponent();
        }

        public void ZerkTitleList_AramaGuncelle()
        {
            ZerkTitleList.ItemsSource = Definitions.Listenings.Other.HWANLevels.ToList();
        }

        private void ZerkTitleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ZerkTitle.DataContext = ZerkTitleList.SelectedItem;
        }

        private void SaveZerkTitle_Click(object sender, RoutedEventArgs e)
        {
            Definitions.Listenings.SQL.Connection.Save((Definitions.TableData.Others.RefHWANLevel)ZerkTitle.DataContext);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Definitions.TableData.Others.RefHWANLevel)((Definitions.TableData.Others.RefHWANLevel)ZerkTitleList.SelectedItem)?.Clone();
            selectedItem.HwanLevel = System.Convert.ToInt32(Definitions.Listenings.SQL.Connection.Insert(selectedItem));
            Definitions.Listenings.Other.HWANLevels.Add(selectedItem);

            ZerkTitleList_AramaGuncelle();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Definitions.TableData.Others.RefHWANLevel)ZerkTitleList.SelectedItem;

            Definitions.Listenings.Other.HWANLevels.Remove(selectedItem);
            Definitions.Listenings.SQL.Connection.Delete(selectedItem);

            ZerkTitleList_AramaGuncelle();
        }
    }
}
