using System.Collections.Generic;
using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    [XmlRoot("Content")]
    public class XmlDoc
    {
        public XmlDoc()
        {
            MaxCameras = 0;
            TypeFile = string.Empty;
            ShortFileName = string.Empty;
            FullFileName = string.Empty;

            XmlDocFileContents = new List<XmlDocFileContent>();
        }

        public int MaxCameras { get; set; }
        public string TypeFile { get; set; }
        public string ShortFileName { get; set; }
        public string FullFileName { get; set; }

        public List<XmlDocFileContent> XmlDocFileContents { get; set; }
    }
}