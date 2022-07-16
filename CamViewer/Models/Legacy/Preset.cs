using System.Collections.Generic;
using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    public class Preset
    {
        public Preset()
        {
            IDPreset = 0;
            Names = string.Empty;

            InternalNames = new List<string>();
        }

        [XmlAttribute("ID")]
        public int IDPreset { get; set; }
        [XmlAttribute("Names")]
        public string Names { get; set; }

        public List<string> InternalNames { get; set; }
    }
}