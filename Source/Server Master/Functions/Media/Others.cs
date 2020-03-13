using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using Path = Alphaleonis.Win32.Filesystem.Path;

namespace ServerMaster.Functions.Media
{
    internal static class Others
    {
        public static void Save()
        {
            SaveHWANLevelData();
        }

        private static void SaveHWANLevelData()
        {
            try
            {
                const string fileName = "hwanleveldata.txt";

                using (var FileStream = new StreamWriter(Path.Combine(Definitions.Directories.ServerMaster.MedyaDizini.FullName, fileName), false, Encoding.Unicode))
                {
                    foreach (var hwanLevel in Definitions.Listenings.Other.HWANLevels.ToList())
                    {
                        FileStream.WriteLine($"{hwanLevel.HwanLevel}\t{hwanLevel.ParamFourcc1}\t{hwanLevel.ParamValue1}\t{hwanLevel.ParamFourcc2}\t{hwanLevel.ParamValue2}\t{hwanLevel.ParamFourcc3}\t{hwanLevel.ParamValue3}\t{hwanLevel.ParamFourcc4}\t{hwanLevel.ParamValue4}\t{hwanLevel.ParamFourcc5}\t{hwanLevel.ParamValue5}\t{hwanLevel.AssocFileObj128}\t{hwanLevel.Title_CH70}\t{hwanLevel.Title_EU70}");
                    }
                }

                $"[Media.PK2][Others][{fileName}] Dosya başarıyla kayıt edildi.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}