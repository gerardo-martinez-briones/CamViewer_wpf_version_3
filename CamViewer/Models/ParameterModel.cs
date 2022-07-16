namespace CamViewer.Models
{
    public class ParameterModel
    {
        public ParameterModel()
        {
            IntervalDiscovery = 30;
        }

        public ParameterModel(int intervalDiscovery)
        {
            IntervalDiscovery = intervalDiscovery;
        }

        public int IntervalDiscovery { get; set; }
    }
}
