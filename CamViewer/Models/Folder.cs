using System;
using System.Collections.Generic;
using static CamViewer.Helpers.General;

namespace CamViewer.Models
{
    public class Folder
    {
        public int Type { get; set; } = (int)NodeTypeEnum.FOLDER_NODE;
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public List<Device> Devices { get; set; } = new List<Device>();

        public Folder(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Devices = new List<Device>();
        }
        public Folder(string id, string name)
        {
            Id = id;
            Name = name;
            Devices = new List<Device>();
        }
    }
}