using System.Windows.Controls;

namespace ServerMaster.Forms.Pages.Drops
{
    /// <summary>
    /// Interaction logic for RefDropClassSel_Reinforce.xaml
    /// </summary>
    public partial class RefDropClassSel_Reinforce : UserControl
    {
        public RefDropClassSel_Reinforce()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Definitions.Listenings.Drop.RefDropClassSel_Reinforce.ForEach(x => Definitions.Listenings.SQL.Connection.Save(x));
        }
    }
}