namespace CamViewer.Models.Legacy
{
    public class CameraCache
    {
        public CameraCache()
        {
            IDCamera = 0;
            CameraName = string.Empty;
            MediaUrl = string.Empty;
            Tag = string.Empty;
        }

        public int IDCamera { get; set; }
        public string CameraName { get; set; }
        public string MediaUrl { get; set; }
        public string Tag { get; set; }
    }
}