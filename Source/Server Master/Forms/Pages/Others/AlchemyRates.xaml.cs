using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ServerMaster.Forms.Pages.Others
{
    /// <summary>
    /// Interaction logic for AlchemyRates.xaml
    /// </summary>
    public partial class AlchemyRates : UserControl
    {
        public AlchemyRates()
        {
            InitializeComponent();
        }

        private void AlchemyItemList_RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            AlchemyItemList_Guncelle();
        }

        public void AlchemyItemList_Guncelle()
        {
            AlchemyItemList.ItemsSource = Definitions.Listenings.RefObjCommon.ObjCommon.Where(x =>
            x.TypeID1 == Definitions.Enums.RefObjCommon.TypeID1.Item
            && x.TypeID2 == 3
            && x.TypeID3 == 10
            && (x.TypeID4 == 1 || x.TypeID4 == 2)
            ).ToList();
        }

        private void AlchemyItemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAlchemyRates();
        }

        private void UpdateAlchemyRates(string Parameter = "")
        {
            try
            {
                AlchemyRate.DataContext = Definitions.Listenings.RefObjCommon.ObjItem.First((Definitions.TableData.Main.RefObjItem x) => x.ID == ((Definitions.TableData.Main.RefObjCommon)AlchemyItemList.SelectedItem).Link);

                var objItem = Definitions.Listenings.RefObjCommon.ObjItem.First((Definitions.TableData.Main.RefObjItem x) => x.ID == ((Definitions.TableData.Main.RefObjCommon)AlchemyItemList.SelectedItem).Link);

                int[] Param2, Param3, Param4;
                var Parameters = Parameter?.Split(',');
                if (Parameters.Length == 3)
                {
                    Param2 = DecryptAlchemyParameters(Parameters[0]);
                    Param3 = DecryptAlchemyParameters(Parameters[1]);
                    Param4 = DecryptAlchemyParameters(Parameters[2]);

                    AlchemyParameters.Text = $"{Parameters[0]},{Parameters[1]},{Parameters[2]}";
                }
                else
                {
                    Param2 = DecryptAlchemyParameters(objItem.Param2.ToString());
                    Param3 = DecryptAlchemyParameters(objItem.Param3.ToString());
                    Param4 = DecryptAlchemyParameters(objItem.Param4.ToString());

                    AlchemyParameters.Text = $"{objItem.Param2},{objItem.Param3},{objItem.Param4}";
                }

                Plus_01.Text = Param2[0].ToString();
                Plus_02.Text = Param2[1].ToString();
                Plus_03.Text = Param2[2].ToString();
                Plus_04.Text = Param2[3].ToString();

                Plus_05.Text = Param3[0].ToString();
                Plus_06.Text = Param3[1].ToString();
                Plus_07.Text = Param3[2].ToString();
                Plus_08.Text = Param3[3].ToString();

                Plus_09.Text = Param4[0].ToString();
                Plus_10.Text = Param4[1].ToString();
                Plus_11.Text = Param4[2].ToString();
                Plus_12.Text = Param4[3].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void EncryptAlchemyRates()
        {
            var item = (Definitions.TableData.Main.RefObjItem)AlchemyRate.DataContext;
            var Param2 = $"{Convert.ToInt64(Plus_01.Text).ToString("X").PadLeft(2, '0')}{Convert.ToInt64(Plus_02.Text).ToString("X").PadLeft(2, '0')}{Convert.ToInt64(Plus_03.Text).ToString("X").PadLeft(2, '0')}{Convert.ToInt64(Plus_04.Text).ToString("X").PadLeft(2, '0')}";
            var Param3 = $"{Convert.ToInt64(Plus_05.Text).ToString("X").PadLeft(2, '0')}{Convert.ToInt64(Plus_06.Text).ToString("X").PadLeft(2, '0')}{Convert.ToInt64(Plus_07.Text).ToString("X").PadLeft(2, '0')}{Convert.ToInt64(Plus_08.Text).ToString("X").PadLeft(2, '0')}";
            var Param4 = $"{Convert.ToInt64(Plus_09.Text).ToString("X").PadLeft(2, '0')}{Convert.ToInt64(Plus_10.Text).ToString("X").PadLeft(2, '0')}{Convert.ToInt64(Plus_11.Text).ToString("X").PadLeft(2, '0')}{Convert.ToInt64(Plus_12.Text).ToString("X").PadLeft(2, '0')}";

            item.Param2 = Convert.ToInt32(Param2, 16);
            item.Param3 = Convert.ToInt32(Param3, 16);
            item.Param4 = Convert.ToInt32(Param4, 16);

            Definitions.Listenings.SQL.Connection.Save(item);

            $"[Database][AlchemyRates] Alchemy oranları başarıyla kaydedildi.".LogToForm();
        }

        public static int[] DecryptAlchemyParameters(string ParamValue)
        {
            var _Int32 = new int[4];
            var str = Convert.ToInt64(ParamValue).ToString("X");

            while (str.Length < 8)
            {
                str = "0" + str;
            }

            for (var i = 0; i < 4; i++)
            {
                _Int32[i] = Convert.ToInt32(str.Substring(i * 2, 2), 16);
            }

            return _Int32;
        }

        private void ResetAlcheymRate_Click(object sender, RoutedEventArgs e)
        {
            UpdateAlchemyRates();
        }

        private void SaveAlchemyRate_Click(object sender, RoutedEventArgs e)
        {
            EncryptAlchemyRates();
        }

        private void SetAlchemyParameters_Click(object sender, RoutedEventArgs e)
        {
            UpdateAlchemyRates(AlchemyParameters.Text);
        }
    }
}