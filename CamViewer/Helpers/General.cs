using CamViewer.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace CamViewer.Helpers
{
    public static class General
    {
        public enum NodeTypeEnum
        {
            Other = 0,
            Root_Header = 1,
            Onvif_Header = 2,
            Folder_Item = 3,
            Device_Item = 4,
            Info_Header = 5,
            Info_Model = 6,
            Info_FirmwareVersion = 7,
            Info_SerialNumber = 8,
            Info_HardwareId = 9,
            Info_Uri = 10,
            Profile_Header = 11,
            Profile_Token = 12,
            Camera_Header = 13,
            Camera_Item = 14,
            Settings_Header = 15,
            Settings_File_Name = 16,
            Settings_Parameters_Header = 17,
            Settings_Blocks_Header = 18,
            Settings_Credentials_Header = 19,
            Settings_CameraTypes_Header = 20,
            Settings_Presets_Header = 21,
            Settings_CimplicityPoints_Header = 22,
            Settings_Forms_Header = 23,
            Settings_FormsRemote_Header = 24,
            Onvif_Parameters_Header = 25,
            Onvif_Parameters_Interval = 26
        }

        public enum ActionEnum
        {
            Import_Global_Config = 1,
            Export_Global_Config = 2,
            Save_Global_Config = 3,
            Enable_Mode_Discovery = 4,
            New_Folder = 5,
            Edit_Folder = 6,
            Delete_Folder = 7,
            New_Device = 8,
            Edit_Device = 9,
            Delete_Device = 10,
            Get_Onvif_Info = 11,
            Import_File = 12
        }
    }
}