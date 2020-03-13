using System.Windows.Controls;

namespace ServerMaster.Forms.Pages.Drops
{
    /// <summary>
    /// Interaction logic for RefDropOptLvlSel.xaml
    /// </summary>
    public partial class RefDropOptLvlSel : UserControl
    {
        public RefDropOptLvlSel()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Definitions.Listenings.Drop.RefDropOptLvlSel.ForEach(x => Definitions.Listenings.SQL.Connection.Save(x));
        }
    }
}