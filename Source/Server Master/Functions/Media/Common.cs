using System;
using System.IO;
using System.Linq;
using System.Windows;
using DirectoryInfo = Alphaleonis.Win32.Filesystem.DirectoryInfo;
using FileInfo = Alphaleonis.Win32.Filesystem.FileInfo;
using Path = Alphaleonis.Win32.Filesystem.Path;

namespace ServerMaster.Functions.Media
{
    internal static class Common
    {
        public static void SavePK2Lines()
        {
            try
            {
                if (!Definitions.Directories.ServerMaster.MedyaDizini.Exists)
                    Definitions.Directories.ServerMaster.MedyaDizini.Create();

                "[Media.PK2] (Varsa) Eski PK2 girdileri yedekleniyor...".LogToForm();
                BackupOldPK2Files();
                "[Media.PK2] Yedekleme tamamlandı. Yeni dosyalar yazılıyor...".LogToForm();

                if (Properties.Settings.Default.Media_GenerateRefObjCommon)
                {
                    var refObjCommon = Definitions.Listenings.RefObjCommon.ObjCommon.Where(x => x.Service == Definitions.Enums.Genel.Service.Active).ToList();

                    CharacterData.SaveAsync(refObjCommon.Where(x => x.TypeID1 == Definitions.Enums.RefObjCommon.TypeID1.Mob).OrderBy(x => x.ID).ToList());
                    ItemData.SaveAsync(refObjCommon.Where(x => x.TypeID1 == Definitions.Enums.RefObjCommon.TypeID1.Item).OrderBy(x => x.ID).ToList());
                    StructureData.SaveAsync(refObjCommon.Where(x => x.TypeID1 == Definitions.Enums.RefObjCommon.TypeID1.Object).OrderBy(x => x.ID).ToList());
                }

                if (Properties.Settings.Default.Media_GenerateRefSkill)
                {
                    SkillData.SaveAsync(Definitions.Listenings.RefSkill.Where(x => x.Service == Definitions.Enums.Genel.Service.Active).OrderBy(x => x.ID).ToList());
                }

                if (Properties.Settings.Default.Media_GenerateNPC)
                {
                    NPCData.Save();
                }

                if (Properties.Settings.Default.Media_GenerateTeleport)
                {
                    TeleportData.Save();
                }

                if (Properties.Settings.Default.Media_GenerateOthers)
                {
                    Others.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void BackupOldPK2Files()
        {
            try
            {
                var oldPK2Files = Definitions.Directories.ServerMaster.MedyaDizini.GetFileSystemInfos("*.txt", SearchOption.TopDirectoryOnly).ToList();

                if (oldPK2Files.Count == 0)
                    return;

                if (!Definitions.Directories.ServerMaster.PK2YedekDizini.Exists)
                    Definitions.Directories.ServerMaster.PK2YedekDizini.Create();

                var currentTime = DateTime.Now;
                var backupDirectory = new DirectoryInfo(Path.Combine(Definitions.Directories.ServerMaster.PK2YedekDizini.FullName,
                    $"{currentTime:d_M_yyyy HH-mm-ss}"));

                if (!backupDirectory.Exists)
                    backupDirectory.Create();

                foreach (FileInfo fileInfo in oldPK2Files)
                {
                    fileInfo.MoveTo(Path.Combine(backupDirectory.FullName, fileInfo.Name));
                }

                $"[Media.PK2] {oldPK2Files.Count} dosya yedeklendi.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}