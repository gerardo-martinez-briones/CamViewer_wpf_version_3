using System.Collections.Generic;

namespace CamViewer.Models
{
    public class Device
    {
        private string _id = string.Empty;
        private string _userName = string.Empty;
        private string _password = string.Empty;
        private string _hostName = string.Empty;
        private string _infoName = string.Empty;
        private string _manufacturer = string.Empty;
        private string _firmware = string.Empty;
        private string _onvifVersion = string.Empty;
        private string _uri = string.Empty;
        private List<Profile> _profiles;
        private List<CameraInfo> _cameras;

        public Device(string userName, string password, string hostName)
        {
            _userName = userName;
            _password = password;
            _hostName = hostName;

            _profiles = new List<Profile>();
            _cameras = new List<CameraInfo>();
        }

        public Device(string id, string userName, string password, string hostName)
        {
            _id = id;
            _userName = userName;
            _password = password;
            _hostName = hostName;

            _profiles = new List<Profile>();
            _cameras = new List<CameraInfo>();
        }

        public string Id
        {
            get => _id;
            set => _id = value;
        }

        public string UserName
        {
            get => _userName;
            set => _userName = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public string HostName
        {
            get => _hostName;
            set => _hostName = value;
        }

        public string InfoName
        {
            get => _infoName;
            set => _infoName = value;
        }

        public string Manufacturer
        {
            get => _manufacturer;
            set => _manufacturer = value;
        }

        public string Firmware
        {
            get => _firmware;
            set => _firmware = value;
        }

        public string OnvifVersion
        {
            get => _onvifVersion;
            set => _onvifVersion = value;
        }

        public string Uri
        {
            get => _uri;
            set => _uri = value;
        }

        public List<Profile> Profiles
        {
            get => _profiles;
            set => _profiles = value;
        }

        public List<CameraInfo> Cameras
        {
            get => _cameras;
            set => _cameras = value;
        }
    }
}