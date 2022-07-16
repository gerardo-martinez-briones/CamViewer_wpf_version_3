using System.Collections.Generic;
using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    public class Lane
    {
        public Lane()
        {
            IDLane = 0;

            Positions = new List<Position>();
        }

        [XmlAttribute("ID")]
        public int IDLane { get; set; }

        public List<Position> Positions { get; set; }
    }
}