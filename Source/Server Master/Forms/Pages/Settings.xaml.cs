using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace ServerMaster.Forms.Pages
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void ClientDegistir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var clientSelector = new OpenFileDialog()
                {
                    Filter = "Silkroad Client(sro_client.exe)|sro_client.exe"
                };

                if (clientSelector.ShowDialog() == true)
                {
                    Properties.Settings.Default.clientDirectory = System.IO.Path.GetDirectoryName(clientSelector.FileName);
                }
            }
            catch { }
        }

        private void MediaPK2_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Functions.Media.Common.SavePK2Lines();
            }
            catch { }
        }

        private void OutputDirectory_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Definitions.Directories.ServerMaster.MedyaDizini.FullName);
            }
            catch { }
        }
    }
}