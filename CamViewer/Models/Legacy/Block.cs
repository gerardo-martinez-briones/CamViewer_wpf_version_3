using System.Collections.Generic;
using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    public class Block
    {
        public Block()
        {
            Numbers = string.Empty;

            InternalNumbers = new List<int>();
            Lanes = new List<Lane>();
        }

        [XmlAttribute("Numbers")]
        public string Numbers { get; set; }

        public List<int> InternalNumbers { get; set; }
        public List<Lane> Lanes { get; set; }
    }
}