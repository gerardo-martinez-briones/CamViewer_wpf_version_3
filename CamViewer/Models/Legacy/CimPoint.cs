using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    public class CimPoint
    {
        [XmlAttribute("PropertyName")]
        public string PropertyName { get; set; } = string.Empty;
        [XmlAttribute("DynamicPointName")]
        public string DynamicPointName { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}