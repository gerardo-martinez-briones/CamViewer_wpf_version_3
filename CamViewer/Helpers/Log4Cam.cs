using NLog;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;

namespace CamViewer.Helpers
{
    public static class Log4Cam
    {
        public static readonly Logger Add = LogManager.GetCurrentClassLogger();

        public static void ErrorManager(Exception ex)
        {
            try
            {
                string generalError = App.Current.FindResource("StrGeneralError").ToString()
                    + Environment.NewLine
                    + Environment.NewLine
                    + ex.Message;

                string productNameAndVersion = Process.GetCurrentProcess().ProcessName + " "
                    + Assembly.GetExecutingAssembly().GetName().Version.ToString();

                Add.Error(ex);

                MessageBox.Show(generalError, productNameAndVersion, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception) { }
        }
    }
}
