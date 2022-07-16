using AxAXVLC;
using System.Windows.Controls;

namespace CtrlOnvifCamera
{
    public partial class Camera : UserControl
    {
        private readonly string strUrl;
        AxVLCPlugin2 _vlc = new AxVLCPlugin2();

        public Camera(string StrUrl)
        {
            InitializeComponent();
            wfContainer.Child = _vlc;
            strUrl = StrUrl;
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _vlc.Toolbar = false;
            _vlc.playlist.add(strUrl);
            _vlc.playlist.play();
        }
    }
}
