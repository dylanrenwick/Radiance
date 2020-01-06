using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiance.Serialization
{
    public abstract class JsonSerializable
    {
        public JsonSerializable() { }
        public JsonSerializable(JObject json) { }

        public abstract JClass Serialize();
    }
}
