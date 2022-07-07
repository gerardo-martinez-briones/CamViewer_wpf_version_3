using System.Collections.Generic;
using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    public class Setup
    {
        [XmlAttribute("ID")]
        public int IDSetup { get; set; } = 0;
        public ButtonPosition Button { get; set; } = new ButtonPosition();
        public List<Camera> Cameras { get; set; } = new List<Camera>();
    }
}