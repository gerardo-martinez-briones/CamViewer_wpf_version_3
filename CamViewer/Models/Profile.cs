using System;

namespace CamViewer.Models
{
    public class Profile
    {
        private string _id = string.Empty;
        private string _token = string.Empty;

        public Profile(string token)
        {
            _id = Guid.NewGuid().ToString();
            _token = token;
        }

        public Profile(string id, string token)
        {
            _id = id;
            _token = token;
        }

        public string Id
        {
            get => _id;
            set => _id = value;
        }

        public string Token
        {
            get => _token;
            set => _token = value;
        }
    }
}