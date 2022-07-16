namespace CamViewer.Models.Legacy
{
    public class XmlDocFileContent
    {
        public XmlDocFileContent()
        {
            IDCamera = 0;
            MediaUrl_T = string.Empty;
            MediaUrl_F = string.Empty;
        }

        public int IDCamera { get; set; }
        public string MediaUrl_T { get; set; }
        public string MediaUrl_F { get; set; }
    }
}