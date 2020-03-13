using System.Linq;
using System.Windows.Controls;

namespace ServerMaster.Forms.Pages.Drops
{
    /// <summary>
    /// Interaction logic for RefDropItem.xaml
    /// </summary>
    public partial class RefMonster_AssignedItemRndDrop : UserControl
    {
        public RefMonster_AssignedItemRndDrop()
        {
            InitializeComponent();
        }

        public void Monster_AssignedDropList_SameMobs_Guncelle()
        {
            try
            {
                var selectedItem = Monster_AssignedRndDropList.SelectedItem as Definitions.TableData.Drops.Monster_AssignedItemRndDrop;

                if (selectedItem == null)
                {
                    return;
                }

                Monster_AssignedRndDrop.DataContext = selectedItem;

                Monster_AssignedRndDropList_SameMobs.ItemsSource = Definitions.Listenings.Drop.Monster_AssignedItemRndDrop.Where(x => x.RefMonsterID == selectedItem.RefMonsterID).ToList();
            }
            catch { }
        }

        public void Monster_AssignedRndDropList_Guncelle()
        {
            try
            {
                Monster_AssignedRndDropList.ItemsSource = SearchIn.Text?.Length == 0 ? Definitions.Listenings.Drop.Monster_AssignedItemRndDrop.ToList() : Definitions.Listenings.Drop.Monster_AssignedItemRndDrop.Where(x => x.RefMonsterCodeName.IndexOf(SearchIn.Text, System.StringComparison.InvariantCultureIgnoreCase) >= 0).ToList();
            }
            catch { }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Monster_AssignedRndDropList_Guncelle();
        }

        private void ContextMenuAdd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            switch (((MenuItem)sender).Tag.ToString())
            {
                case "Monster_AssignedDropList":
                    var assignedDrop = (Definitions.TableData.Drops.Monster_AssignedItemRndDrop)Definitions.Listenings.Drop.Monster_AssignedItemRndDrop[0].Clone();
                    assignedDrop.ID = 0;
                    assignedDrop.RefMonsterID = 1933;
                    assignedDrop.RefItemGroupID = 1;
                    assignedDrop.ID = System.Convert.ToInt32(Definitions.Listenings.SQL.Connection.Insert(assignedDrop));
                    Definitions.Listenings.Drop.Monster_AssignedItemRndDrop.Add(assignedDrop);

                    Monster_AssignedRndDropList_Guncelle();
                    break;

                case "Monster_AssignedDropList_SameMobs":
                    var assignedItemDrop = ((Definitions.TableData.Drops.Monster_AssignedItemRndDrop)((Definitions.TableData.Drops.Monster_AssignedItemRndDrop)Monster_AssignedRndDropList_SameMobs.SelectedItem).Clone());
                    assignedItemDrop.ID = 0;
                    assignedItemDrop.RefItemGroupID = 1;
                    assignedItemDrop.ID = System.Convert.ToInt32(Definitions.Listenings.SQL.Connection.Insert(assignedItemDrop));
                    Definitions.Listenings.Drop.Monster_AssignedItemRndDrop.Add(assignedItemDrop);

                    Monster_AssignedDropList_SameMobs_Guncelle();
                    break;
            }
        }

        private void ContextMenuRemove_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            switch (((MenuItem)sender).Tag.ToString())
            {
                case "Monster_AssignedDropList":
                    var assignedDrop = Monster_AssignedRndDropList.SelectedItem as Definitions.TableData.Drops.Monster_AssignedItemRndDrop;

                    Definitions.Listenings.SQL.Connection.Delete(assignedDrop);
                    Definitions.Listenings.Drop.Monster_AssignedItemRndDrop.Remove(assignedDrop);

                    Monster_AssignedRndDropList_Guncelle();
                    break;

                case "Monster_AssignedDropList_SameMobs":
                    var assignedDropItem = Monster_AssignedRndDropList_SameMobs.SelectedItem as Definitions.TableData.Drops.Monster_AssignedItemRndDrop;
                    Definitions.Listenings.SQL.Connection.Delete(assignedDropItem);
                    Definitions.Listenings.Drop.Monster_AssignedItemRndDrop.Remove(assignedDropItem);

                    Monster_AssignedDropList_SameMobs_Guncelle();
                    break;
            }
        }

        private void RefDropItemAssign_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Definitions.Listenings.SQL.Connection.Save(Monster_AssignedDrop_SameMobs.DataContext);
            $"[_RefMonster_AssignedItemRndDrop] Saved drop: {(Monster_AssignedDrop_SameMobs.DataContext as Definitions.TableData.Drops.Monster_AssignedItemRndDrop)?.RefMonsterCodeName} to database".LogToForm();
        }

        private void RefDropItemAssign_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Monster_AssignedDrop_SameMobs.DataContext = Monster_AssignedRndDropList_SameMobs.SelectedItem;
        }

        private void RefDropItemGroup_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Definitions.Listenings.SQL.Connection.Save(Monster_AssignedRndDrop.DataContext);
            $"[_RefMonster_AssignedItemRndDrop] Saved drop: {(Monster_AssignedRndDrop.DataContext as Definitions.TableData.Drops.Monster_AssignedItemRndDrop)?.RefMonsterCodeName} to database".LogToForm();
        }

        private void RefDropItemGroup_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Monster_AssignedDropList_SameMobs_Guncelle();
        }
    }
}