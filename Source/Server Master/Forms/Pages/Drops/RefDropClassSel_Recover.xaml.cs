using System.Windows.Controls;

namespace ServerMaster.Forms.Pages.Drops
{
    /// <summary>
    /// Interaction logic for RefDropClassSel_Recover.xaml
    /// </summary>
    public partial class RefDropClassSel_Recover : UserControl
    {
        public RefDropClassSel_Recover()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Definitions.Listenings.Drop.RefDropClassSel_Recover.ForEach(x => Definitions.Listenings.SQL.Connection.Save(x));
        }
    }
}