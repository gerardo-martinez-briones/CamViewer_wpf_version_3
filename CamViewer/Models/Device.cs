using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using static CamViewer.Helpers.General;

namespace CamViewer.Models
{
    public class Device
    {
        public int Type { get; set; } = (int)NodeTypeEnum.DEVICE_NODE;
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string HostName { get; set; } = string.Empty;
        public string InfoName { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public string Firmware { get; set; } = string.Empty;
        public string OnvifVersion { get; set; } = string.Empty;
        public string Uri { get; set; } = string.Empty;
        public List<Profile> Profiles { get; set; } = new List<Profile>();
        public List<OnvifCamera> Cameras { get; set; } = new List<OnvifCamera>();

        public Device(string userName, string password, string hostName)
        {
            Id = Guid.NewGuid().ToString();
            UserName = userName;
            Password = password;
            HostName = hostName;
            Profiles = new List<Profile>();
            Cameras = new List<OnvifCamera>();
        }
        public Device(string id, string userName, string password, string hostName)
        {
            Id = id;
            UserName = userName;
            Password = password;
            HostName = hostName;
            Profiles = new List<Profile>();
            Cameras = new List<OnvifCamera>();
        }
    }
}