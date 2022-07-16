using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    public class ButtonPosition
    {
        public ButtonPosition()
        {
            Text = string.Empty;
            Visible = false;
        }

        [XmlAttribute("Text")]
        public string Text { get; set; }
        [XmlAttribute("Visible")]
        public bool Visible { get; set; }
    }
}