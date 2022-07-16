namespace CamViewer.Models.Legacy
{
    public class CimData
    {
        public CimData()
        {
            CraneName = string.Empty;
            ShortCraneName = string.Empty;
            BlockNumber = string.Empty;
            IDSetup = 0;
            IDLane = 0;
            IDChassis = 0;
            IDError = 0;
            ErrorDescription = string.Empty;
        }

        public string CraneName { get; set; }
        public string ShortCraneName { get; set; }
        public string BlockNumber { get; set; }
        public int IDSetup { get; set; }
        public int IDLane { get; set; }
        public int IDChassis { get; set; }
        public int IDError { get; set; }
        public string ErrorDescription { get; set; }
    }
}