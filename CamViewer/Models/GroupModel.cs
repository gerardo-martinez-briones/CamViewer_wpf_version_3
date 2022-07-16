using System;
using System.Collections.Generic;
using static CamViewer.Helpers.General;

namespace CamViewer.Models
{
    public class GroupModel
    {
        public GroupModel(string StrName)
        {
            Id = Guid.NewGuid().ToString();
            Name = StrName;
            Devices = new List<DeviceModel>();
        }

        public GroupModel(string StrId, string StrName)
        {
            Id = StrId;
            Name = StrName;
            Devices = new List<DeviceModel>();
        }

        public int Type { get; set; } = (int)NodeTypeEnum.Folder_Item;
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public List<DeviceModel> Devices { get; set; } = new List<DeviceModel>();
    }
}