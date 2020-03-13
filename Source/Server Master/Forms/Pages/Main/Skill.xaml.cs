using Force.DeepCloner;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ServerMaster.Forms.Pages.Main
{
    /// <summary>
    /// Interaction logic for Skill.xaml
    /// </summary>
    public partial class Skill : UserControl
    {
        public Skill()
        {
            InitializeComponent();
        }

        public void RefSkill_AramaGuncelle()
        {
            try
            {
                if (string.IsNullOrEmpty(RefSkill_Search.Text))
                {
                    RefSkillList.ItemsSource = Definitions.Listenings.RefSkill.OrderBy(x => x.ID).ToList();
                }
                else
                {
                    RefSkillList.ItemsSource = Definitions.Listenings.RefSkill.Where(x =>
                    x.Basic_Code.IndexOf(RefSkill_Search.Text, StringComparison.InvariantCultureIgnoreCase) >= 0 || x.ID.ToString() == RefSkill_Search.Text
                    || x.Media_SkillName.IndexOf(RefSkill_Search.Text, StringComparison.InvariantCultureIgnoreCase) >= 0).OrderBy(x => x.ID).ToList();
                }
            }
            catch { }
        }

        private void RefSkill_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefSkill_AramaGuncelle();
        }

        private void SkillData_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SkillData_GroupBox.DataContext = RefSkillList.SelectedItem;
                RefSkillList_ByGroup.ItemsSource = Definitions.Listenings.RefSkill.Where(x => x.GroupID == (RefSkillList.SelectedItem as Definitions.TableData.Main.RefSkill)?.GroupID).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RefSkillList_ByGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SkillData_GroupIDBox.DataContext = RefSkillList_ByGroup.SelectedItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SaveSkill(object sender, RoutedEventArgs e)
        {
            try
            {
                Definitions.Listenings.SQL.Connection.Save(SkillData_GroupBox.DataContext);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SaveSkillInGroup(object sender, RoutedEventArgs e)
        {
            try
            {
                Definitions.Listenings.SQL.Connection.Save(SkillData_GroupIDBox.DataContext);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SaveAllSkills(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var currentItem in RefSkillList.ItemsSource)
                {
                    Definitions.Listenings.SQL.Connection.Save(currentItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SaveAllSkillsInGroup(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var currentItem in RefSkillList_ByGroup.ItemsSource)
                {
                    Definitions.Listenings.SQL.Connection.Save(currentItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SkillList_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var currentItem in RefSkillList.SelectedItems)
                {
                    var skill = currentItem.DeepClone() as Definitions.TableData.Main.RefSkill;
                    skill.ID = Convert.ToInt32(Definitions.Listenings.SQL.Connection.Insert(skill));

                    Definitions.Listenings.RefSkill.Add(skill);
                }

                RefSkill_AramaGuncelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SkillList_Remove(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var currentItem in RefSkillList.SelectedItems)
                {
                    Definitions.Listenings.SQL.Connection.Delete(currentItem);
                    Definitions.Listenings.RefSkill.Remove((Definitions.TableData.Main.RefSkill)currentItem);
                }

                RefSkill_AramaGuncelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SkillGroupList_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var currentItem in RefSkillList_ByGroup.SelectedItems)
                {
                    var skill = currentItem.DeepClone() as Definitions.TableData.Main.RefSkill;
                    skill.ID = Convert.ToInt32(Definitions.Listenings.SQL.Connection.Insert(skill));

                    Definitions.Listenings.RefSkill.Add(skill);
                }

                RefSkill_AramaGuncelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SkillGroupList_Remove(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var currentItem in RefSkillList_ByGroup.SelectedItems)
                {
                    Definitions.Listenings.SQL.Connection.Delete(currentItem);
                    Definitions.Listenings.RefSkill.Remove((Definitions.TableData.Main.RefSkill)currentItem);
                }

                RefSkill_AramaGuncelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}