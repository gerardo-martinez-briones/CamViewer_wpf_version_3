using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    public class Camera
    {
        [XmlAttribute("ID")]
        public int IDCamera { get; set; } = 0;
        [XmlAttribute("IDType")]
        public int IDType { get; set; } = 0;
        [XmlAttribute("CameraNumber")]
        public int CameraNumber { get; set; } = 0;
        [XmlAttribute("IndexLane")]
        public int IndexLane { get; set; } = 0;
    }
}