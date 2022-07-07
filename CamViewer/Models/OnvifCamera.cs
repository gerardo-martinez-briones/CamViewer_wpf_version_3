using System;
using static CamViewer.Helpers.General;

namespace CamViewer.Models
{
    public class OnvifCamera
    {
        public int Type { get; set; } = (int)NodeTypeEnum.CAMERA_ITEM_NODE;
        public string Id { get; set; } = string.Empty;
        public string MediaUrl { get; set; } = string.Empty;

        public OnvifCamera(string mediaUrl)
        {
            Id = Guid.NewGuid().ToString();
            MediaUrl = mediaUrl;
        }
        public OnvifCamera(string id, string mediaUrl)
        {
            Id = id;
            MediaUrl = mediaUrl;
        }
    }
}