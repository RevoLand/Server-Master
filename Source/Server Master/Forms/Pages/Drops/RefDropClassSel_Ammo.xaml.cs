using System.Windows.Controls;

namespace ServerMaster.Forms.Pages.Drops
{
    /// <summary>
    /// Interaction logic for RefDropClassSel_Ammo.xaml
    /// </summary>
    public partial class RefDropClassSel_Ammo : UserControl
    {
        public RefDropClassSel_Ammo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Definitions.Listenings.Drop.RefDropClassSel_Ammo.ForEach(x => Definitions.Listenings.SQL.Connection.Save(x));
        }
    }
}