using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    public class Location
    {
        [XmlAttribute("X")]
        public int X { get; set; } = 0;
        [XmlAttribute("Y")]
        public int Y { get; set; } = 0;
    }
}