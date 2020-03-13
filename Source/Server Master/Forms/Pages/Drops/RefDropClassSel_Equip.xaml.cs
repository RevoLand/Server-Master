using System.Windows.Controls;

namespace ServerMaster.Forms.Pages.Drops
{
    /// <summary>
    /// Interaction logic for RefDropClassSel_Equip.xaml
    /// </summary>
    public partial class RefDropClassSel_Equip : UserControl
    {
        public RefDropClassSel_Equip()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Definitions.Listenings.Drop.RefDropClassSel_Equip.ForEach(x => Definitions.Listenings.SQL.Connection.Save(x));
        }
    }
}