using CamViewer.Views;
using System;
using System.Linq;
using System.Windows;

namespace CamViewer
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Main main;
            Config config;
            string[] args = Environment.GetCommandLineArgs();

            if (args.Length == 1)
            {
                main = new Main();

                main.Show();
            }
            else if (args.Any(x => x.ToLower().Equals("--config")))
            {
                config = new Config();

                config.Show();
            }
        }
    }
}