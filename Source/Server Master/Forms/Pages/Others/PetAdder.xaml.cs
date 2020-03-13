using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ServerMaster.Forms.Pages.Others
{
    /// <summary>
    /// Interaction logic for PetAdder.xaml
    /// </summary>
    public partial class PetAdder : UserControl
    {
        public PetAdder()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var _CodeName128 = CodeName128.Text;
            var _NameStrID = NameStrID.Text;
            var _AssocFileObj128 = AssocFileObj128.Text;
            var _AssocFileIcon128 = AssocFileIcon128.Text;
            var _AssocFile1_128 = AssocFile1_128.Text;

            foreach (var objCommon in Definitions.Listenings.RefObjCommon.ObjCommon.Where(x => x.CodeName128.StartsWith("COS_P_WOLF_")).Take(140).ToList())
            {
                var _newObjCommon = objCommon.Clone() as Definitions.TableData.Main.RefObjCommon;
                var _newObjChar = Definitions.Listenings.RefObjCommon.ObjChar.Find(x => x.ID == objCommon.Link).Clone() as Definitions.TableData.Main.RefObjChar;

                _newObjChar.CanBeVehicle = CanBeVehicle.Text.ParseEnum<Definitions.Enums.RefObjChar.CanBeVehicle>();

                _newObjCommon.Link = System.Convert.ToInt32(Definitions.Listenings.SQL.Connection.Insert(_newObjChar));
                _newObjCommon.CodeName128 = _newObjCommon.CodeName128.Replace("COS_P_WOLF", _CodeName128);
                _newObjCommon.NameStrID128 = _NameStrID;
                _newObjCommon.DescStrID128 = (_newObjCommon.DescStrID128 != "xxx") ? _newObjCommon.DescStrID128.Replace("COS_P_WOLF", _CodeName128) : "xxx";
                _newObjCommon.AssocFileObj128 = _AssocFileObj128;
                _newObjCommon.AssocFileIcon128 = _AssocFileIcon128;
                _newObjCommon.AssocFile1_128 = _AssocFile1_128;
                _newObjCommon.ID = System.Convert.ToInt32(Definitions.Listenings.SQL.Connection.Insert(_newObjCommon));

                Definitions.Listenings.RefObjCommon.ObjCommon.Add(_newObjCommon);
                Definitions.Listenings.RefObjCommon.ObjChar.Add(_newObjChar);
            }

            MessageBox.Show("Eklendi: " + _CodeName128);
        }
    }
}
