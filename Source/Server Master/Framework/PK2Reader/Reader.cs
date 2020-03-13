using ServerMaster.Framework.SilkroadSecurityApi;

// Main Copyright: bloodman (Algorythm & baseclass)
// Sub Copyright: MrLordschaft (Editing & Improving)
// Source: http://www.elitepvpers.com/forum/sro-coding-corner/2469483-release-c-pk2-reader-including-sourcecode.html
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using FileInfo = Alphaleonis.Win32.Filesystem.FileInfo;

namespace ServerMaster.Framework.PK2Reader
{
    public class Reader : IDisposable
    {
        #region Properties & Member variables

        private readonly Blowfish m_Blowfish = new Blowfish();

        private long m_Size;
        public long Size => m_Size;

        private byte[] m_Key;
        public byte[] Key => m_Key;

        private string m_Key_Ascii = string.Empty;
        public string ASCIIKey => m_Key_Ascii;

        private SPk2Header m_Header;
        public SPk2Header Header => m_Header;

        private List<SPk2EntryBlock> m_EntryBlocks = new List<SPk2EntryBlock>();
        public List<SPk2EntryBlock> EntryBlocks => m_EntryBlocks;

        private List<File> m_Files = new List<File>();
        public List<File> Files => m_Files;

        private List<Folder> m_Folders = new List<Folder>();
        public List<Folder> Folders => m_Folders;

        private string m_Path;
        public string Path => m_Path;

        private Folder m_CurrentFolder;
        private Folder m_MainFolder;
        private readonly FileStream m_FileStream;

        #endregion Properties & Member variables

        #region Constructor

