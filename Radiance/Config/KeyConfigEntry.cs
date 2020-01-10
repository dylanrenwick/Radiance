using Microsoft.Xna.Framework.Input;

using Newtonsoft.Json;

namespace Radiance.Config
{
    public class KeyConfigEntry : ConfigEntry
    {
        public Keys Value { get; set; }

        public KeyConfigEntry(string key, ConfigCategory category, Keys value) : base(key, category)
        {
            this.Value = value;
        }
    }
}
