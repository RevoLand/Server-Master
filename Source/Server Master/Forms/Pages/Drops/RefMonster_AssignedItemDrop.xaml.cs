using System.Linq;
using System.Windows.Controls;

namespace ServerMaster.Forms.Pages.Drops
{
    /// <summary>
    /// Interaction logic for RefDropItem.xaml
    /// </summary>
    public partial class RefMonster_AssignedItemDrop : UserControl
    {
        public RefMonster_AssignedItemDrop()
        {
            InitializeComponent();
        }

        public void Monster_AssignedDropList_SameMobs_Guncelle()
        {
            try
            {
                var selectedItem = Monster_AssignedDropList.SelectedItem as Definitions.TableData.Drops.Monster_AssignedItemDrop;

                if (selectedItem == null)
                {
                    return;
                }

                Monster_AssignedDrop.DataContext = selectedItem;

                Monster_AssignedDropList_SameMobs.ItemsSource = Definitions.Listenings.Drop.Monster_AssignedItemDrop.Where(x => x.RefMonsterID == selectedItem.RefMonsterID).ToList();
            }
            catch { }
        }

        public void Monster_AssignedDropList_Guncelle()
        {
            try
            {
                Monster_AssignedDropList.ItemsSource = SearchIn.Text?.Length == 0 ? Definitions.Listenings.Drop.Monster_AssignedItemDrop.ToList() : Definitions.Listenings.Drop.Monster_AssignedItemDrop.Where(x => x.RefMonsterCodeName.IndexOf(SearchIn.Text, System.StringComparison.InvariantCultureIgnoreCase) >= 0).ToList();
            }
            catch { }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Monster_AssignedDropList_Guncelle();
        }

        private void ContextMenuAdd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            switch (((MenuItem)sender).Tag.ToString())
            {
                case "Monster_AssignedDropList":
                    var assignedDrop = (Definitions.TableData.Drops.Monster_AssignedItemDrop)Definitions.Listenings.Drop.Monster_AssignedItemDrop[0].Clone();
                    assignedDrop.ID = 0;
                    assignedDrop.RefMonsterID = 1933;
                    assignedDrop.RefItemID = 1;
                    assignedDrop.ID = System.Convert.ToInt32(Definitions.Listenings.SQL.Connection.Insert(assignedDrop));
                    Definitions.Listenings.Drop.Monster_AssignedItemDrop.Add(assignedDrop);

                    Monster_AssignedDropList_Guncelle();
                    break;

                case "Monster_AssignedDropList_SameMobs":
                    var assignedItemDrop = ((Definitions.TableData.Drops.Monster_AssignedItemDrop)((Definitions.TableData.Drops.Monster_AssignedItemDrop)Monster_AssignedDropList_SameMobs.SelectedItem).Clone());
                    assignedItemDrop.ID = 0;
                    assignedItemDrop.RefItemID = 1;
                    assignedItemDrop.ID = System.Convert.ToInt32(Definitions.Listenings.SQL.Connection.Insert(assignedItemDrop));
                    Definitions.Listenings.Drop.Monster_AssignedItemDrop.Add(assignedItemDrop);

                    Monster_AssignedDropList_SameMobs_Guncelle();
                    break;
            }
        }

        private void ContextMenuRemove_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            switch (((MenuItem)sender).Tag.ToString())
            {
                case "Monster_AssignedDropList":
                    var assignedDrop = Monster_AssignedDropList.SelectedItem as Definitions.TableData.Drops.Monster_AssignedItemDrop;

                    Definitions.Listenings.SQL.Connection.Delete(assignedDrop);
                    Definitions.Listenings.Drop.Monster_AssignedItemDrop.Remove(assignedDrop);

                    Monster_AssignedDropList_Guncelle();
                    break;

                case "Monster_AssignedDropList_SameMobs":
                    var assignedDropItem = Monster_AssignedDropList_SameMobs.SelectedItem as Definitions.TableData.Drops.Monster_AssignedItemDrop;
                    Definitions.Listenings.SQL.Connection.Delete(assignedDropItem);
                    Definitions.Listenings.Drop.Monster_AssignedItemDrop.Remove(assignedDropItem);

                    Monster_AssignedDropList_SameMobs_Guncelle();
                    break;
            }
        }

        private void RefDropItemAssign_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Definitions.Listenings.SQL.Connection.Save(Monster_AssignedDrop_SameMobs.DataContext);
            $"[_RefMonster_AssignedItemDrop] Saved drop: {(Monster_AssignedDrop_SameMobs.DataContext as Definitions.TableData.Drops.Monster_AssignedItemDrop)?.RefMonsterCodeName} to database".LogToForm();
        }

        private void RefDropItemAssign_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Monster_AssignedDrop_SameMobs.DataContext = Monster_AssignedDropList_SameMobs.SelectedItem;
        }

        private void RefDropItemGroup_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Definitions.Listenings.SQL.Connection.Save(Monster_AssignedDrop.DataContext);
            $"[_RefMonster_AssignedItemDrop] Saved drop: {(Monster_AssignedDrop.DataContext as Definitions.TableData.Drops.Monster_AssignedItemDrop)?.RefMonsterCodeName} to database".LogToForm();
        }

        private void RefDropItemGroup_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Monster_AssignedDropList_SameMobs_Guncelle();
        }
    }
}