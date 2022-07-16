using CamViewer.Models.Legacy;
using System.Collections.Generic;

namespace CamViewer.Models
{
    public class ConfigModel
    {
        public ConfigModel()
        {
            Groups = new List<GroupModel>();
            Devices = new List<DeviceModel>();
            Settings = new List<Settings>();
            Parameters = new ParameterModel();
        }

        public List<GroupModel> Groups { get; set; }
        public List<DeviceModel> Devices { get; set; }
        public List<Settings> Settings { get; set; }
        public ParameterModel Parameters { get; set; }
    }
}