using CamViewer.Helpers;
using CamViewer.Models;
using CamViewer.UserControls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace CamViewer.Views
{
    public partial class Config : Window
    {
        // ********************* variables *********************        
        private TreeViewItem _viewItemOnvif;
        private TreeViewItem _viewItemSettings;

        public List<Folder> _folders = new List<Folder>();
        public string _idSelected = string.Empty;

        public enum TypeNodeEnum
        {
            ParentOnvif = 0,
            ParentSettings = 1,
            ChildFolder = 2,
            ChildDevice = 3,
            ChildInfo = 4,
            ChildInfoName = 5,
            ChildInfoManufacturer = 6,
            ChildInfoFirmware = 7,
            ChildInfoOnvifVersion = 8,
            ChildInfoUri = 9,
            ChildHeaderProfiles = 10,
            ChildProfiles = 11,
            ChildHeaderCameras = 12,
            ChildCamera = 13
        }

        // ********************* constructors *********************
        public Config()
        {
            InitializeComponent();
        }

        // ********************* events *********************
        private void OnMenuItem_Click(object sender, RoutedEventArgs e)
        {
            string actionName = string.Empty;

            try
            {
                actionName = ((MenuItem)sender).Tag.ToString();

                switch (actionName)
                {
                    case "[NEW_FOLDER]":
                        //ctlContainer.Content = new FolderControl(this);
                        break;
                    case "[LIVE_VIDEO]":
                        ctlContainer.Content = new LiveVideoControl(this);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Log4Cam.ErrorManager(ex);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                InitializeTreeView();
                LoadConfiguration();
            }
            catch (Exception ex)
            {
                Log4Cam.ErrorManager(ex);
            }
        }

        private void TxtTitleScreen_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void BtnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string exitMessage = App.Current.FindResource("StrCloseApplicationQuestion").ToString();

                string productNameAndVersion = Process.GetCurrentProcess().ProcessName + " "
                    + Assembly.GetExecutingAssembly().GetName().Version.ToString();

                MessageBoxResult result = MessageBox.Show(exitMessage, productNameAndVersion, MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                    Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                Log4Cam.ErrorManager(ex);
            }
        }

        private void TvwMainConfig_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeView x = (TreeView)sender;

            TreeViewItem y = (TreeViewItem)x.SelectedItem;

            _idSelected = y.Uid;
        }

        // ********************* methods *********************
        private void InitializeTreeView()
        {
            try
            {
                //tvwMainConfig.Items.Clear();

                _viewItemOnvif = new TreeViewItem();
                _viewItemSettings = new TreeViewItem();

                _viewItemOnvif = BuildViewItem(TypeNodeEnum.ParentOnvif, "0", "Onvif Devices", (Image)App.Current.FindResource("ImgOnvif"));
                _viewItemSettings = BuildViewItem(TypeNodeEnum.ParentSettings, "1", "Settings", (Image)App.Current.FindResource("ImgSettings"));

                tvwMainConfig.Items.Add(_viewItemOnvif);
                tvwMainConfig.Items.Add(_viewItemSettings);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadConfiguration()
        {
            // ********* test code *********
            if (_folders.Count == 0)
            {
                // load data....
                _folders.Add(new Folder("Fence"));
                _folders[0].Devices.Add(new Device("root", "Pass123!", "169.254.195.178"));
                _folders[0].Devices[0].Profiles.Add(new Profile("User Profile01"));
                _folders[0].Devices[0].Profiles.Add(new Profile("User Profile02"));
                _folders[0].Devices[0].Profiles.Add(new Profile("User Profile03"));
                _folders[0].Devices[0].Profiles.Add(new Profile("User Profile04"));
                _folders[0].Devices[0].Profiles.Add(new Profile("User Profile05"));
                _folders[0].Devices[0].Profiles.Add(new Profile("User Profile06"));
                _folders[0].Devices[0].Profiles.Add(new Profile("User Profile07"));
                _folders[0].Devices[0].Profiles.Add(new Profile("User Profile08"));
                _folders[0].Devices[0].Cameras.Add(new Camera("rtsp://root:Pass123!@169.254.195.178:554/live?pf=11&pt=tcp"));
                _folders[0].Devices[0].Cameras.Add(new Camera("rtsp://root:Pass123!@169.254.195.178:554/live?pf=17&pt=tcp"));

                _folders.Add(new Folder("Spreader"));
                _folders[1].Devices.Add(new Device("root", "Pass123!", "169.254.113.207"));
                _folders[1].Devices[0].Profiles.Add(new Profile("profile_1 h264"));
                _folders[1].Devices[0].Profiles.Add(new Profile("profile_1 jpeg"));
                _folders[1].Devices[0].Cameras.Add(new Camera("rtsp://root:Pass123!@169.254.113.207/onvif-media/media.amp?profile=profile_1_h264&sessiontimeout=60&streamtype=unicast"));

                _folders.Add(new Folder("Trolley PTZ"));
            }

            // ********* test code *********
            //InitializeTreeView();



            foreach (Folder folderItem in _folders)
            {
                TreeViewItem viewFolderItem = BuildViewItem(TypeNodeEnum.ChildFolder, folderItem.Id, folderItem.Name, (Image)App.Current.FindResource("ImgFolder"));

                foreach (Device deviceItem in folderItem.Devices)
                {
                    TreeViewItem viewDeviceItem = BuildViewItem(TypeNodeEnum.ChildDevice, deviceItem.Id, deviceItem.HostName, (Image)App.Current.FindResource("ImgDevice"));

                    TreeViewItem viewInfoHeaderItem = BuildViewItem(TypeNodeEnum.ChildInfo, deviceItem.Id, "Information", (Image)App.Current.FindResource("ImgInfo"));
                    TreeViewItem viewInfoNameItem = BuildViewItem(TypeNodeEnum.ChildInfoName, deviceItem.Id, "Name: " + deviceItem.InfoName.Trim());
                    TreeViewItem viewInfoManufacturerItem = BuildViewItem(TypeNodeEnum.ChildInfoManufacturer, deviceItem.Id, "Manufacturer: " + deviceItem.Manufacturer.Trim());
                    TreeViewItem viewInfoFirmwareItem = BuildViewItem(TypeNodeEnum.ChildInfoFirmware, deviceItem.Id, "Firmware: " + deviceItem.Firmware.Trim());
                    TreeViewItem viewInfoOnvifVersionItem = BuildViewItem(TypeNodeEnum.ChildInfoOnvifVersion, deviceItem.Id, "Onvif Version: " + deviceItem.OnvifVersion.Trim());
                    TreeViewItem viewInfoUriItem = BuildViewItem(TypeNodeEnum.ChildInfoUri, deviceItem.Id, "Uri: " + deviceItem.Uri.Trim());

                    TreeViewItem viewProfilesHeaderItem = BuildViewItem(TypeNodeEnum.ChildHeaderProfiles, deviceItem.Id, "Profiles", (Image)App.Current.FindResource("ImgProfiles"));

                    foreach (Profile profileItem in deviceItem.Profiles)
                    {
                        TreeViewItem viewProfilesItem = BuildViewItem(TypeNodeEnum.ChildProfiles, profileItem.Id, "Token: " + profileItem.Token);

                        viewProfilesHeaderItem.Items.Add(viewProfilesItem);
                    }

                    TreeViewItem viewCamerasHeaderItem = BuildViewItem(TypeNodeEnum.ChildHeaderCameras, deviceItem.Id, "Cameras", (Image)App.Current.FindResource("ImgCameras"));

                    foreach (Camera cameraInfoItem in deviceItem.Cameras)
                    {
                        TreeViewItem viewCameraInfoItem = BuildViewItem(TypeNodeEnum.ChildCamera, cameraInfoItem.Id, cameraInfoItem.MediaUrl);

                        viewCamerasHeaderItem.Items.Add(viewCameraInfoItem);
                    }

                    viewInfoHeaderItem.Items.Add(viewInfoNameItem);
                    viewInfoHeaderItem.Items.Add(viewInfoManufacturerItem);
                    viewInfoHeaderItem.Items.Add(viewInfoFirmwareItem);
                    viewInfoHeaderItem.Items.Add(viewInfoOnvifVersionItem);
                    viewInfoHeaderItem.Items.Add(viewInfoUriItem);

                    viewDeviceItem.Items.Add(viewInfoHeaderItem);
                    viewDeviceItem.Items.Add(viewProfilesHeaderItem);
                    viewDeviceItem.Items.Add(viewCamerasHeaderItem);
                    viewFolderItem.Items.Add(viewDeviceItem);
                }


                _viewItemOnvif.Items.Add(viewFolderItem);
            }            
        }

        private TreeViewItem BuildViewItem(TypeNodeEnum type, string id, string headerText, Image icon = null)
        {
            TreeViewItem result;

            try
            {
                result = new TreeViewItem();

                result.IsExpanded = false;
                result.Header = BuildHeaderItem(headerText, icon);
                result.Uid = id;
                result.Tag = type;
                result.ContextMenu = BuildContextMenu(type);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        private StackPanel BuildHeaderItem(string headerText, Image icon = null)
        {
            StackPanel result;
            Image image;
            TextBlock text;
            Thickness margin;

            try
            {
                result = new StackPanel();
                image = new Image();
                text = new TextBlock();
                margin = new Thickness(5, 0, 0, 0);

                result.Orientation = Orientation.Horizontal;
                
                text.Text = headerText;
                text.Margin = margin;
                text.VerticalAlignment = VerticalAlignment.Center;

                if (icon != null)
                {
                    image.Source = icon.Source;
                    result.Children.Add(image);
                }
                
                result.Children.Add(text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        private ContextMenu BuildContextMenu(TypeNodeEnum type)
        {
            ContextMenu result;

            try
            {
                result = new ContextMenu();

            // = 5,
            // = 6,
            // = 7,
            // = 8,
            // = 9,
            //ChildHeaderProfiles = 10,
            //ChildProfiles = 11,
            //ChildHeaderCameras = 12,
            //ChildCamera = 12

                switch (type)
                {
                    case TypeNodeEnum.ParentOnvif:
                        result.Items.Add(BuildMenuItem("Add Folder", "[NEW_FOLDER]"));
                        result.Items.Add(BuildMenuItem("Add Devices", "[NEW_DEVICE]"));
                        break;
                    case TypeNodeEnum.ParentSettings:
                        break;
                    case TypeNodeEnum.ChildFolder:
                        result.Items.Add(BuildMenuItem("Add Devices", "[NEW_DEVICE]"));
                        break;
                    case TypeNodeEnum.ChildDevice:
                        result.Items.Add(BuildMenuItem("Get Data", "[GET_DATA]"));
                        break;
                    case TypeNodeEnum.ChildInfo:
                        break;
                    case TypeNodeEnum.ChildInfoName:
                        break;
                    case TypeNodeEnum.ChildInfoManufacturer:
                        break;
                    case TypeNodeEnum.ChildInfoFirmware:
                        break;
                    case TypeNodeEnum.ChildInfoOnvifVersion:
                        break;
                    case TypeNodeEnum.ChildInfoUri:
                        break;
                    case TypeNodeEnum.ChildHeaderProfiles:
                        break;
                    case TypeNodeEnum.ChildProfiles:
                        break;
                    case TypeNodeEnum.ChildHeaderCameras:
                        break;
                    case TypeNodeEnum.ChildCamera:
                        result.Items.Add(BuildMenuItem("Live Video", "[LIVE_VIDEO]"));
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        private MenuItem BuildMenuItem(string headerText, string actionName)
        {
            MenuItem result;

            try
            {
                result = new MenuItem();

                result.Header = headerText;
                result.Click += OnMenuItem_Click;
                result.Tag = actionName;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public void AddFolder(Folder folder)
        {
            try
            {
                _folders.Add(folder);
                LoadConfiguration();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void TvwMainConfig_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            TreeView view = (TreeView)sender;

            if (view.SelectedItem == null)
                e.Handled = true;
        }
    }
}