        public Reader(string FileName, string Key)
        {
            try
            {
                if (!System.IO.File.Exists(FileName))
                {
                    throw new Exception("File not found");
                }
                else
                {
                    m_Path = FileName;
                    m_Key = GenerateFinalBlowfishKey(Key);
                    m_Key_Ascii = Key;

                    m_FileStream = new FileStream(FileName, FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
                    m_Size = m_FileStream.Length;

                    m_Blowfish.Initialize(m_Key);
                    var reader = new System.IO.BinaryReader(m_FileStream);
                    m_Header = (SPk2Header)BufferToStruct(reader.ReadBytes(256), typeof(SPk2Header));
                    m_CurrentFolder = new Folder()
                    {
                        Name = FileName,
                        Files = new List<File>(),
                        SubFolders = new List<Folder>()
                    };
                    m_MainFolder = m_CurrentFolder;
                    Read(reader.BaseStream.Position);
                }
            }
            catch { }
        }

        #endregion Constructor

        #region Blowfish:Key_Generation

        private static byte[] GenerateFinalBlowfishKey(string ascii_key)
        {
            //Using the default Base_Key
            return GenerateFinalBlowfishKey(ascii_key, new byte[] { 0x03, 0xF8, 0xE4, 0x44, 0x88, 0x99, 0x3F, 0x64, 0xFE, 0x35 });
        }

        private static byte[] GenerateFinalBlowfishKey(string ascii_key, byte[] base_key)
        {
            var ascii_key_lenght = (byte)ascii_key.Length;

            //Max count of 56 key bytes
            if (ascii_key_lenght > 56)
            {
                ascii_key_lenght = 56;
            }

            //Get bytes from ascii
            var a_key = Encoding.ASCII.GetBytes(ascii_key);

            //This is the Silkroad bas key used in all versions
            var b_key = new byte[56];

            //Copy key to array to keep the b_key at 56 bytes. b_key has to be bigger than a_key
            //to be able to xor every index of a_key.
            Array.ConstrainedCopy(base_key, 0, b_key, 0, base_key.Length);

            // Their key modification algorithm for the final blowfish key
            var bf_key = new byte[ascii_key_lenght];
            for (byte x = 0; x < ascii_key_lenght; ++x)
            {
                bf_key[x] = (byte)(a_key[x] ^ b_key[x]);
            }

            return bf_key;
        }

        #endregion Blowfish:Key_Generation

        #region Functions & Methods

        public void ExtractFile(File File, string OutputPath)
        {
            var data = GetFileBytes(File);
            var stream = new FileStream(OutputPath, FileMode.OpenOrCreate);
            var writer = new BinaryWriter(stream);
            writer.Write(data);
            writer.Close();
        }

        public void ExtractFile(string Name, string OutputPath)
        {
            var data = GetFileBytes(Name);

            if (data == null)
                return;

            var fileInfo = new FileInfo(OutputPath);

            if (!fileInfo.Directory.Exists)
                fileInfo.Directory.Create();

            var stream = new FileStream(fileInfo.FullName, FileMode.OpenOrCreate, FileAccess.Write);
            var writer = new BinaryWriter(stream);
            writer.Write(data);
            writer.Close();
        }

        public string GetFileExtension(File File)
        {
            var Offset = File.Name.LastIndexOf('.');
            return File.Name.Substring(Offset);
        }

        public string GetFileExtension(string Name)
        {
            if (FileExists(Name))
            {
                var Offset = Name.LastIndexOf('.');
                return Name.Substring(Offset);
            }
            else
            {
                throw new Exception("The file does not exsist");
            }
        }

        public List<File> GetRootFiles()
        {
            return m_MainFolder.Files;
        }

        public List<Folder> GetRootFolders()
        {
            return m_MainFolder.SubFolders;
        }

        public List<File> GetFiles(string ParentFolder)
        {
            var ObjToReturn = new List<File>();
            foreach (var file in Files)
            {
                if (file.ParentFolder.Name == ParentFolder)
                {
                    ObjToReturn.Add(file);
                }
            }
            return ObjToReturn;
        }

        public List<Folder> GetSubFolders(string ParentFolder)
        {
            var ObjToReturn = new List<Folder>();
            foreach (var folder in Folders)
            {
                if (folder.Name == ParentFolder)
                {
                    foreach (var subFolder in folder.SubFolders)
                    {
                        ObjToReturn.Add(subFolder);
                    }
                }
            }
            return ObjToReturn;
        }

        public bool FileExists(string Name)
        {
            try
            {
                var file = m_Files.Find(item => string.Equals(item.Name, Name, StringComparison.InvariantCultureIgnoreCase));
                if (file != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public byte[] GetFileBytes(string Name)
        {
            if (FileExists(Name))
            {
                var reader = new System.IO.BinaryReader(m_FileStream);
                var file = m_Files.Find(item => string.Equals(item.Name, Name, StringComparison.InvariantCultureIgnoreCase));
                reader.BaseStream.Position = file.Position;
                return reader.ReadBytes((int)file.Size);
            }
            else
            {
                //throw new Exception(string.Format("pk2Reader: File not found: {0}", Name));
                return null;
            }
        }

        public byte[] GetFileBytes(File File)
        {
            if (FileExists(File.Name))
            {
                var reader = new System.IO.BinaryReader(m_FileStream);
                var file = m_Files.Find(item => string.Equals(item.Name, File.Name, StringComparison.InvariantCultureIgnoreCase));
                reader.BaseStream.Position = file.Position;
                return reader.ReadBytes((int)file.Size);
            }
            else
            {
                //throw new Exception(string.Format("pk2Reader: File not found: {0}", Name));
                return null;
            }
        }

        public string GetFileText(string Name)
        {
            if (FileExists(Name))
            {
                var tempBuffer = GetFileBytes(Name);
                if (tempBuffer != null)
                {
                    System.IO.TextReader txtReader = new System.IO.StreamReader(new System.IO.MemoryStream(tempBuffer));
                    return txtReader.ReadToEnd();
                }
                else
                {
                    return null;
                }
            }
            else
            {
                throw new Exception("File does not exsist!");
            }
        }

        public string GetFileText(File File)
        {
            var tempBuffer = GetFileBytes(File.Name);
            if (tempBuffer != null)
            {
                System.IO.TextReader txtReader = new System.IO.StreamReader(new System.IO.MemoryStream(tempBuffer));
                return txtReader.ReadToEnd();
            }
            else
            {
                return null;
            }
        }

        public System.IO.Stream GetFileStream(string Name)
        {
            var ObjToReturn = new System.IO.MemoryStream(GetFileBytes(Name));
            return ObjToReturn;
        }

        public System.IO.Stream GetFileStream(File File)
        {
            var ObjToReturn = new System.IO.MemoryStream(GetFileBytes(File.Name));
            return ObjToReturn;
        }

        public List<string> GetFileNames()
        {
            var tmpList = new List<string>();
            foreach (var file in m_Files)
            {
                tmpList.Add(file.Name);
            }
            return tmpList;
        }

        private void Read(long Position)
        {
            var reader = new System.IO.BinaryReader(m_FileStream);
            reader.BaseStream.Position = Position;
            var folders = new List<Folder>();
            var entryBlock = (SPk2EntryBlock)BufferToStruct(m_Blowfish.Decode(reader.ReadBytes(Marshal.SizeOf(typeof(SPk2EntryBlock)))), typeof(SPk2EntryBlock));

            for (var i = 0; i < 20; i++)
            {
                var entry = entryBlock.Entries[i];
                switch (entry.Type)
                {
                    case 0: //Null Entry

                        break;

                    case 1: //Folder
                        if (entry.Name != "." && entry.Name != "..")
                        {
                            var folder = new Folder()
                            {
                                Name = entry.Name,
                                Position = BitConverter.ToInt64(entry.g_Position, 0)
                            };
                            folders.Add(folder);
                            m_Folders.Add(folder);
                            m_CurrentFolder.SubFolders.Add(folder);
                        }
                        break;

                    case 2: //File
                        var file = new File()
                        {
                            Position = entry.Position,
                            Name = entry.Name,
                            Size = entry.Size,
                            ParentFolder = m_CurrentFolder
                        };
                        m_Files.Add(file);
                        m_CurrentFolder.Files.Add(file);
                        break;
                }
            }
            if (entryBlock.Entries[19].NextChain != 0)
            {
                Read(entryBlock.Entries[19].NextChain);
            }

            foreach (var folder in folders)
            {
                m_CurrentFolder = folder;
                if (folder.Files == null)
                {
                    folder.Files = new List<File>();
                }
                if (folder.SubFolders == null)
                {
                    folder.SubFolders = new List<Folder>();
                }
                Read(folder.Position);
            }
        }

        #endregion Functions & Methods

        #region Structures

        private object BufferToStruct(byte[] buffer, Type returnStruct)
        {
            var pointer = Marshal.AllocHGlobal(buffer.Length);
            Marshal.Copy(buffer, 0, pointer, buffer.Length);
            return Marshal.PtrToStructure(pointer, returnStruct);
        }

        [StructLayout(LayoutKind.Sequential, Size = 256)]
        public struct SPk2Header
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
            public string Name;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Version;

            [MarshalAs(UnmanagedType.I1, SizeConst = 1)]
            public byte Encryption;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] Verify;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 205)]
            public byte[] Reserved;
        }

