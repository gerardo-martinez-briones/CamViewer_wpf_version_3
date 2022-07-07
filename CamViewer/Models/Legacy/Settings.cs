using System.Collections.Generic;
using System.Xml.Serialization;
using static CamViewer.Helpers.General;

namespace CamViewer.Models.Legacy
{
    [XmlRoot("Settings")]
    public class Settings
    {
        public int Type { get; set; } = (int)NodeTypeEnum.XML_FILE_NODE;
        public string Id { get; set; } = string.Empty;
        public string SettingsPath { get; set; } = string.Empty;
        public string PrefixCraneName { get; set; } = string.Empty;
        public string CraneNameTemplate { get; set; } = string.Empty;
        public string BlockNameTemplate { get; set; } = string.Empty;
        public string Project { get; set; } = string.Empty;
        public string RosID { get; set; } = string.Empty;
        public string ROSIniPath { get; set; } = string.Empty;
        public List<Block> Blocks { get; set; } = new List<Block>();
        public Credential Credentials { get; set; } = new Credential();
        public List<CameraType> CameraTypes { get; set; } = new List<CameraType>();
        public List<Preset> Presets { get; set; } = new List<Preset>();
        public List<CimPoint> CimplicityPoints { get; set; } = new List<CimPoint>();
        public List<FormSetup> Forms { get; set; } = new List<FormSetup>();
        public FormRemote FormRemote { get; set; } = new FormRemote();
    }
}