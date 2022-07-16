using System.Collections.Generic;
using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    public class Setup
    {
        public Setup()
        {
            IDSetup = 0;

            Button = new ButtonPosition();
            Cameras = new List<Camera>();
        }

        [XmlAttribute("ID")]
        public int IDSetup { get; set; }

        public ButtonPosition Button { get; set; }
        public List<Camera> Cameras { get; set; }
    }
}