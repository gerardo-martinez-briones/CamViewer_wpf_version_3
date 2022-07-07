using System.Collections.Generic;
using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    public class Position
    {
        [XmlAttribute("ID")]
        public int IDChassis { get; set; } = 0;
        [XmlAttribute("Types")]
        public string Types { get; set; } = string.Empty;
        [XmlAttribute("CameraNumbers")]
        public string CameraNumbers { get; set; } = string.Empty;
        public List<int> InternalTypes { get; set; } = new List<int>();
        public List<int> InternalCameraNumbers { get; set; } = new List<int>();
    }
}