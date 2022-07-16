using AxAXVLC;
using CamViewer.Models;
using CamViewer.Views;
using System;
using System.Linq;
using System.Windows.Controls;

namespace CamViewer.UserControls
{

    public partial class LiveVideoControl : UserControl
    {
        private readonly ConfigModel ObjMainConfig;
        private readonly string StrId;
        private AxVLCPlugin2 _vlcMediaPlayer = new AxVLCPlugin2();

        public LiveVideoControl(ConfigModel ObjMainConfig, string StrId)
        {
            InitializeComponent();

            wfhContainer.Child = _vlcMediaPlayer;
            ObjMainConfig = ObjMainConfig;
            this.StrId = StrId;
        }

        private string GetMediaUrl()
        {
            return (ObjMainConfig.Groups
            .SelectMany(a => a.Devices)
            .SelectMany(b => b.Cameras).FirstOrDefault(c => c.Id.Equals(StrId))).Url;
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _vlcMediaPlayer.Toolbar = false;
            _vlcMediaPlayer.playlist.add(GetMediaUrl());
            _vlcMediaPlayer.playlist.play();
        }
    }
}
