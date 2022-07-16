using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    public class CimPoint
    {
        public CimPoint()
        {
            PropertyName = string.Empty;
            DynamicPointName = string.Empty;
            Value = string.Empty;
        }

        [XmlAttribute("PropertyName")]
        public string PropertyName { get; set; }
        [XmlAttribute("DynamicPointName")]
        public string DynamicPointName { get; set; }
        public string Value { get; set; }
    }
}