using Pfim;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using Directory = Alphaleonis.Win32.Filesystem.Directory;
using File = Alphaleonis.Win32.Filesystem.File;
using MessageBox = System.Windows.MessageBox;

namespace ServerMaster.Forms.Pages.Others
{
    /// <summary>
    /// Interaction logic for DDJConverter.xaml
    /// </summary>
    public partial class DDJConverter
    {
        private string _selectedFolder;

        public DDJConverter()
        {
            InitializeComponent();
        }

        private void FolderSelector_OnClick(object sender, RoutedEventArgs e)
        {
            using (var targetFolderBrowser = new FolderBrowserDialog()
            {
                ShowNewFolderButton = true
            })
            {
                if (targetFolderBrowser.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                _selectedFolder = targetFolderBrowser.SelectedPath;
            }

            _selectedFolderLabel.Content = _selectedFolder;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Definitions.Directories.ServerMaster.ItemDizini.Refresh();
            if (!Definitions.Directories.ServerMaster.ItemDizini.Exists)
            {
                return;
            }

            Process.Start(Definitions.Directories.ServerMaster.ItemDizini.FullName);
        }

        private void ConvertTo_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!_selectedFolder.EndsWith(Path.DirectorySeparatorChar.ToString()))
                {
                    _selectedFolder += Path.DirectorySeparatorChar;
                }

                foreach (var file in Directory.GetFiles(_selectedFolder, "*.ddj", SearchOption.AllDirectories))
                {
                    var fileContentBytes = File.ReadAllBytes(file).Skip(20).ToArray();

                    using (var mStream = new MemoryStream(fileContentBytes))
                    {
                        using (var image = Pfim.Pfim.FromStream(mStream))
                        {
                            byte[] newData;

                            var tightStride = image.Width * image.BitsPerPixel / 8;
                            if (image.Stride != tightStride)
                            {
                                newData = new byte[image.Height * tightStride];
                                for (var i = 0; i < image.Height; i++)
                                {
                                    Buffer.BlockCopy(image.Data, i * image.Stride, newData, i * tightStride, tightStride);
                                }
                            }
                            else
                            {
                                newData = image.Data;
                            }

                            var newFile = new FileInfo(Path.ChangeExtension(file.Replace(_selectedFolder,
    Definitions.Directories.ServerMaster.ConverterDizini.FullName + Path.DirectorySeparatorChar), ".png"));
                            var encoder = new PngEncoder();

                            newFile.Directory.Create();

                            using (var fs = newFile.Create())
                            {
                                switch (image.Format)
                                {
                                    case ImageFormat.Rgba32:
                                        SixLabors.ImageSharp.Image.LoadPixelData<Bgra32>(newData, image.Width, image.Height)
                                            .Save(fs, encoder);
                                        break;

                                    case ImageFormat.Rgb24:
                                        SixLabors.ImageSharp.Image.LoadPixelData<Bgr24>(newData, image.Width, image.Height).Save(fs, encoder);
                                        break;

                                    case ImageFormat.Rgba16:
                                        SixLabors.ImageSharp.Image.LoadPixelData<Bgra4444>(newData, image.Width, image.Height)
                                            .Save(fs, encoder);
                                        break;

                                    case ImageFormat.R5g5b5:
                                        // Turn the alpha channel on for image sharp.
                                        for (int i = 1; i < newData.Length; i += 2)
                                        {
                                            newData[i] |= 128;
                                        }

                                        SixLabors.ImageSharp.Image.LoadPixelData<Bgra5551>(newData, image.Width, image.Height)
                                            .Save(fs, encoder);
                                        break;

                                    case ImageFormat.R5g5b5a1:
                                        SixLabors.ImageSharp.Image.LoadPixelData<Bgra5551>(newData, image.Width, image.Height)
                                            .Save(fs, encoder);
                                        break;

                                    case ImageFormat.R5g6b5:
                                        SixLabors.ImageSharp.Image.LoadPixelData<Bgr565>(newData, image.Width, image.Height)
                                            .Save(fs, encoder);
                                        break;

                                    case ImageFormat.Rgb8:
                                        SixLabors.ImageSharp.Image.LoadPixelData<Gray8>(newData, image.Width, image.Height).Save(fs, encoder);
                                        break;

                                    default:
                                        throw new Exception($"ImageSharp does not recognize image format: {image.Format}");
                                }
                            }
                        }
                    }
                }

                MessageBox.Show("Completed!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}