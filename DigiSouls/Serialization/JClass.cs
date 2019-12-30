using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiSouls.Serialization
{
    public class JClass : JObject
    {
        public JClass(Type classType): base()
        {
            this.Add("__ClassType", $"{classType.AssemblyQualifiedName}");
        }

        public JClass(object classType): base()
        {
            Type type = classType.GetType();
            this.Add("__ClassType", $"{type.AssemblyQualifiedName}");
        }
    }
}
