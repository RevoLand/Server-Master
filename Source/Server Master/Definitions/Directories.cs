using Alphaleonis.Win32.Filesystem;

namespace ServerMaster.Definitions
{
    public static class Directories
    {
        public static class ServerMaster
        {
            // Current running directory of SLM
            public static readonly DirectoryInfo MevcutDizin = new DirectoryInfo(System.AppDomain.CurrentDomain.BaseDirectory);

            // Set cache directory of SLM to %temp%/Assembly Name (Steam Library Manager)
            public static DirectoryInfo TempDizini = new DirectoryInfo(Path.Combine(Path.GetTempPath(), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name));

            public static readonly DirectoryInfo MedyaDizini = new DirectoryInfo(Path.Combine(MevcutDizin.FullName, "Media"));

            public static readonly DirectoryInfo ItemDizini = new DirectoryInfo(Path.Combine(MedyaDizini.FullName, "ItemResim"));
            public static readonly DirectoryInfo ConverterDizini = new DirectoryInfo(Path.Combine(ItemDizini.FullName, "Converted"));

            public static readonly DirectoryInfo PK2YedekDizini = new DirectoryInfo(Path.Combine(MedyaDizini.FullName, "PK2_Yedek"));
        }

        public static class Client
        {
            public static FileInfo MediaPK2;
            public static DirectoryInfo Media;
            public static DirectoryInfo ServerDep;
            public static DirectoryInfo Icon;
        }
    }
}