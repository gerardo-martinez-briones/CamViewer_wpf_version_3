using System;
using static CamViewer.Helpers.General;

namespace CamViewer.Models
{
    public class ProfileModel
    {
        public ProfileModel()
        {
            Type = (int)NodeTypeEnum.Profile_Token;
            Id = Guid.NewGuid().ToString();
            Token = string.Empty;
        }

        public ProfileModel(string token)
        {
            Type = (int)NodeTypeEnum.Profile_Token;
            Id = Guid.NewGuid().ToString();
            Token = token;
        }

        public ProfileModel(string id, string token)
        {
            Type = (int)NodeTypeEnum.Profile_Token;
            Id = id;
            Token = token;
        }

        public int Type { get; set; }
        public string Id { get; set; }
        public string Token { get; set; }
    }
}