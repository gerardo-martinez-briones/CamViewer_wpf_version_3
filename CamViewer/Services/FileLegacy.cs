using CamViewer.Models.Legacy;
using System;
using System.IO;
using System.Xml.Serialization;

namespace CamViewer.Services
{
    public class FileLegacy
    {
        public Settings LoadLegacyConfig(string pathFileName)
        {
            Settings result;

            try
            {
                result = new Settings();

                XmlSerializer xml = new XmlSerializer(typeof(Settings));

                FileStream stream = new FileStream(pathFileName, FileMode.Open);
                result = (Settings)xml.Deserialize(stream);
                stream.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}