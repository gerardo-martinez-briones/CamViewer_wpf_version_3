using CamViewer.Helpers;
using CamViewer.Models;
using CamViewer.Views;
using System;
using System.Windows;
using System.Windows.Controls;

namespace CamViewer.UserControls
{
    public partial class FolderControl : UserControl
    {
        private Config _config;

        public FolderControl(Config config)
        {
            InitializeComponent();
            _config = config;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtName.Focus();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Folder currentFolder;

            try
            {
                currentFolder = new Folder(txtName.Text.Trim());

                _config.AddFolder(currentFolder);
                BtnClose_Click(sender, e);
            }
            catch (Exception ex)
            {
                Log4Cam.ErrorManager(ex);
            }
            finally
            {
                currentFolder = null;
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            _config.ctlContainer.Content = null;
            _config.tvwMainConfig.IsEnabled = true;
        }
    }
}