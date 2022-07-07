using System.Collections.Generic;
using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    public class Lane
    {
        [XmlAttribute("ID")]
        public int IDLane { get; set; } = 0;
        public List<Position> Positions { get; set; } = new List<Position>();
    }
}