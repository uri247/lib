using System;
using System.IO;
using Matrix.Xml;

namespace Weather
{
    public class Util
    {
        private static string _settingsFolder;
        private static string _settingsFilename;
        
        private static string SettingsFolder
        {
            get
            {
                if (_settingsFolder == null)
                {
                    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                                               @"MatriX-Examples\Weather");
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    _settingsFolder = path;
                }
                return _settingsFolder;
            }
        }

        private static string SettingsFilename
        {
            get
            {
                if (_settingsFilename == null)
                    _settingsFilename = Path.Combine(SettingsFolder, "settings.xml");
                
                return _settingsFilename;
            }
        }
        
        public static Settings.Settings LoadSettings()
        {
            XmppXElement set = null;
            if (File.Exists(SettingsFilename))
            {
                set = XmppXElement.LoadXml(File.ReadAllText(SettingsFilename));
                
            }
            if (set is Settings.Settings)
                return set as Settings.Settings;
            
            return new Settings.Settings();
        }

        public static void SaveSettings(Settings.Settings set)
        {
            set.Save(SettingsFilename);
        }
    }
}