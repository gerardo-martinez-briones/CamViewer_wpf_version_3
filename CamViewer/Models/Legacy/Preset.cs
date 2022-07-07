using System.Collections.Generic;
using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    public class Preset
    {
        [XmlAttribute("ID")]
        public int IDPreset { get; set; } = 0;
        [XmlAttribute("Names")]
        public string Names { get; set; } = string.Empty;
        public List<string> InternalNames { get; set; } = new List<string>();
    }
}