using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    public class CraneName
    {
        public CraneName()
        {
            IDCamera = 0;
            StartLimit = 0;
            FinalLimit = 0;
            Prefix = string.Empty;
            Suffix = string.Empty;
        }

        [XmlAttribute("ID")]
        public int IDCamera { get; set; }
        [XmlAttribute("StartLimit")]
        public int StartLimit { get; set; }
        [XmlAttribute("FinalLimit")]
        public int FinalLimit { get; set; }
        [XmlAttribute("Prefix")]
        public string Prefix { get; set; }
        [XmlAttribute("Suffix")]
        public string Suffix { get; set; }
    }
}