        [StructLayout(LayoutKind.Sequential, Size = 128)]
        public struct SPk2Entry
        {
            [MarshalAs(UnmanagedType.I1)]
            public byte Type; //files are 2, folger are 1, null entries re 0

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
            public string Name;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] AccessTime;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] CreateTime;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] ModifyTime;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] g_Position;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            private readonly byte[] m_Size;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            private readonly byte[] m_NextChain;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Padding;

            public long NextChain => BitConverter.ToInt64(m_NextChain, 0);
            public long Position => BitConverter.ToInt64(g_Position, 0);
            public uint Size => BitConverter.ToUInt32(m_Size, 0);
        }

        [StructLayout(LayoutKind.Sequential, Size = 2560)]
        public struct SPk2EntryBlock
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public SPk2Entry[] Entries;
        }

        #endregion Structures

        #region Dispose

        public void Dispose()
        {
            m_CurrentFolder = null;
            m_EntryBlocks = null;
            m_Files = null;
            //m_FileStream = null;
            m_FileStream.Dispose();
            m_Folders = null;
            m_Key = null;
            m_Key_Ascii = null;
            m_MainFolder = null;
            m_Path = null;
            m_Size = 0;
        }

        #endregion Dispose
    }

    public class File
    {
        public string Name { get; set; }
        public long Position { get; set; }
        public uint Size { get; set; }
        public Folder ParentFolder { get; set; }
    }

    public class Folder
    {
        public string Name { get; set; }
        public long Position { get; set; }
        public List<File> Files { get; set; }
        public List<Folder> SubFolders { get; set; }
    }
}