using System;

namespace ServerMaster.Definitions.TableData
{
    internal static class Media
    {
        public class MissingDDJLines
        {
            public string FilePath { get; set; }
            public string AssocFileIcon128 { get; set; }
            public string CodeName128 { get; set; }
        }

        public class MissingBSRLines
        {
            public string FilePath { get; set; }
            public string AssocFileObj128 { get; set; }
            public string CodeName128 { get; set; }
        }

        public class DDJFiles
        {
            public string FileName { get; set; }
            public string FullName { get; set; }

            private System.Windows.Media.ImageSource _mediaImage;

            public System.Windows.Media.ImageSource MediaImage
            {
                get
                {
                    if (_mediaImage != null) return _mediaImage;
                    var fileName = FileName.Split(new[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
                    _mediaImage = Functions.Media.Image.GetItemImage(fileName[fileName.Length - 1]);

                    return _mediaImage;
                }
            }
        }

        public class TextUISystem
        {
            public string RefName { get; set; }
            public string Text { get; set; }
        }
    }
}