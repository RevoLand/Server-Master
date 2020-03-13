using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using Path = Alphaleonis.Win32.Filesystem.Path;

namespace ServerMaster.Functions.Media
{
    internal static class SkillData
    {
        public static async void SaveAsync(List<Definitions.TableData.Main.RefSkill> RefSkill, int DataLineCount = 5000)
        {
            try
            {
                using (var SkillDataFile = new StreamWriter(Path.Combine(Definitions.Directories.ServerMaster.MedyaDizini.FullName, "skilldata.txt"), false, System.Text.Encoding.Unicode))
                {
                    using (var SkillDataEncFile = new StreamWriter(Path.Combine(Definitions.Directories.ServerMaster.MedyaDizini.FullName, "skilldataenc.txt"), false, System.Text.Encoding.Unicode))
                    {
                        for (int i = 0, j, k = 0; k < RefSkill.Count; i = j)
                        {
                            j = i + DataLineCount;

                            if (!RefSkill.Any(x => x.ID >= i && x.ID < j))
                                continue;

                            var fileName = $"skilldata_{j}.txt";
                            await SkillDataFile.WriteLineAsync(fileName).ConfigureAwait(false);
                            await SkillDataEncFile.WriteLineAsync(fileName.Replace(".txt", "_enc.txt")).ConfigureAwait(false);

                            using (var itemData = new StreamWriter(Path.Combine(Definitions.Directories.ServerMaster.MedyaDizini.FullName, fileName), false, System.Text.Encoding.Unicode))
                            {
                                foreach (var skillData in RefSkill.Where(x => x.ID >= i && x.ID < j).OrderBy(x => x.ID))
                                {
                                    var textToWrite = "";
                                    foreach (var dataLine in skillData.GetType().GetFilteredProperties())
                                    {
                                        if (dataLine.PropertyType.IsEnum)
                                        {
                                            textToWrite += (int)dataLine.GetValue(skillData, null) + "\t";
                                        }
                                        else
                                        {
                                            textToWrite += dataLine.GetValue(skillData, null) + "\t";
                                        }
                                    }

                                    await itemData.WriteLineAsync(textToWrite.Remove(textToWrite.Length - 1, 1)).ConfigureAwait(false);
                                    k++;
                                }
                            }

                            $"[Media.PK2][Skill][{fileName}] Dosya başarıyla kayıt edildi.".LogToForm();
                            var SkillDataEncrypter = new Framework.SkillDecrypt();
                            SkillDataEncrypter.ReadAndDecryptFile(Path.Combine(Definitions.Directories.ServerMaster.MedyaDizini.FullName, fileName));
                            SkillDataEncrypter.SaveFile(Path.Combine(Definitions.Directories.ServerMaster.MedyaDizini.FullName, fileName.Replace(".txt", "_enc.txt")));
                        }
                    }
                }

                "[Media.PK2][Skill] İşlem başarıyla tamamlandı.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}