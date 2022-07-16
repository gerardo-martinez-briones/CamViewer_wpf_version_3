namespace CamViewer.Models.Legacy
{
    public class Credential
    {
        public Credential()
        {
            UserName = string.Empty;
            Password = string.Empty;
            UIMode = string.Empty;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string UIMode { get; set; }
    }
}