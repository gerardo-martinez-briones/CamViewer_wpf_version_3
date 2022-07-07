using System.Collections.Generic;
using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    public class FormRemote
    {
        [XmlAttribute("ID")]
        public int IDForm { get; set; } = 0;
        public List<CraneName> CraneNames { get; set; } = new List<CraneName>();
        public Location Location { get; set; } = new Location();
        public Dimension Dimension { get; set; } = new Dimension();
        public int Border { get; set; } = 0;
        public int BorderCamera { get; set; } = 0;
        public bool OnTop { get; set; } = false;
        public bool Exit { get; set; } = false;
        public bool LaneDisplayType { get; set; } = false;
    }
}