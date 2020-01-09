namespace Radiance.Assets
{
    public abstract class Asset
    {
        public string Name { get; private set; }

        public Asset(string name)
        {
            Name = name;
        }
    }
}
