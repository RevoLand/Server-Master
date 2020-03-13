using Pfim;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using File = Alphaleonis.Win32.Filesystem.File;
using FileInfo = Alphaleonis.Win32.Filesystem.FileInfo;
using Path = Alphaleonis.Win32.Filesystem.Path;

namespace ServerMaster.Functions.Media
{
    internal static class Image
    {
        public static ImageSource GetItemImage(string itemName, bool fullpath = false)
        {
            try
            {
                byte[] ddjContent;

                if (fullpath)
                {
                    ddjContent = File.ReadAllBytes(itemName);
                }
                else if (Definitions.Directories.Client.MediaPK2.Length > 0)
                {
                    ddjContent = Definitions.Listenings.Media.PK2.GetFileBytes(itemName);
                }
                else
                {
                    ddjContent = File.ReadAllBytes(Definitions.Directories.Client.Icon
                        .GetFiles(itemName, SearchOption.AllDirectories).FirstOrDefault()?.FullName);
                }

                if (ddjContent == null)
                    return new BitmapImage();

                itemName = itemName.Replace(".ddj", ".dds");

                var ddsPath = fullpath
                    ? new FileInfo(Path.Combine(Definitions.Directories.ServerMaster.ItemDizini.FullName,
                        new FileInfo(itemName).Name))
                    : new FileInfo(Path.Combine(Definitions.Directories.ServerMaster.ItemDizini.FullName, itemName));

                if (!ddsPath.Exists)
                {
                    if (!ddsPath.Directory.Exists)
                        ddsPath.Directory.Create();

                    CreateDdsFromDdjFile(ddsPath.FullName, ddjContent);
                }

                var image = Pfim.Pfim.FromFile(ddsPath.FullName);
                var pinnedArray = GCHandle.Alloc(image.Data, GCHandleType.Pinned);
                var addr = pinnedArray.AddrOfPinnedObject();

                PixelFormat format;
                switch (image.Format)
                {
                    case ImageFormat.Rgb24:
                        format = PixelFormats.Bgr24;
                        break;

                    case ImageFormat.Rgba32:
                        format = PixelFormats.Bgr32;
                        break;

                    case ImageFormat.Rgb8:
                        format = PixelFormats.Gray8;
                        break;

                    case ImageFormat.R5g5b5a1:
                    case ImageFormat.R5g5b5:
                        format = PixelFormats.Bgr555;
                        break;

                    case ImageFormat.R5g6b5:
                        format = PixelFormats.Bgr565;
                        break;

                    case ImageFormat.Rgba16:
                        format = PixelFormats.Gray16;
                        break;

                    default:
                        return new BitmapImage();
                }

                return BitmapSource.Create(image.Width, image.Height, 96.0, 96.0,
                    format, null, addr, image.DataLen, image.Stride);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return new BitmapImage();
            }
        }

        private static void CreateDdsFromDdjFile(string filePath, byte[] ddjContent)
        {
            try
            {
                using (var file = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                {
                    file.Write(ddjContent, 20, ddjContent.Length - 20);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void LoadDdjFiles()
        {
            if (Definitions.Directories.Client.MediaPK2.Length > 0)
            {
                foreach (var mediaFile in Definitions.Listenings.Media.PK2.Files.Where(x => x.Name.EndsWith(".ddj")).ToList())
                {
                    Definitions.Listenings.Other.DDJFiles.Add(new Definitions.TableData.Media.DDJFiles { FileName = mediaFile.Name });
                }
            }
            else
            {
                foreach (var mediaFile in Definitions.Directories.Client.Icon.GetFiles("*.ddj", SearchOption.AllDirectories))
                {
                    Definitions.Listenings.Other.DDJFiles.Add(new Definitions.TableData.Media.DDJFiles { FileName = mediaFile.FullName.Replace(Definitions.Directories.Client.Icon.FullName + "\\", ""), FullName = mediaFile.FullName });
                }
            }
        }
    }
}