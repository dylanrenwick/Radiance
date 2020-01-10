namespace Radiance.Config
{
    public class ConfigEntry
    {
        public string Key { get; private set; }
        public ConfigCategory Category { get; private set; }

        public ConfigEntry(string key, ConfigCategory category)
        {
            this.Key = key;
            this.Category = category;
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
