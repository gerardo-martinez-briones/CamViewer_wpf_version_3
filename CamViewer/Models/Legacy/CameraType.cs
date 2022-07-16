using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    public class CameraType
    {
        public CameraType()
        {
            IDType = 0;
            IDPreset = 0;
            DynamicName = string.Empty;
            MediaUrl = string.Empty;
            PTZControlUrl = string.Empty;
            BlockFlag = false;
            DescriptionText = string.Empty;
        }

        [XmlAttribute("ID")]
        public int IDType { get; set; }
        public int IDPreset { get; set; }
        public string DynamicName { get; set; }
        public string MediaUrl { get; set; }
        public string PTZControlUrl { get; set; }
        public bool BlockFlag { get; set; }
        public string DescriptionText { get; set; }
    }
}