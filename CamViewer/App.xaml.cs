using CamViewer.Helpers;
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
            ConfigView configView;

            try
            {
                Log4Cam.Add.Info("CamViewer is Starting.");

                string[] args = Environment.GetCommandLineArgs();

                if (args.Length == 1)
                {
                    main = new Main();

                    main.Show();
                }
                else if (args.Any(x => x.ToLower().Equals("--config")))
                {
                    configView = new ConfigView();

                    configView.Show();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}