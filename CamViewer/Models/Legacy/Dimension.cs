using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    public class Dimension
    {
        [XmlAttribute("Width")]
        public int Width { get; set; } = 0;
        [XmlAttribute("Height")]
        public int Height { get; set; } = 0;
    }
}