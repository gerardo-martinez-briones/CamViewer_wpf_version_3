using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    public class Location
    {
        public Location()
        {
            X = 0;
            Y = 0;
        }

        [XmlAttribute("X")]
        public int X { get; set; }
        [XmlAttribute("Y")]
        public int Y { get; set; }
    }
}