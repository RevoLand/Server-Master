using System.Windows.Controls;

namespace ServerMaster.Forms.Pages.Drops
{
    /// <summary>
    /// Interaction logic for RefDropGold.xaml
    /// </summary>
    public partial class RefDropGold : UserControl
    {
        public RefDropGold()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Definitions.Listenings.Drop.RefDropGold.ForEach(x => Definitions.Listenings.SQL.Connection.Save(x));
        }
    }
}