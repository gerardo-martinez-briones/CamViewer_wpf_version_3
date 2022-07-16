using System.Collections.Generic;
using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    public class Position
    {
        public Position()
        {
            IDChassis = 0;
            Types = string.Empty;
            CameraNumbers = string.Empty;

            InternalTypes = new List<int>();
            InternalCameraNumbers = new List<int>();
        }

        [XmlAttribute("ID")]
        public int IDChassis { get; set; }
        [XmlAttribute("Types")]
        public string Types { get; set; }
        [XmlAttribute("CameraNumbers")]
        public string CameraNumbers { get; set; }
        public List<int> InternalTypes { get; set; }
        public List<int> InternalCameraNumbers { get; set; }
    }
}