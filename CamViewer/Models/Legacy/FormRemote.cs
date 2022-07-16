using System.Collections.Generic;
using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    public class FormRemote
    {
        public FormRemote()
        {
            IDForm = 0;
            Border = 0;
            BorderCamera = 0;
            OnTop = false;
            Exit = false;
            LaneDisplayType = false;

            CraneNames = new List<CraneName>();
            Location = new Location();
            Dimension = new Dimension();
        }

        [XmlAttribute("ID")]
        public int IDForm { get; set; }

        public List<CraneName> CraneNames { get; set; }
        public Location Location { get; set; }
        public Dimension Dimension { get; set; }

        public int Border { get; set; }
        public int BorderCamera { get; set; }
        public bool OnTop { get; set; }
        public bool Exit { get; set; }
        public bool LaneDisplayType { get; set; }
    }
}