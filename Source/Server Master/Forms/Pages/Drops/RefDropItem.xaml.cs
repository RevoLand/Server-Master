using System.Linq;
using System.Windows.Controls;

namespace ServerMaster.Forms.Pages.Drops
{
    /// <summary>
    /// Interaction logic for RefDropItem.xaml
    /// </summary>
    public partial class RefDropItem : UserControl
    {
        public RefDropItem()
        {
            InitializeComponent();
        }

        private void RefDropItemGroup_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DropItemAssignGuncelle();
        }

        public void DropItemListeGuncelle()
        {
            RefDropItemGroup_List.ItemsSource = Definitions.Listenings.Drop.RefDropItemGroup.ToList();
        }

        public void DropItemAssignGuncelle()
        {
            var selectedItem = RefDropItemGroup_List.SelectedItem as Definitions.TableData.Drops.RefDropItemGroup;
            RefDropItemGroup.DataContext = selectedItem;

            RefDropItemAssign_List.ItemsSource = Definitions.Listenings.Drop.RefDropItemAssign.Where(x => x.AssignedGroup == selectedItem.RefItemGroupID).ToList();
        }

        private void RefDropItemAssign_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefDropItemAssign.DataContext = RefDropItemAssign_List.SelectedItem;
        }

        private void RefDropItemGroup_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Definitions.Listenings.SQL.Connection.Save(RefDropItemGroup.DataContext);
            $"[_RefDropItemGroup] Saved Group: {(RefDropItemGroup.DataContext as Definitions.TableData.Drops.RefDropItemGroup)?.CodeName128} to database".LogToForm();
        }

        private void RefDropItemAssign_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Definitions.Listenings.SQL.Connection.Save(RefDropItemAssign.DataContext);
            $"[_RefDropItemAssign] Saved Group: {(RefDropItemAssign.DataContext as Definitions.TableData.Drops.RefDropItemAssign)?.CodeName128} to database".LogToForm();
        }

        private void ContextMenuAdd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            switch (((MenuItem)sender).Tag.ToString())
            {
                case "DropItemGroup":
                    var itemGroup = (Definitions.TableData.Drops.RefDropItemGroup)Definitions.Listenings.Drop.RefDropItemGroup[0].Clone();
                    itemGroup.ID = 0;
                    itemGroup.CodeName128 = "YeniItemGroup_CodeName";
                    itemGroup.RefItemGroupID = 0;
                    itemGroup.RefItemID = 0;
                    itemGroup.ID = System.Convert.ToInt32(Definitions.Listenings.SQL.Connection.Insert(itemGroup));
                    Definitions.Listenings.Drop.RefDropItemGroup.Add(itemGroup);

                    DropItemListeGuncelle();
                    break;

                case "DropItemAssign":
                    var itemAssign = (Definitions.TableData.Drops.RefDropItemAssign)Definitions.Listenings.Drop.RefDropItemAssign[0].Clone();
                    itemAssign.AssignedGroup = (RefDropItemGroup_List.SelectedItem as Definitions.TableData.Drops.RefDropItemGroup)?.RefItemGroupID ?? 0;
                    itemAssign.ID = System.Convert.ToInt32(Definitions.Listenings.SQL.Connection.Insert(itemAssign));
                    Definitions.Listenings.Drop.RefDropItemAssign.Add(itemAssign);

                    DropItemAssignGuncelle();
                    break;
            }
        }

        private void ContextMenuRemove_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            switch (((MenuItem)sender).Tag.ToString())
            {
                case "DropItemGroup":
                    var itemGroup = RefDropItemGroup_List.SelectedItem as Definitions.TableData.Drops.RefDropItemGroup;

                    Definitions.Listenings.Drop.RefDropItemAssign.Where(x => x.AssignedGroup == itemGroup.RefItemGroupID).ToList().ForEach(x => Definitions.Listenings.SQL.Connection.Delete(x));
                    Definitions.Listenings.SQL.Connection.Delete(itemGroup);
                    Definitions.Listenings.Drop.RefDropItemGroup.Remove(itemGroup);

                    DropItemListeGuncelle();
                    break;

                case "DropItemAssign":
                    var itemAssign = RefDropItemAssign_List.SelectedItem as Definitions.TableData.Drops.RefDropItemAssign;
                    Definitions.Listenings.SQL.Connection.Delete(itemAssign);
                    Definitions.Listenings.Drop.RefDropItemAssign.Remove(itemAssign);

                    DropItemAssignGuncelle();
                    break;
            }
        }
    }
}