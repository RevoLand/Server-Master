using System.Windows.Controls;

namespace ServerMaster.Forms.Pages.Drops
{
    /// <summary>
    /// Interaction logic for RefDropClassSel_Scroll.xaml
    /// </summary>
    public partial class RefDropClassSel_Scroll : UserControl
    {
        public RefDropClassSel_Scroll()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Definitions.Listenings.Drop.RefDropClassSel_Scroll.ForEach(x => Definitions.Listenings.SQL.Connection.Save(x));
        }
    }
}