using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using static CamViewer.Helpers.General;

namespace CamViewer.Models.Legacy
{
    [XmlRoot("Settings")]
    public class Settings
    {
        public Settings()
        {
            Type = (int)NodeTypeEnum.Settings_File_Name;
            Id = Guid.NewGuid().ToString();
            SettingsPath = string.Empty;
            PrefixCraneName = string.Empty;
            CraneNameTemplate = string.Empty;
            BlockNameTemplate = string.Empty;
            Project = string.Empty;
            RosID = string.Empty;
            ROSIniPath = string.Empty;

            Blocks = new List<Block>();
            Credentials = new Credential();
            CameraTypes = new List<CameraType>();
            Presets = new List<Preset>();
            CimplicityPoints = new List<CimPoint>();
            Forms = new List<FormSetup>();
            FormRemote = new FormRemote();
        }

        public int Type { get; set; }
        public string Id { get; set; }
        public string SettingsPath { get; set; }
        public string PrefixCraneName { get; set; }
        public string CraneNameTemplate { get; set; }
        public string BlockNameTemplate { get; set; }
        public string Project { get; set; }
        public string RosID { get; set; }
        public string ROSIniPath { get; set; }

        public List<Block> Blocks { get; set; }
        public Credential Credentials { get; set; }
        public List<CameraType> CameraTypes { get; set; }
        public List<Preset> Presets { get; set; }
        public List<CimPoint> CimplicityPoints { get; set; }
        public List<FormSetup> Forms { get; set; }
        public FormRemote FormRemote { get; set; }
    }
}