using System.Windows.Controls;

namespace ServerMaster.Forms.Pages.Drops
{
    /// <summary>
    /// Interaction logic for RefDropClassSel_Cure.xaml
    /// </summary>
    public partial class RefDropClassSel_Cure : UserControl
    {
        public RefDropClassSel_Cure()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Definitions.Listenings.Drop.RefDropClassSel_Cure.ForEach(x => Definitions.Listenings.SQL.Connection.Save(x));
        }
    }
}