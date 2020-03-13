using Alphaleonis.Win32.Filesystem;
using System;
using System.Linq;

namespace ServerMaster.Functions.Tables
{
    internal static class Other
    {
        public static void LoadHwanLines()
        {
            Definitions.Listenings.Other.HWANLevels = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.Others.RefHWANLevel>("SELECT * FROM _RefHWANLevel ORDER BY HwanLevel");

            $"[SQL] _RefHWANLevel tablosu yüklendi. Tabloda {Definitions.Listenings.Other.HWANLevels.Count} veri bulundu.".LogToForm();
        }

        public static void LoadMapViewerLines()
        {
            var reversePoints = Definitions.Listenings.SQL.Connection.Fetch<dynamic>("SELECT * FROM _RefOptionalTeleport ORDER BY ID");

            foreach (var MapFile in Directory.GetFiles(Path.Combine(Definitions.Directories.Client.Media.FullName, "minimap"), "*.ddj"))
            {
                var fileInfo = new FileInfo(MapFile);
                var mapFile = new Definitions.MediaData.MapFile
                {
                    FileName = MapFile,
                    X = Convert.ToInt16(fileInfo.Name.Split('x').First()),
                    Y = Convert.ToInt16(fileInfo.Name.Split('x').Last().Replace(".ddj", "")),
                };

                if (reversePoints.Count(x => x.RegionID == mapFile.RegionID) > 0)
                {
                    foreach (var mapmarker in reversePoints.Where(x => x.RegionID == mapFile.RegionID))
                    {
                        mapFile.MapPoints.Add(new Definitions.MediaData.MapPoint
                        {
                            Name = mapmarker.ZoneName128,
                            PointRegionID = mapmarker.RegionID,
                            RegionID = mapFile.RegionID,
                            X = mapmarker.Pos_X,
                            Y = mapmarker.Pos_Y
                        });
                    }
                }

                Definitions.Listenings.Media.MapFiles.Add(mapFile);
            }
        }
    }
}