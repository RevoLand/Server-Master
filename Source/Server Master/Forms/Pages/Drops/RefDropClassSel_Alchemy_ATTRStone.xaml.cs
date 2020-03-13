using System.Windows.Controls;

namespace ServerMaster.Forms.Pages.Drops
{
    /// <summary>
    /// Interaction logic for RefDropClassSel_Alchemy_ATTRStone.xaml
    /// </summary>
    public partial class RefDropClassSel_Alchemy_ATTRStone : UserControl
    {
        public RefDropClassSel_Alchemy_ATTRStone()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Definitions.Listenings.Drop.RefDropClassSel_Alchemy_ATTRStone.ForEach(x => Definitions.Listenings.SQL.Connection.Save(x));
        }
    }
}