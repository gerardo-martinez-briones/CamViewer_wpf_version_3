using AxAXVLC;
using CamViewer.Views;
using System;
using System.Linq;
using System.Windows.Controls;

namespace CamViewer.UserControls
{

    public partial class LiveVideoControl : UserControl
    {
        private AxVLCPlugin2 _vlcMediaPlayer = new AxVLCPlugin2();
        private static Config _config;

        public LiveVideoControl(Config config)
        {
            InitializeComponent();

            _config = config;

            wfhContainer.Child = _vlcMediaPlayer;


        }

        private string GetMediaUrl()
        {
            return (_config._folders
            .SelectMany(a => a.Devices)
            .SelectMany(b => b.Cameras).FirstOrDefault(c => c.Id.Equals(_config._idSelected))).MediaUrl;
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _vlcMediaPlayer.Toolbar = false;
            _vlcMediaPlayer.playlist.add(GetMediaUrl());
            _vlcMediaPlayer.playlist.play();
        }
    }
}
