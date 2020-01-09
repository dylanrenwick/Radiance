using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Radiance.Config
{
    public static class UserConfig
    {
        private static Dictionary<ConfigCategory, List<ConfigEntry<object>>> configEntries;

        public static void LoadConfig()
        {
            UserConfig.configEntries = new Dictionary<ConfigCategory, List<ConfigEntry<object>>>();
            foreach (ConfigCategory category in Enum.GetValues(typeof(ConfigCategory)))
            {
                UserConfig.configEntries.Add(category, new List<ConfigEntry<object>>());
            }

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/radiance";
            string configFilePath = appDataPath + "/settings.json";
        }
    }
}
