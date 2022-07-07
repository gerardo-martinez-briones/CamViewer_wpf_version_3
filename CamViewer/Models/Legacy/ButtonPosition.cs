using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    public class ButtonPosition
    {
        [XmlAttribute("Text")]
        public string Text { get; set; } = string.Empty;
        [XmlAttribute("Visible")]
        public bool Visible { get; set; } = false;
    }
}