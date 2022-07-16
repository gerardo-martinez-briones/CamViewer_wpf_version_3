using System;
using static CamViewer.Helpers.General;

namespace CamViewer.Models
{
    public class CameraModel
    {
        public CameraModel()
        {
            Id = Guid.NewGuid().ToString();
            Type = (int)NodeTypeEnum.Camera_Item;
        }

        public CameraModel(string StrUrl)
        {
            Id = Guid.NewGuid().ToString();
            Type = (int)NodeTypeEnum.Camera_Item;
            Url = StrUrl;
        }

        public CameraModel(string StrId, string StrUrl)
        {
            Id = StrId;
            Type = (int)NodeTypeEnum.Camera_Item;
            Url = StrUrl;
        }

        public int Type { get; set; }
        public string Id { get; set; }
        public string Url { get; set; }
    }
}