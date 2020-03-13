using System;
using System.Windows;

namespace ServerMaster.Functions.Tables
{
    internal static class Main
    {
        public static void LoadObjCommonTable()
        {
            try
            {
                Definitions.Listenings.RefObjCommon.ObjCommon = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.Main.RefObjCommon>("SELECT * FROM _RefObjCommon WHERE ID > 0");

                $"[SQL] _RefObjCommon tablosu yüklendi. Tabloda {Definitions.Listenings.RefObjCommon.ObjCommon.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadObjCharTable()
        {
            try
            {
                Definitions.Listenings.RefObjCommon.ObjChar = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.Main.RefObjChar>("SELECT * FROM _RefObjChar");

                $"[SQL] _RefObjChar tablosu yüklendi. Tabloda {Definitions.Listenings.RefObjCommon.ObjChar.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadObjItemTable()
        {
            try
            {
                Definitions.Listenings.RefObjCommon.ObjItem = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.Main.RefObjItem>("SELECT * FROM _RefObjItem");

                $"[SQL] _RefObjItem tablosu yüklendi. Tabloda {Definitions.Listenings.RefObjCommon.ObjItem.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadObjStructTable()
        {
            try
            {
                Definitions.Listenings.RefObjCommon.ObjStruct = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.Main.RefObjStruct>("SELECT * FROM _RefObjStruct");

                $"[SQL] _RefObjStruct tablosu yüklendi. Tabloda {Definitions.Listenings.RefObjCommon.ObjStruct.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadRefSkillTable()
        {
            try
            {
                Definitions.Listenings.RefSkill = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.Main.RefSkill>("SELECT * FROM _RefSkill");

                $"[SQL] _RefSkill tablosu yüklendi. Tabloda {Definitions.Listenings.RefSkill.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}