using System;
using System.Collections.Generic;

namespace CamViewer.Models
{
    public class Folder
    {
        private string _id = string.Empty;
        private string _name = string.Empty;
        private List<Device> _devices;

        public Folder(string name)
        {
            _id = Guid.NewGuid().ToString();
            _name = name;

            _devices = new List<Device>();
        }

        public Folder(string id, string name)
        {
            _id = id;
            _name = name;

            _devices = new List<Device>();
        }

        public string Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public List<Device> Devices
        {
            get => _devices;
            set => _devices = value;
        }
    }
}