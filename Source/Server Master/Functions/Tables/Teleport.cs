using System;
using System.Windows;

namespace ServerMaster.Functions.Tables
{
    internal static class Teleport
    {
        public static void LoadRefTeleportTable()
        {
            try
            {
                Definitions.Listenings.Teleport.RefTeleport = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.Teleport.RefTeleport>("SELECT * FROM _RefTeleport");

                $"[SQL] _RefTeleport tablosu yüklendi. Tabloda {Definitions.Listenings.Teleport.RefTeleport.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadRefTeleLinkTable()
        {
            try
            {
                Definitions.Listenings.Teleport.RefTeleLink = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.Teleport.RefTeleLink>("SELECT * FROM _RefTeleLink");

                $"[SQL] _RefTeleLink tablosu yüklendi. Tabloda {Definitions.Listenings.Teleport.RefTeleLink.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
