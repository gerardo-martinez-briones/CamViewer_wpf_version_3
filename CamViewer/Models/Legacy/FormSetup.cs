using System.Collections.Generic;
using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    public class FormSetup
    {
        [XmlAttribute("ID")]
        public int IDForm { get; set; } = 0;
        public Location Location { get; set; } = new Location();
        public Dimension Dimension { get; set; } = new Dimension();
        public bool ShowPanel { get; set; } = false;
        public int Border { get; set; } = 0;
        public int BorderCamera { get; set; } = 0;
        public int Interval { get; set; } = 0;
        public bool OnTop { get; set; } = false;
        public bool Exit { get; set; } = false;
        public bool BtnEnb { get; set; } = false;
        public bool PresetEnb { get; set; } = false;
        public bool SetPresEnb { get; set; } = false;
        public bool LaneDisplayType { get; set; } = false;
        public bool AutoHome { get; set; } = false;
        public List<Setup> Setups { get; set; } = new List<Setup>();
    }
}