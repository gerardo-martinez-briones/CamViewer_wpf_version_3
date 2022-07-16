using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using static CamViewer.Helpers.General;

namespace CamViewer.Models
{
    public class DeviceModel
    {
        public DeviceModel()
        {
            Type = (int)NodeTypeEnum.Device_Item;
            Id = Guid.NewGuid().ToString();
            UserName = string.Empty;
            Password = string.Empty;
            HostName = string.Empty;
            Model = string.Empty;
            FirmwareVersion = string.Empty;
            SerialNumber = string.Empty;
            HardwareId = string.Empty;
            Uri = string.Empty;

            Profiles = new List<ProfileModel>();
            Cameras = new List<CameraModel>();
        }

        public DeviceModel(string userName, string password, string hostName)
        {
            Type = (int)NodeTypeEnum.Device_Item;
            Id = Guid.NewGuid().ToString();
            UserName = userName;
            Password = password;
            HostName = hostName;
            Model = string.Empty;
            FirmwareVersion = string.Empty;
            SerialNumber = string.Empty;
            HardwareId = string.Empty;
            Uri = string.Empty;

            Profiles = new List<ProfileModel>();
            Cameras = new List<CameraModel>();
        }

        public DeviceModel(string id, string userName, string password, string hostName)
        {
            Type = (int)NodeTypeEnum.Device_Item;
            Id = id;
            UserName = userName;
            Password = password;
            HostName = hostName;
            Model = string.Empty;
            FirmwareVersion = string.Empty;
            SerialNumber = string.Empty;
            HardwareId = string.Empty;
            Uri = string.Empty;

            Profiles = new List<ProfileModel>();
            Cameras = new List<CameraModel>();
        }

        public int Type { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string HostName { get; set; }
        public string Model { get; set; }
        public string FirmwareVersion { get; set; }
        public string SerialNumber { get; set; }
        public string HardwareId { get; set; }
        public string Uri { get; set; }

        public List<ProfileModel> Profiles { get; set; }
        public List<CameraModel> Cameras { get; set; }
    }
}