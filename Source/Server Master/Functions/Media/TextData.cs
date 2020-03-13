using System;
using System.IO;
using System.Linq;
using System.Windows;
using File = Alphaleonis.Win32.Filesystem.File;

namespace ServerMaster.Functions.Media
{
    internal static class TextData
    {
        public static string FindFromTextData(string Ref)
        {
            try
            {
                if (Ref == "xxx")
                    return Ref;

                return Definitions.Listenings.Media.TextUISystem.Find(x => x.RefName == Ref)?.Text ?? Ref;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return Ref;
            }
        }

        public static void ParseTextUISystemFile(string fileName)
        {
            try
            {
                var textdataLines = new string[0];

                if (Definitions.Directories.Client.MediaPK2.Length > 0)
                {
                    textdataLines = Definitions.Listenings.Media.PK2.GetFileText(fileName).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                }
                else
                {
                    textdataLines = File.ReadAllLines(Definitions.Directories.Client.ServerDep.GetFiles(fileName, SearchOption.AllDirectories).FirstOrDefault()?.FullName);
                }

                foreach (var textdataLine in textdataLines)
                {
                    if (textdataLine.EndsWith(".txt"))
                    {
                        ParseTextUISystemFile(textdataLine);
                        continue;
                    }

                    var textdataRows = textdataLine.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    if (textdataRows.Length < ((fileName == "textuisystem.txt") ? 18 : 3))
                        continue;

                    Definitions.Listenings.Media.TextUISystem.Add(new Definitions.TableData.Media.TextUISystem
                    {
                        RefName = textdataRows[1],
                        Text = (fileName == "textuisystem.txt") ? textdataRows[9] : textdataRows[2]
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}