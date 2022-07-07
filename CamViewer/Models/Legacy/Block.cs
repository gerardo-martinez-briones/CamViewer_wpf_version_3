using System.Collections.Generic;
using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    public class Block
    {
        [XmlAttribute("Numbers")]
        public string Numbers { get; set; } = string.Empty;
        public List<int> InternalNumbers { get; set; } = new List<int>();
        public List<Lane> Lanes { get; set; } = new List<Lane>();
    }
}