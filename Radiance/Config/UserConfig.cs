using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Input;

using Radiance.Serialization;

namespace Radiance.Config
{
    public static class UserConfig
    {
        private static string userDataDirectory => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/radiance";
        private static string userConfigFile => UserConfig.userDataDirectory + "/settings.json";

        private static Dictionary<ConfigCategory, List<ConfigEntry>> configEntries;

        public static void LoadConfig()
        {
            UserConfig.configEntries = new Dictionary<ConfigCategory, List<ConfigEntry>>();
            foreach (ConfigCategory category in Enum.GetValues(typeof(ConfigCategory)))
            {
                UserConfig.configEntries.Add(category, new List<ConfigEntry>());
            }

            if (!Directory.Exists(UserConfig.userDataDirectory) || !File.Exists(UserConfig.userConfigFile))
            {
                UserConfig.configEntries = UserConfig.GetDefaultConfig();
                UserConfig.SaveConfig();
                return;
            }

            UserConfig.configEntries = Serializer.DeserializeObjectFromFile<Dictionary<ConfigCategory, List<ConfigEntry>>>(UserConfig.userConfigFile);
        }

        public static void SaveConfig()
        {
            if (!Directory.Exists(UserConfig.userDataDirectory)) Directory.CreateDirectory(UserConfig.userDataDirectory);
            Serializer.SerializeObjectToFile(UserConfig.configEntries, UserConfig.userConfigFile);
        }

        public static List<ConfigEntry> GetCategory(ConfigCategory category)
        {
            if (UserConfig.configEntries.ContainsKey(category)) return UserConfig.configEntries[category];
            return new List<ConfigEntry>();
        }

        public static T GetConfig<T>(ConfigCategory category, string key) where T : ConfigEntry
        {
            List<ConfigEntry> categoryEntries = UserConfig.GetCategory(category);
            var found = categoryEntries.Where(e => e.Key == key);
            return (T)found.FirstOrDefault();
        }

        private static Dictionary<ConfigCategory, List<ConfigEntry>> GetDefaultConfig()
        {
            var defaultConfig = new Dictionary<ConfigCategory, List<ConfigEntry>>();

            defaultConfig.Add(ConfigCategory.Controls, new List<ConfigEntry>()
            {
                new KeyConfigEntry("Up", ConfigCategory.Controls, Keys.I),
                new KeyConfigEntry("Left", ConfigCategory.Controls, Keys.J),
                new KeyConfigEntry("Down", ConfigCategory.Controls, Keys.K),
                new KeyConfigEntry("Right", ConfigCategory.Controls, Keys.L)
            });

            return defaultConfig;
        }
    }
}
