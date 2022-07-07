using CamViewer.Models.Legacy;
using System.Collections.Generic;

namespace CamViewer.Models
{
    public class Config
    {
        public List<Folder> Folders { get; set; } = new List<Folder>();
        public List<Device> Devices { get; set; } = new List<Device>();
        public List<Settings> Settings { get; set; } = new List<Settings>();
    }
}