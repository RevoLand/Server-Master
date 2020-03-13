using System.Collections.Generic;

namespace ServerMaster.Definitions
{
    public static class MediaData
    {
        public class MapFile
        {
            public string FileName { get; set; }
            public int X { get; set; }
            public int Y { get; set; }

            public int RegionID => int.Parse(Y.ToString("X") + X.ToString("X"), System.Globalization.NumberStyles.HexNumber);

            public List<MapPoint> MapPoints { get; set; } = new List<MapPoint>();

            private System.Windows.Media.ImageSource _mediaImage;

            public System.Windows.Media.ImageSource MediaImage
            {
                get { return _mediaImage ?? (_mediaImage = Functions.Media.Image.GetItemImage(FileName, true)); }
            }
        }

        public class MapPoint
        {
            public string Name { get; set; }
            public int PointRegionID { get; set; }
            public double X { get; set; }
            public double Y { get; set; }
            public int RegionID { get; set; }

            public System.Windows.Thickness Thickness
            {
                get
                {
                    var LatestX = (PointRegionID - RegionID) * 32;
                    LatestX = (LatestX == 128) ? 96 : LatestX;
                    LatestX = (int)((X / 50) + LatestX);
                    LatestX = (LatestX > 128) ? 128 : LatestX;

                    var latestY = Y / 93.6;
                    latestY = (latestY > 128) ? 128 : latestY;

                    return new System.Windows.Thickness(LatestX, 0, 0, latestY);
                }
            }

            public string DataContextTest => $"[{PointRegionID} - {RegionID}] {Name}: {X}:{Y} | {Thickness}";
        }
    }
}