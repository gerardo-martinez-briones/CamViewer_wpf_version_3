using CamViewer.Helpers;
using CamViewer.Models;
using CamViewer.Models.Legacy;
using CamViewer.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using static CamViewer.Helpers.General;

namespace CamViewer.Views
{
    public partial class ConfigView : Window
    {
        private TreeViewItem _rootNode;
        private TreeViewItem _onvifNode;
        private TreeViewItem _settingsNode;
        private TreeViewItem _selectedNode;
        private Config _config;

        public ConfigView()
        {
            InitializeComponent();

            _rootNode = new TreeViewItem();
            _onvifNode = new TreeViewItem();
            _settingsNode = new TreeViewItem();
            _config = new Config();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
            BuildTreeView();
        }
        private void TvwMainConfig_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            _selectedNode = (TreeViewItem)((TreeView)sender).SelectedItem;
        }

        private void LoadData()
        {
            _config.Folders.Add(new Folder("Fence"));
            _config.Folders.Add(new Folder("Spreader"));
            _config.Folders.Add(new Folder("Trolley PTZ"));

            _config.Folders[0].Devices.Add(new Device("root", "Pass123!", "169.254.113.207"));
            _config.Folders[0].Devices.Add(new Device("root", "Pass123!", "169.254.195.178"));
            _config.Folders[0].Devices.Add(new Device("root", "Pass123!", "169.254.113.106"));

            _config.Folders[0].Devices[0].Profiles.Add(new Profile("profile_1 h264"));
            _config.Folders[0].Devices[0].Profiles.Add(new Profile("profile_1 jpeg"));

            _config.Folders[0].Devices[1].Profiles.Add(new Profile("User Profile01"));
            _config.Folders[0].Devices[1].Profiles.Add(new Profile("User Profile02"));
            _config.Folders[0].Devices[1].Profiles.Add(new Profile("User Profile03"));
            _config.Folders[0].Devices[1].Profiles.Add(new Profile("User Profile04"));
            _config.Folders[0].Devices[1].Profiles.Add(new Profile("User Profile05"));
            _config.Folders[0].Devices[1].Profiles.Add(new Profile("User Profile06"));
            _config.Folders[0].Devices[1].Profiles.Add(new Profile("User Profile07"));
            _config.Folders[0].Devices[1].Profiles.Add(new Profile("User Profile08"));

            _config.Folders[0].Devices[1].Cameras.Add(new OnvifCamera("rtsp://root:Pass123!@169.254.195.178:554/live?pf=11&pt=tcp"));
            _config.Folders[0].Devices[1].Cameras.Add(new OnvifCamera("rtsp://root:Pass123!@169.254.195.178:554/live?pf=17&pt=tcp"));

            _config.Devices.Add(new Device("root", "Pass123!", "192.168.87.100"));
            _config.Devices.Add(new Device("root", "Pass123!", "192.168.87.150"));
            _config.Devices.Add(new Device("root", "Pass123!", "192.168.87.170"));
            _config.Devices.Add(new Device("root", "Pass123!", "192.168.87.190"));
        }
        private void BuildTreeView()
        {
            try
            {
                _rootNode = BuildTreeViewItem(NodeTypeEnum.ROOT_NODE, Guid.NewGuid().ToString(), General.GetResource("StrRootNodeCaption").ToString(), (Image)General.GetResource("ImgRootNode"));
                _onvifNode = BuildTreeViewItem(NodeTypeEnum.ONVIF_NODE, Guid.NewGuid().ToString(), General.GetResource("StrOnvifNodeCaption").ToString(), (Image)General.GetResource("ImgOnvifNode"));
                _settingsNode = BuildTreeViewItem(NodeTypeEnum.SETTINGS_NODE, Guid.NewGuid().ToString(), General.GetResource("StrSettingsNodeCaption").ToString(), (Image)General.GetResource("ImgSettingsNode"));

                // *** dynamics branchs folders
                foreach (Folder itemFolder in _config.Folders)
                {
                    TreeViewItem folderNode = BuildTreeViewItem((NodeTypeEnum)itemFolder.Type, itemFolder.Id, itemFolder.Name, (Image)General.GetResource("ImgFolderNode"));

                    List<TreeViewItem> devicesFromFolder = BuildNodeDevices(itemFolder.Devices);
                    foreach (TreeViewItem itemView in devicesFromFolder)
                        folderNode.Items.Add(itemView);

                    _onvifNode.Items.Add(folderNode);
                }

                // *** dynamics branchs devices
                List<TreeViewItem> devices = BuildNodeDevices(_config.Devices);
                foreach (TreeViewItem itemView in devices)
                    _onvifNode.Items.Add(itemView);

                // *** dynamics branchs settings
                foreach (Settings itemSettings in _config.Settings)
                {

                }

                _rootNode.Items.Add(_onvifNode);
                _rootNode.Items.Add(_settingsNode);

                tvwMainConfig.Items.Add(_rootNode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private List<TreeViewItem> BuildNodeDevices(List<Device> devices)
        {
            List<TreeViewItem> result;

            try
            {
                result = new List<TreeViewItem>();

                foreach (Device itemDevice in devices)
                {
                    TreeViewItem deviceNode = BuildTreeViewItem((NodeTypeEnum)itemDevice.Type, itemDevice.Id, itemDevice.HostName, (Image)General.GetResource("ImgDeviceNode"));
                    TreeViewItem infoHeaderNode = BuildTreeViewItem(NodeTypeEnum.INFO_NODE, itemDevice.Id, General.GetResource("StrInfoHeaderNodeCaption").ToString(), (Image)General.GetResource("ImgInfoNode"));
                    TreeViewItem profileHeaderNode = BuildTreeViewItem(NodeTypeEnum.PROFILE_NODE, itemDevice.Id, General.GetResource("StrProfileHeaderNodeCaption").ToString(), (Image)General.GetResource("ImgProfileNode"));
                    TreeViewItem cameraHeaderNode = BuildTreeViewItem(NodeTypeEnum.CAMERA_NODE, itemDevice.Id, General.GetResource("StrCameraHeaderNodeCaption").ToString(), (Image)General.GetResource("ImgCameraNode"));

                    if (!string.IsNullOrWhiteSpace(itemDevice.InfoName))
                    {
                        TreeViewItem infoNameNode = BuildTreeViewItem(NodeTypeEnum.NONE, itemDevice.Id, General.GetResource("StrInfoNameNodeCaption").ToString());
                        infoHeaderNode.Items.Add(infoNameNode);
                    }

                    if (!string.IsNullOrWhiteSpace(itemDevice.Manufacturer))
                    {
                        TreeViewItem infoManufacturerNode = BuildTreeViewItem(NodeTypeEnum.NONE, itemDevice.Id, General.GetResource("StrInfoManufacturerNodeCaption").ToString());
                        infoHeaderNode.Items.Add(infoManufacturerNode);
                    }

                    if (!string.IsNullOrWhiteSpace(itemDevice.Firmware))
                    {
                        TreeViewItem infoFirmwareNode = BuildTreeViewItem(NodeTypeEnum.NONE, itemDevice.Id, General.GetResource("StrInfoFirmwareNodeCaption").ToString());
                        infoHeaderNode.Items.Add(infoFirmwareNode);
                    }

                    if (!string.IsNullOrWhiteSpace(itemDevice.OnvifVersion))
                    {
                        TreeViewItem infoOnvifVersionNode = BuildTreeViewItem(NodeTypeEnum.NONE, itemDevice.Id, General.GetResource("StrInfoOnvifVersionNodeCaption").ToString());
                        infoHeaderNode.Items.Add(infoOnvifVersionNode);
                    }

                    if (!string.IsNullOrWhiteSpace(itemDevice.Uri))
                    {
                        TreeViewItem infoUriNode = BuildTreeViewItem(NodeTypeEnum.NONE, itemDevice.Id, General.GetResource("StrInfoUriNodeCaption").ToString());
                        infoHeaderNode.Items.Add(infoUriNode);
                    }

                    foreach (Profile itemProfile in itemDevice.Profiles)
                    {
                        TreeViewItem profileTokenNode = BuildTreeViewItem((NodeTypeEnum)itemProfile.Type, itemProfile.Id, itemProfile.Token, (Image)General.GetResource("ImgProfileTokenNode"));
                        profileHeaderNode.Items.Add(profileTokenNode);
                    }

                    foreach (OnvifCamera itemCamera in itemDevice.Cameras)
                    {
                        TreeViewItem cameraItemNode = BuildTreeViewItem((NodeTypeEnum)itemCamera.Type, itemCamera.Id, itemCamera.MediaUrl, (Image)General.GetResource("ImgCameraItemNode"));
                        cameraHeaderNode.Items.Add(cameraItemNode);
                    }

                    deviceNode.Items.Add(infoHeaderNode);
                    deviceNode.Items.Add(profileHeaderNode);
                    deviceNode.Items.Add(cameraHeaderNode);

                    result.Add(deviceNode);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        private void BuildNodeLegacy(Settings settings, TreeViewItem node)
        {
            try
            {
                TreeViewItem xmlFileNode = BuildTreeViewItem((NodeTypeEnum)settings.Type, settings.Id, settings.Id, (Image)General.GetResource("ImgXmlFileNode"));
                TreeViewItem parametersNode = BuildTreeViewItem(NodeTypeEnum.NONE, settings.Id, General.GetResource("StrParametersNodeCaption").ToString(), (Image)General.GetResource("ImgParametersNode"));
                TreeViewItem settingsPathNode = BuildTreeViewItem(NodeTypeEnum.NONE, settings.Id, General.GetResource("StrSettingsPathNodeCaption").ToString() + " " + settings.SettingsPath);
                TreeViewItem prefixCraneNameNode = BuildTreeViewItem(NodeTypeEnum.NONE, settings.Id, General.GetResource("StrPrefixCraneNameNodeCaption").ToString() + " " + settings.PrefixCraneName);
                TreeViewItem craneNameTemplateNode = BuildTreeViewItem(NodeTypeEnum.NONE, settings.Id, General.GetResource("StrCraneNameTemplateNodeCaption").ToString() + " " + settings.CraneNameTemplate);
                TreeViewItem blockNameTemplateNode = BuildTreeViewItem(NodeTypeEnum.NONE, settings.Id, General.GetResource("StrBlockNameTemplateNodeCaption").ToString() + " " + settings.BlockNameTemplate);
                TreeViewItem projectNode = BuildTreeViewItem(NodeTypeEnum.NONE, settings.Id, General.GetResource("StrProjectNodeCaption").ToString() + " " + settings.Project);
                TreeViewItem rosIDNode = BuildTreeViewItem(NodeTypeEnum.NONE, settings.Id, General.GetResource("StrRosIDNodeCaption").ToString() + " " + settings.RosID);
                TreeViewItem rosIniPathNode = BuildTreeViewItem(NodeTypeEnum.NONE, settings.Id, General.GetResource("StrROSIniPathNodeCaption").ToString() + " " + settings.ROSIniPath);

                parametersNode.Items.Add(settingsPathNode);
                parametersNode.Items.Add(prefixCraneNameNode);
                parametersNode.Items.Add(craneNameTemplateNode);
                parametersNode.Items.Add(blockNameTemplateNode);
                parametersNode.Items.Add(projectNode);
                parametersNode.Items.Add(rosIDNode);
                parametersNode.Items.Add(rosIniPathNode);

                xmlFileNode.Items.Add(parametersNode);
                node.Items.Add(xmlFileNode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private TreeViewItem BuildTreeViewItem(NodeTypeEnum type, string id, string caption, Image icon = null)
        {
            TreeViewItem result;

            try
            {
                result = new TreeViewItem();

                result.IsExpanded = (type == NodeTypeEnum.ROOT_NODE || type == NodeTypeEnum.ONVIF_NODE || type == NodeTypeEnum.SETTINGS_NODE) ? true : false;
                result.Header = BuildHeaderItem(caption, icon);
                result.ContextMenu = BuildContextMenu(type);
                result.Uid = id;
                result.Tag = type;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        private StackPanel BuildHeaderItem(string caption, Image icon = null)
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

                text.Text = caption;
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
        private ContextMenu BuildContextMenu(NodeTypeEnum type)
        {
            ContextMenu result;

            try
            {
                result = new ContextMenu();

                switch (type)
                {
                    case NodeTypeEnum.ROOT_NODE:
                        result.Items.Add(BuildMenuItem("Import...", ActionEnum.IMPORT_FILE_ACTION));
                        result.Items.Add(BuildMenuItem("Export...", ActionEnum.EXPORT_FILE_ACTION));
                        result.Items.Add(BuildMenuItem("Save", ActionEnum.SAVE_ACTION));
                        break;
                    case NodeTypeEnum.ONVIF_NODE:
                        result.Items.Add(BuildMenuItem("New Folder...", ActionEnum.NEW_FOLDER_ACTION));
                        result.Items.Add(BuildMenuItem("New Devices...", ActionEnum.NEW_DEVICES_ACTION));
                        break;
                    case NodeTypeEnum.SETTINGS_NODE:
                        result.Items.Add(BuildMenuItem("Import Legacy...", ActionEnum.IMPORT_FILE_LEGACY_ACTION));
                        break;
                    case NodeTypeEnum.FOLDER_NODE:
                        break;
                    case NodeTypeEnum.DEVICE_NODE:
                        break;
                    case NodeTypeEnum.INFO_NODE:
                        break;
                        break;
                    case NodeTypeEnum.PROFILE_NODE:
                        break;
                    case NodeTypeEnum.PROFILE_TOKEN_NODE:
                        break;
                    case NodeTypeEnum.CAMERA_NODE:
                        break;
                    case NodeTypeEnum.CAMERA_ITEM_NODE:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        private MenuItem BuildMenuItem(string caption, ActionEnum actionName)
        {
            MenuItem result;

            try
            {
                result = new MenuItem();

                result.Header = caption;
                result.Click += OnMenuItem_Click;
                result.Tag = actionName;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        private void OnMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ActionEnum actionName;

            try
            {
                actionName = (ActionEnum)((MenuItem)sender).Tag;

                switch (actionName)
                {
                    case ActionEnum.IMPORT_FILE_ACTION:
                        break;
                    case ActionEnum.EXPORT_FILE_ACTION:
                        break;
                    case ActionEnum.SAVE_ACTION:
                        break;
                    case ActionEnum.NEW_FOLDER_ACTION:
                        break;
                    case ActionEnum.NEW_DEVICES_ACTION:
                        break;
                    case ActionEnum.IMPORT_FILE_LEGACY_ACTION:
                        ImportFileLegacy();
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
        private void ImportFileLegacy()
        {
            Settings configLegacy;
            OpenFileDialog openDialog;
            FileLegacy fileLegacy;
            string pathFileName = string.Empty;

            try
            {
                openDialog = new OpenFileDialog();
                fileLegacy = new FileLegacy();

                openDialog.Filter = "Legacy Files (.xml)|*.xml";

                if ((bool)openDialog.ShowDialog())
                    pathFileName = openDialog.FileName;

                if (!string.IsNullOrEmpty(pathFileName))
                {
                    configLegacy = fileLegacy.LoadLegacyConfig(pathFileName);

                    if (configLegacy != null)
                    {
                        configLegacy.Id = openDialog.SafeFileName.Replace(".xml","").ToUpper();
                        BuildNodeLegacy(configLegacy, _selectedNode);
                    }                        
                }                    
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                openDialog = null;
                fileLegacy = null;
            }
        }        
    }
}