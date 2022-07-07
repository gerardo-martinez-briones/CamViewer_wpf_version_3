using System;
using static CamViewer.Helpers.General;

namespace CamViewer.Models
{
    public class Profile
    {
        public int Type { get; set; } = (int)NodeTypeEnum.PROFILE_TOKEN_NODE;
        public string Id { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;

        public Profile(string token)
        {
            Id = Guid.NewGuid().ToString();
            Token = token;
        }
        public Profile(string id, string token)
        {
            Id = id;
            Token = token;
        }
    }
}