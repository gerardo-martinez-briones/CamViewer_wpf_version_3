using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    public class Dimension
    {
        public Dimension()
        {
            Width = 0;
            Height = 0;
        }

        [XmlAttribute("Width")]
        public int Width { get; set; }
        [XmlAttribute("Height")]
        public int Height { get; set; }
    }
}