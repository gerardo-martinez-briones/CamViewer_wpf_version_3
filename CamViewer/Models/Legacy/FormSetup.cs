using System.Collections.Generic;
using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    public class FormSetup
    {
        public FormSetup()
        {
            IDForm = 0;
            ShowPanel = false;
            Border = 0;
            BorderCamera = 0;
            Interval = 0;
            OnTop = false;
            Exit = false;
            BtnEnb = false;
            PresetEnb = false;
            SetPresEnb = false;
            LaneDisplayType = false;
            AutoHome= false;

            Location = new Location();
            Dimension = new Dimension();
            Setups = new List<Setup>();
        }

        [XmlAttribute("ID")]
        public int IDForm { get; set; }

        public Location Location { get; set; }
        public Dimension Dimension { get; set; }

        public bool ShowPanel { get; set; }
        public int Border { get; set; }
        public int BorderCamera { get; set; }
        public int Interval { get; set; }
        public bool OnTop { get; set; }
        public bool Exit { get; set; }
        public bool BtnEnb { get; set; }
        public bool PresetEnb { get; set; }
        public bool SetPresEnb { get; set; }
        public bool LaneDisplayType { get; set; }
        public bool AutoHome { get; set; }

        public List<Setup> Setups { get; set; }
    }
}