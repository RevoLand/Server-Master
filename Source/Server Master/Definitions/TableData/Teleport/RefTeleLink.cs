using NPoco;
using System;
using System.ComponentModel;

namespace ServerMaster.Definitions.TableData.Teleport
{
    [TableName("_RefTeleLink"), PrimaryKey("ID")]
    public class RefTeleLink : ICloneable, INotifyPropertyChanged
    {
        public Enums.Genel.Service Service { get; set; } = Enums.Genel.Service.Active;
        private int _OwnerTeleport, _TargetTeleport;

        public int OwnerTeleport
        {
            get => _OwnerTeleport;
            set
            {
                _OwnerTeleport = value;
                OnPropertyChanged("OwnerTeleport");
                OnPropertyChanged("GetOwnerTeleportName");
            }
        }

        public int TargetTeleport
        {
            get => _TargetTeleport;
            set
            {
                _TargetTeleport = value;
                OnPropertyChanged("TargetTeleport");
                OnPropertyChanged("GetTargetTeleportName");
            }
        }

        public int Fee { get; set; }
        public int RestrictBindMethod { get; set; } // Textdata'ya eklenmeyecek
        public int RunTimeTeleportMethod { get; set; } = 0;
        public int CheckResult { get; set; } = 0;
        public Enums.RefTeleLink.RestrictType Restrict1 { get; set; } = 0;
        public int Data1_1 { get; set; } = 0;
        public int Data1_2 { get; set; } = 0;
        public Enums.RefTeleLink.RestrictType Restrict2 { get; set; } = 0;
        public int Data2_1 { get; set; } = 0;
        public int Data2_2 { get; set; } = 0;
        public Enums.RefTeleLink.RestrictType Restrict3 { get; set; } = 0;
        public int Data3_1 { get; set; } = 0;
        public int Data3_2 { get; set; } = 0;
        public Enums.RefTeleLink.RestrictType Restrict4 { get; set; } = 0;
        public int Data4_1 { get; set; } = 0;
        public int Data4_2 { get; set; } = 0;
        public Enums.RefTeleLink.RestrictType Restrict5 { get; set; } = 0;
        public int Data5_1 { get; set; } = 0;
        public int Data5_2 { get; set; } = 0;

        public int ID { get; set; }

        [Ignore]
        public string GetOwnerTeleportName => Listenings.Teleport.RefTeleport.Find(x => x.ID == OwnerTeleport)?.ZoneName128_Media;

        [Ignore]
        public string GetTargetTeleportName => Listenings.Teleport.RefTeleport.Find(x => x.ID == TargetTeleport)?.ZoneName128_Media;

        public object Clone()
        {
            return MemberwiseClone();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string info) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
    }
}