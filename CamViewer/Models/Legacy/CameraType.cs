using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    public class CameraType
    {
        [XmlAttribute("ID")]
        public int IDType { get; set; } = 0;
        public int IDPreset { get; set; } = 0;
        public string DynamicName { get; set; } = string.Empty;
        public string MediaUrl { get; set; } = string.Empty;
        public string PTZControlUrl { get; set; } = string.Empty;
        public bool BlockFlag { get; set; } = false;
        public string DescriptionText { get; set; } = string.Empty;
    }
}