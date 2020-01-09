using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Radiance.Serialization;

namespace Radiance.Config
{
    public class ConfigEntry<T>
    {
        public string Key { get; private set; }
        public T Value { get; set; }
        public ConfigCategory Category { get; private set; }

        public ConfigEntry(string key, ConfigCategory category)
        {
            this.Key = key;
            this.Category = category;
        }

        public ConfigEntry(JObject obj)
        {
            this.Key = obj["Key"].ToString();
            this.Value = obj["Value"].ToObject<T>();
        }
    }

    public enum ConfigCategory
    {
        Controls,
        Graphics,
        Game,
        Audio
    }
}
