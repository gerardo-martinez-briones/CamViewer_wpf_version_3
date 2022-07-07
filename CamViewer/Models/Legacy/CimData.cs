namespace CamViewer.Models.Legacy
{
    public class CimData
    {
        public string CraneName { get; set; } = string.Empty;
        public string ShortCraneName { get; set; } = string.Empty;
        public string BlockNumber { get; set; } = string.Empty;
        public int IDSetup { get; set; } = 0;
        public int IDLane { get; set; } = 0;
        public int IDChassis { get; set; } = 0;
        public int IDError { get; set; } = 0;
        public string ErrorDescription { get; set; } = string.Empty;
    }
}