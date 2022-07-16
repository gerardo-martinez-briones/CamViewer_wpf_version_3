using CamViewer.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using static CamViewer.Helpers.General;

namespace CamViewer.Views
{
    public partial class ConfigView : Window
    {
        private ConfigModel _mainConfig;
        private TreeViewItem _viewItemRootHeader;
        private TreeViewItem _viewItemOnvifHeader;
        private TreeViewItem _viewItemSettingsHeader;
        private TreeViewItem _viewItemSelected;

        public ConfigView()
        {
            InitializeComponent();

            _mainConfig = new ConfigModel();
            _viewItemRootHeader = new TreeViewItem();
            _viewItemOnvifHeader = new TreeViewItem();
            _viewItemSettingsHeader = new TreeViewItem();

            InitializeTreeView();
            LoadMainConfiguration();
            LoadTreeView();
        }

        private void InitializeTreeView()
        {
            try
            {
                _viewItemRootHeader = CreateNode((int)NodeTypeEnum.Root_Header, Guid.NewGuid().ToString());
                _viewItemOnvifHeader = CreateNode((int)NodeTypeEnum.Onvif_Header, Guid.NewGuid().ToString());
                _viewItemSettingsHeader = CreateNode((int)NodeTypeEnum.Settings_Header, Guid.NewGuid().ToString());

                TreeViewItem viewItemOnvifParametersHeader = CreateNode((int)NodeTypeEnum.Onvif_Parameters_Header, Guid.NewGuid().ToString());
                TreeViewItem viewItemOnvifParametersInterval = CreateNode((int)NodeTypeEnum.Onvif_Parameters_Interval, Guid.NewGuid().ToString(), _mainConfig.Parameters.IntervalDiscovery.ToString());

                viewItemOnvifParametersHeader.Items.Add(viewItemOnvifParametersInterval);
                _viewItemOnvifHeader.Items.Add(viewItemOnvifParametersHeader);

                _viewItemRootHeader.Items.Add(_viewItemOnvifHeader);
                _viewItemRootHeader.Items.Add(_viewItemSettingsHeader);

                TvwMainConfig.Items.Add(_viewItemRootHeader);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadMainConfiguration()
        {
            try
            {
                _mainConfig.Groups.Add(new GroupModel("Fence"));
                _mainConfig.Groups.Add(new GroupModel("Spreader"));
                _mainConfig.Groups.Add(new GroupModel("Trolley PTZ"));

                _mainConfig.Groups[0].Devices.Add(new DeviceModel("root", "Pass123!", "ASC01LTPTZ1"));
                _mainConfig.Groups[0].Devices.Add(new DeviceModel("root", "Pass123!", "ASC01LVSPR"));

                _mainConfig.Groups[0].Devices[0].Profiles.Add(new ProfileModel("profile_1 h264"));
                _mainConfig.Groups[0].Devices[0].Profiles.Add(new ProfileModel("profile_1 jpeg"));

                _mainConfig.Groups[0].Devices[1].Profiles.Add(new ProfileModel("User Profile01"));
                _mainConfig.Groups[0].Devices[1].Profiles.Add(new ProfileModel("User Profile02"));
                _mainConfig.Groups[0].Devices[1].Profiles.Add(new ProfileModel("User Profile03"));
                _mainConfig.Groups[0].Devices[1].Profiles.Add(new ProfileModel("User Profile04"));
                _mainConfig.Groups[0].Devices[1].Profiles.Add(new ProfileModel("User Profile05"));
                _mainConfig.Groups[0].Devices[1].Profiles.Add(new ProfileModel("User Profile06"));
                _mainConfig.Groups[0].Devices[1].Profiles.Add(new ProfileModel("User Profile07"));
                _mainConfig.Groups[0].Devices[1].Profiles.Add(new ProfileModel("User Profile08"));

                _mainConfig.Groups[0].Devices[1].Cameras.Add(new CameraModel("rtsp://root:Pass123!@169.254.195.178:554/live?pf=11&pt=tcp"));
                _mainConfig.Groups[0].Devices[1].Cameras.Add(new CameraModel("rtsp://root:Pass123!@169.254.195.178:554/live?pf=17&pt=tcp"));

                _mainConfig.Devices.Add(new DeviceModel("root", "Pass123!", "192.168.87.100"));
                _mainConfig.Devices.Add(new DeviceModel("root", "Pass123!", "192.168.87.150"));
                _mainConfig.Devices.Add(new DeviceModel("root", "Pass123!", "192.168.87.170"));
                _mainConfig.Devices.Add(new DeviceModel("root", "Pass123!", "192.168.87.190"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadTreeView()
        {
            try
            {
                foreach (GroupModel itemGroup in _mainConfig.Groups)
                {
                    TreeViewItem _viewItemGroup = CreateNode(itemGroup.Type, itemGroup.Id, itemGroup.Name);

                    foreach (DeviceModel itemDevice in itemGroup.Devices)
                    {
                        TreeViewItem _viewItemDevice = CreateDeviceNode(itemDevice);
                        _viewItemGroup.Items.Add(_viewItemDevice);
                    }

                    _viewItemOnvifHeader.Items.Add(_viewItemGroup);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private TreeViewItem CreateNode(int type, string id, string caption = "")
        {
            TreeViewItem result = new TreeViewItem();

            try
            {
                result.Header = CreateHeader(type, caption);
                result.ContextMenu = CreateContextMenu((NodeTypeEnum)type);
                result.Uid = id;
                result.Tag = (int)type;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        private TreeViewItem CreateDeviceNode(DeviceModel source)
        {
            TreeViewItem result = new TreeViewItem();

            try
            {
                result = CreateNode(source.Type, source.Id, source.HostName);

                TreeViewItem viewItemInfoHeader = CreateNode((int)NodeTypeEnum.Info_Header, source.Id);
                TreeViewItem viewItemProfileHeader = CreateNode((int)NodeTypeEnum.Profile_Header, source.Id);
                TreeViewItem viewItemCameraHeader = CreateNode((int)NodeTypeEnum.Camera_Header, source.Id);

                TreeViewItem viewItemInfoModel = CreateNode((int)NodeTypeEnum.Info_Model, source.Id, source.Model);
                TreeViewItem viewItemInfoFirmwareVersion = CreateNode((int)NodeTypeEnum.Info_FirmwareVersion, source.Id, source.FirmwareVersion);
                TreeViewItem viewItemInfoSerialNumber = CreateNode((int)NodeTypeEnum.Info_SerialNumber, source.Id, source.SerialNumber);
                TreeViewItem viewItemInfoHardwareId = CreateNode((int)NodeTypeEnum.Info_HardwareId, source.Id, source.HardwareId);
                TreeViewItem viewItemInfoUri = CreateNode((int)NodeTypeEnum.Info_Uri, source.Id, source.Uri);

                if (!string.IsNullOrEmpty(source.Model))
                    viewItemInfoHeader.Items.Add(viewItemInfoModel);

                if (!string.IsNullOrEmpty(source.FirmwareVersion))
                    viewItemInfoHeader.Items.Add(viewItemInfoFirmwareVersion);

                if (!string.IsNullOrEmpty(source.SerialNumber))
                    viewItemInfoHeader.Items.Add(viewItemInfoSerialNumber);

                if (!string.IsNullOrEmpty(source.HardwareId))
                    viewItemInfoHeader.Items.Add(viewItemInfoHardwareId);

                if (!string.IsNullOrEmpty(source.Uri))
                    viewItemInfoHeader.Items.Add(viewItemInfoUri);

                foreach (ProfileModel itemProfile in source.Profiles)
                {
                    TreeViewItem viewItemProfile = CreateNode(itemProfile.Type, itemProfile.Id, itemProfile.Token);
                    viewItemProfileHeader.Items.Add(viewItemProfile);
                }

                foreach (CameraModel itemCamera in source.Cameras)
                {
                    TreeViewItem viewItemProfile = CreateNode(itemCamera.Type, itemCamera.Id, itemCamera.Url);
                    viewItemCameraHeader.Items.Add(viewItemProfile);
                }

                result.Items.Add(viewItemInfoHeader);
                result.Items.Add(viewItemProfileHeader);
                result.Items.Add(viewItemCameraHeader);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        private StackPanel CreateHeader(int type, string caption)
        {
            StackPanel result = new StackPanel();
            TextBlock textblock = new TextBlock();
            Image image = null;
            Thickness margin = new Thickness(5, 0, 0, 0);

            try
            {
                result.Orientation = Orientation.Horizontal;

                textblock.Text = caption;
                textblock.VerticalAlignment = VerticalAlignment.Center;
                textblock.Margin = margin;

                if (App.Current.Resources.Contains("Caption_" + type.ToString()))
                {
                    textblock.Text = App.Current.FindResource("Caption_" + type.ToString()).ToString();
                    textblock.Text += " " + caption;
                }

                if (App.Current.Resources.Contains("Image_" + type.ToString()))
                {
                    Image imageTempo = (Image)App.Current.FindResource("Image_" + type.ToString());

                    if (imageTempo != null)
                    {
                        image = new Image();
                        image.Source = imageTempo.Source;

                        result.Children.Add(image);
                    }
                }

                result.Children.Add(textblock);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        private ContextMenu CreateContextMenu(NodeTypeEnum type)
        {
            ContextMenu result = new ContextMenu();

            try
            {
                switch (type)
                {
                    case NodeTypeEnum.Other:
                        break;
                    case NodeTypeEnum.Root_Header:
                        result.Items.Add(CreateMenuItem((int)ActionEnum.Import_Global_Config));
                        result.Items.Add(CreateMenuItem((int)ActionEnum.Export_Global_Config));
                        result.Items.Add(CreateMenuItem((int)ActionEnum.Save_Global_Config));
                        break;
                    case NodeTypeEnum.Onvif_Header:
                        break;
                    case NodeTypeEnum.Folder_Item:
                        break;
                    case NodeTypeEnum.Device_Item:
                        break;
                    case NodeTypeEnum.Info_Header:
                        break;
                    case NodeTypeEnum.Info_Model:
                        break;
                    case NodeTypeEnum.Info_FirmwareVersion:
                        break;
                    case NodeTypeEnum.Info_SerialNumber:
                        break;
                    case NodeTypeEnum.Info_HardwareId:
                        break;
                    case NodeTypeEnum.Info_Uri:
                        break;
                    case NodeTypeEnum.Profile_Header:
                        break;
                    case NodeTypeEnum.Profile_Token:
                        break;
                    case NodeTypeEnum.Camera_Header:
                        break;
                    case NodeTypeEnum.Camera_Item:
                        break;
                    case NodeTypeEnum.Settings_Header:
                        break;
                    case NodeTypeEnum.Settings_File_Name:
                        break;
                    case NodeTypeEnum.Settings_Parameters_Header:
                        break;
                    case NodeTypeEnum.Settings_Blocks_Header:
                        break;
                    case NodeTypeEnum.Settings_Credentials_Header:
                        break;
                    case NodeTypeEnum.Settings_CameraTypes_Header:
                        break;
                    case NodeTypeEnum.Settings_Presets_Header:
                        break;
                    case NodeTypeEnum.Settings_CimplicityPoints_Header:
                        break;
                    case NodeTypeEnum.Settings_Forms_Header:
                        break;
                    case NodeTypeEnum.Settings_FormsRemote_Header:
                        break;
                    case NodeTypeEnum.Onvif_Parameters_Header:
                        break;
                    case NodeTypeEnum.Onvif_Parameters_Interval:
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

        private MenuItem CreateMenuItem(int action)
        {
            MenuItem result = new MenuItem();

            try
            {
                if (App.Current.Resources.Contains("ActionName_" + action.ToString()))
                    result.Header = App.Current.FindResource("ActionName_" + action.ToString()).ToString();

                result.Tag = (ActionEnum)action;
                result.Click += OnMenuItem_Click;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        private void TvwMainConfig_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            TreeView treeView = (TreeView)sender;
            TreeViewItem viewItem = (TreeViewItem)treeView.SelectedItem;

            if (viewItem == null)
            {
                e.Handled = true;
                return;
            }
                
            if (viewItem.ContextMenu.Items.Count == 0)
                e.Handled = true;
            else
            {
                _viewItemSelected = viewItem;

                if ((NodeTypeEnum)viewItem.Tag == NodeTypeEnum.Root_Header)
                {
                    foreach (MenuItem itemMenu in viewItem.ContextMenu.Items)
                    {
                        if ((ActionEnum)itemMenu.Tag == ActionEnum.Export_Global_Config)
                        {
                            itemMenu.IsEnabled = (_mainConfig.Devices.Count > 0 ||
                                _mainConfig.Groups.Count > 0 || _mainConfig.Settings.Count > 0);
                        }
                    }
                }
            }
        }

        private void OnMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem;

            try
            {
                menuItem = (MenuItem)sender;

                ActionEnum action = (ActionEnum)menuItem.Tag;

                switch (action)
                {
                    case ActionEnum.Import_Global_Config:
                        break;
                    case ActionEnum.Export_Global_Config:
                        ExportGlobalConfig();
                        break;
                    case ActionEnum.Save_Global_Config:
                        break;
                    case ActionEnum.Enable_Mode_Discovery:
                        break;
                    case ActionEnum.New_Folder:
                        break;
                    case ActionEnum.Edit_Folder:
                        break;
                    case ActionEnum.Delete_Folder:
                        break;
                    case ActionEnum.New_Device:
                        break;
                    case ActionEnum.Edit_Device:
                        break;
                    case ActionEnum.Delete_Device:
                        break;
                    case ActionEnum.Get_Onvif_Info:
                        break;
                    case ActionEnum.Import_File:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                menuItem = null;
            }
        }

        private void ExportGlobalConfig()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            JsonSerializer jsonSerializer = new JsonSerializer();
            string fileNamePath = string.Empty;

            try
            {
                saveDialog.DefaultExt = "json";
                saveDialog.Filter = "json files (*.json)|*.json|Json files (*.json)|*.json";

                if (saveDialog.ShowDialog() == true)
                {
                    fileNamePath = saveDialog.FileName;

                    using (StreamWriter sw = new StreamWriter(@fileNamePath))
                    using (JsonWriter writer = new JsonTextWriter(sw))
                    {
                        jsonSerializer.Serialize(writer, _mainConfig);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                saveDialog = null;
                jsonSerializer = null;
            }
        }
    }
}