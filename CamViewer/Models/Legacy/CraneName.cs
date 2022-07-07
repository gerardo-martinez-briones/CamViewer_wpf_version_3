using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    public class CraneName
    {
        [XmlAttribute("ID")]
        public int IDCamera { get; set; } = 0;
        [XmlAttribute("StartLimit")]
        public int StartLimit { get; set; } = 0;
        [XmlAttribute("FinalLimit")]
        public int FinalLimit { get; set; } = 0;
        [XmlAttribute("Prefix")]
        public string Prefix { get; set; } = string.Empty;
        [XmlAttribute("Suffix")]
        public string Suffix { get; set; } = string.Empty;
    }
}