using DigiSouls.Serialization;
using Newtonsoft.Json.Linq;

namespace DigiSouls.Assets
{
    public abstract class Asset : JsonSerializable
    {
        public string Name { get; private set; }

        public Asset(string name)
        {
            Name = name;
        }

        public override JClass Serialize()
        {
            JClass jObj = new JClass(this);
            jObj.Add("Name", this.Name);
            return jObj;
        }
    }
}
