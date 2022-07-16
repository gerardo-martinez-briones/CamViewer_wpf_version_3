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

        public static void ErrorManager(Exception ObjEx)
        {
            try
            {
                string GeneralError = App.Current.FindResource("GeneralError").ToString()
                    + Environment.NewLine
                    + Environment.NewLine
                    + ObjEx.Message;

                string StrProductNameAndVersion = Process.GetCurrentProcess().ProcessName + " "
                    + Assembly.GetExecutingAssembly().GetName().Version.ToString();

                Add.Error(ObjEx);

                MessageBox.Show(GeneralError, StrProductNameAndVersion, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception) { }
        }

        public static void ErrorManager(string StrErrorMessage)
        {
            try
            {
                string StrProductNameAndVersion = Process.GetCurrentProcess().ProcessName + " "
                    + Assembly.GetExecutingAssembly().GetName().Version.ToString();

                Add.Debug(StrErrorMessage);

                MessageBox.Show(StrErrorMessage, StrProductNameAndVersion, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception) { }
        }
    }
}