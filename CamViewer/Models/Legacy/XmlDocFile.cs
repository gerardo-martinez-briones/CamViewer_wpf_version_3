namespace CamViewer.Models.Legacy
{
    public class XmlDocFile
    {
        public XmlDocFile()
        {
            FullPathFileName = string.Empty;
            TypeFile = string.Empty;
            ShortFileName = string.Empty;
            CreationDate = string.Empty;
            EditDate = string.Empty;
        }

        public string FullPathFileName { get; set; }
        public string TypeFile { get; set; }
        public string ShortFileName { get; set; }
        public string CreationDate { get; set; }
        public string EditDate { get; set; }
    }
}