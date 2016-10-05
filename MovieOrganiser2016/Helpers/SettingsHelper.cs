using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieOrganiser2016.Helpers
{
    public class SettingsHelper
    {
        // constructor. makes sure a settings file exists.
        public SettingsHelper()
        {

        }

        public string GetSetting(string SettingName)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[SettingName] ?? "";
                Console.WriteLine("value for setting: " + SettingName + " = " + result);
                return result;
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
            return "";
        }

        public void WriteSettings(string SettingName, string SettingValue)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[SettingName] == null)
                {
                    settings.Add(SettingName, SettingValue);
                }
                else
                {
                    settings[SettingName].Value = SettingValue;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        public void PrintAllSettingsToConsole()
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        
                Console.WriteLine("--- Settings from: " + configFile.ToString());
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("AppSettings is empty.");
                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {
                        Console.WriteLine("Key: {0} Value: {1}", key, appSettings[key]);
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
        }
    }
}
