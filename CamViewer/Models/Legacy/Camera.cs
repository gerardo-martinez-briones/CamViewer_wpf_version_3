using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    public class Camera
    {
        public Camera()
        {
            IDCamera = 0;
            IDType = 0;
            CameraNumber = 0;
            IndexLane = 0;
        }

        [XmlAttribute("ID")]
        public int IDCamera { get; set; }
        [XmlAttribute("IDType")]
        public int IDType { get; set; }
        [XmlAttribute("CameraNumber")]
        public int CameraNumber { get; set; }
        [XmlAttribute("IndexLane")]
        public int IndexLane { get; set; }
    }
}