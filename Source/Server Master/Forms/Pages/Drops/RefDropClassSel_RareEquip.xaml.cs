using System.Windows.Controls;

namespace ServerMaster.Forms.Pages.Drops
{
    /// <summary>
    /// Interaction logic for RefDropClassSel_RareEquip.xaml
    /// </summary>
    public partial class RefDropClassSel_RareEquip : UserControl
    {
        public RefDropClassSel_RareEquip()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Definitions.Listenings.Drop.RefDropClassSel_RareEquip.ForEach(x => Definitions.Listenings.SQL.Connection.Save(x));
        }
    }
}