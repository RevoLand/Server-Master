using System;
using System.IO;
using System.Linq;
using System.Windows;
using Path = Alphaleonis.Win32.Filesystem.Path;

namespace ServerMaster.Functions.Media
{
    internal static class TeleportData
    {
        public static void Save()
        {
            // _RefTeleport
            SaveRefTeleportAsync();

            // _RefTeleLink
            SaveRefTeleLinkAsync();

            // _RefOptionalTeleport - Reverse noktaları
            SaveRefOptionalTeleport();
        }

        private static async void SaveRefTeleportAsync()
        {
            try
            {
                const string fileName = "teleportdata.txt";

                using (var FileStream = new StreamWriter(Path.Combine(Definitions.Directories.ServerMaster.MedyaDizini.FullName, fileName), false, System.Text.Encoding.Unicode))
                {
                    foreach (var refTeleport in Definitions.Listenings.Teleport.RefTeleport.Where(x => x.Service == Definitions.Enums.Genel.Service.Active).OrderBy(x => x.ID).ThenBy(x => x))
                    {
                        await FileStream.WriteLineAsync($"{(int)refTeleport.Service}\t{refTeleport.ID}\t{refTeleport.CodeName128}\t{refTeleport.AssocRefObjID}\t{refTeleport.ZoneName128}\t{refTeleport.GenRegionID}\t{refTeleport.GenPos_X}\t{refTeleport.GenPos_Y}\t{refTeleport.GenPos_Z}\t{refTeleport.GenAreaRadius}\t{refTeleport.CanBeResurrectPos}\t{refTeleport.CanGotoResurrectPos}\t{refTeleport.GenWorldID}").ConfigureAwait(false);
                    }
                }

                $"[Media.PK2][Teleport][{fileName}] Dosya başarıyla kayıt edildi.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static async void SaveRefTeleLinkAsync()
        {
            try
            {
                const string fileName = "teleportlink.txt";

                using (var FileStream = new StreamWriter(Path.Combine(Definitions.Directories.ServerMaster.MedyaDizini.FullName, fileName), false, System.Text.Encoding.Unicode))
                {
                    foreach (var refTeleLink in Definitions.Listenings.Teleport.RefTeleLink.Where(x => x.Service == Definitions.Enums.Genel.Service.Active).OrderBy(x => x.OwnerTeleport).ThenBy(x => x.TargetTeleport))
                    {
                        await FileStream.WriteLineAsync($"{(int)refTeleLink.Service}\t{refTeleLink.OwnerTeleport}\t{refTeleLink.TargetTeleport}\t{refTeleLink.Fee}\t{refTeleLink.RunTimeTeleportMethod}\t{refTeleLink.CheckResult}\t{(int)refTeleLink.Restrict1}\t{refTeleLink.Data1_1}\t{refTeleLink.Data1_2}\t{(int)refTeleLink.Restrict2}\t{refTeleLink.Data2_1}\t{refTeleLink.Data2_2}\t{(int)refTeleLink.Restrict3}\t{refTeleLink.Data3_1}\t{refTeleLink.Data3_2}\t{(int)refTeleLink.Restrict4}\t{refTeleLink.Data4_1}\t{refTeleLink.Data4_2}\t{(int)refTeleLink.Restrict5}\t{refTeleLink.Data5_1}\t{refTeleLink.Data5_2}").ConfigureAwait(false);
                    }
                }

                $"[Media.PK2][Teleport][{fileName}] Dosya başarıyla kayıt edildi.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static void SaveRefOptionalTeleport()
        {
            try
            {
                const string fileName = "refoptionalteleport.txt";

                using (var FileStream = new StreamWriter(Path.Combine(Definitions.Directories.ServerMaster.MedyaDizini.FullName, fileName), false, System.Text.Encoding.Unicode))
                {
                    foreach (var refOptionalTeleport in Definitions.Listenings.SQL.Connection.Fetch<dynamic>("SELECT * FROM _RefOptionalTeleport WHERE Service = 1 ORDER BY ID"))
                    {
                        var textToWrite = "";
                        foreach (var item in refOptionalTeleport)
                        {
                            textToWrite += item.Value + "\t";
                        }
                        FileStream.WriteLine(textToWrite.Remove(textToWrite.Length - 1, 1));
                    }
                }

                $"[Media.PK2][Teleport][{fileName}] Dosya başarıyla kayıt edildi.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}