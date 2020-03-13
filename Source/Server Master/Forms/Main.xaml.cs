using System.Linq;
using System.Windows;

namespace ServerMaster.Forms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Main
    {
        public static Framework.AsyncObservableCollection<string> ProgramLogs = new Framework.AsyncObservableCollection<string>();

        public Main()
        {
            InitializeComponent();

            Functions.Program.OnLoaded();

            Settings.programLogsBox.ItemsSource = ProgramLogs;

            UpdateItemSources();
        }

        private void UpdateItemSources()
        {
            try
            {
                // _RefObjCommon
                RefObjCommon_MobsAndPets.RefObjCommon_Mob_AramaGuncelle();
                RefObjCommon_Item.RefObjCommon_Item_AramaGuncelle();
                RefObjCommon_Structure.RefObjCommon_Structure_AramaGuncelle();

                // Skill data
                SkillData.RefSkill_AramaGuncelle();

                // NPC
                NPC.NPCListesi_AramaGuncelle();

                // Others
                RefTeleportPage.RefTeleport_AramaGuncelle();
                MediaDDJViewerPage.MediaDDJList_AramaGuncelle();
                AlchemyRatesPage.AlchemyItemList_Guncelle();
                ZerkTitlesPage.ZerkTitleList_AramaGuncelle();

                // Drops
                RefDropClassSel_Equip.DropList.ItemsSource = Definitions.Listenings.Drop.RefDropClassSel_Equip;
                RefDropClassSel_RareEquip.DropList.ItemsSource = Definitions.Listenings.Drop.RefDropClassSel_RareEquip;

                RefDropClassSel_Alchemy_ATTRStone.DropList.ItemsSource = Definitions.Listenings.Drop.RefDropClassSel_Alchemy_ATTRStone;
                RefDropClassSel_Alchemy_MagicStone.DropList.ItemsSource = Definitions.Listenings.Drop.RefDropClassSel_Alchemy_MagicStone;
                RefDropClassSel_Alchemy_Tablet.DropList.ItemsSource = Definitions.Listenings.Drop.RefDropClassSel_Alchemy_Tablet;

                RefDropClassSel_Ammo.DropList.ItemsSource = Definitions.Listenings.Drop.RefDropClassSel_Ammo;
                RefDropClassSel_Cure.DropList.ItemsSource = Definitions.Listenings.Drop.RefDropClassSel_Cure;
                RefDropClassSel_Recover.DropList.ItemsSource = Definitions.Listenings.Drop.RefDropClassSel_Recover;
                RefDropClassSel_Reinforce.DropList.ItemsSource = Definitions.Listenings.Drop.RefDropClassSel_Reinforce;
                RefDropClassSel_Scroll.DropList.ItemsSource = Definitions.Listenings.Drop.RefDropClassSel_Scroll;

                RefDropGold.DropList.ItemsSource = Definitions.Listenings.Drop.RefDropGold;
                RefDropOptLvlSel.DropList.ItemsSource = Definitions.Listenings.Drop.RefDropOptLvlSel;

                RefDropItem.DropItemListeGuncelle();

                RefMonster_AssignedItemDrop.Monster_AssignedDropList_Guncelle();

                RefMonster_AssignedItemRndDrop.Monster_AssignedRndDropList_Guncelle();

                // Map vieweer
                //MapViewerPage.IngameMap.ItemsSource = Definitions.Listenings.Media.MapFiles.Where(x => x.X < 175).OrderByDescending(x => x.Y).ThenBy(x => x.X);
            }
            catch { }
        }

        private void Generator_Convert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var _content in Generator_Input.Text.Split('\n'))
                {
                    if (string.IsNullOrEmpty(_content))
                        continue;

                    var content = _content.Replace("\r", "");

                    Generator_Output.Text += "<Label Content=\"" + content.Replace("_", "__") + ":\" VerticalAlignment=\"Top\" />\n<TextBox Text=\"{Binding " + content + "}\" VerticalAlignment=\"Top\" HorizontalAlignment=\"Left\" MinHeight=\"25\" MinWidth=\"256\" />\n";
                }
            }
            catch { }
        }
    }
}