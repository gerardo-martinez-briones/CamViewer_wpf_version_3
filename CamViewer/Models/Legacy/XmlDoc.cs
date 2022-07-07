using System.Collections.Generic;
using System.Xml.Serialization;

namespace CamViewer.Models.Legacy
{
    [XmlRoot("Content")]
    public class XmlDoc
    {
        public int MaxCameras { get; set; } = 0;
        public string TypeFile { get; set; } = string.Empty;
        public string ShortFileName { get; set; } = string.Empty;
        public string FullFileName { get; set; } = string.Empty;
        public List<XmlDocFileContent> XmlDocFileContents { get; set; } = new List<XmlDocFileContent>();
    }
}