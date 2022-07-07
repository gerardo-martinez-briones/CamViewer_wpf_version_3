namespace CamViewer.Helpers
{
    public static class General
    {
        public enum NodeTypeEnum
        {
            NONE = 0,
            ROOT_NODE = 1,
            ONVIF_NODE = 2,            
            FOLDER_NODE = 3,
            DEVICE_NODE = 4,
            INFO_NODE = 5,
            PROFILE_NODE = 6,
            PROFILE_TOKEN_NODE = 7,
            CAMERA_NODE = 8,
            CAMERA_ITEM_NODE = 9,
            SETTINGS_NODE = 10,
            XML_FILE_NODE = 11
        }

        public enum ActionEnum
        {
            IMPORT_FILE_ACTION = 0,
            EXPORT_FILE_ACTION = 1,
            SAVE_ACTION = 2,
            NEW_FOLDER_ACTION = 3,
            NEW_DEVICES_ACTION = 4,
            IMPORT_FILE_LEGACY_ACTION = 5
        }

        public static object GetResource(string resource)
        {
            return App.Current.FindResource(resource);
        }
   }
}