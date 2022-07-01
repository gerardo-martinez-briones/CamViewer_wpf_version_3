using System;

namespace CamViewer.Models
{
    public class CameraInfo
    {
        private string _id = string.Empty;
        private string _mediaUrl = string.Empty;

        public CameraInfo(string mediaUrl)
        {
            _id = Guid.NewGuid().ToString();
            _mediaUrl = mediaUrl;
        }

        public CameraInfo(string id, string mediaUrl)
        {
            _id = id;
            _mediaUrl = mediaUrl;
        }

        public string Id
        {
            get => _id;
            set => _id = value;
        }

        public string MediaUrl
        {
            get => _mediaUrl;
            set => _mediaUrl = value;
        }
    }
}
