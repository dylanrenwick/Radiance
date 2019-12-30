using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DigiSouls.Serialization
{
    public class JClass : JObject
    {
        public JClass(object classType): base()
        {
            this.AddTypeData(classType);
        }

        private void AddTypeData(object classType)
        {
            Type type = classType.GetType();
            this.Add("__ClassType", $"{type.AssemblyQualifiedName}");
            var properties = type.GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                if (Attribute.IsDefined(pi, typeof(SerializedField)))
                {
                    this.AddValue(pi.Name, pi.GetValue(classType), pi.PropertyType);
                }
            }
        }

        private void AddValue(string key, object value, Type valueType)
        {
            // primitive types
            if (value is string) this.Add(key, (string)value);
            else if (value is int) this.Add(key, (int)value);
            else if (value is bool) this.Add(key, (bool)value);
            else if (value is float) this.Add(key, (float)value);
            // if value is instance of JsonSerializable
            else if (typeof(JsonSerializable).IsAssignableFrom(valueType)) this.Add(key, ((JsonSerializable)value).Serialize());
            // if value is array
            else if (valueType.IsArray) this.Add(key, new JArray((object[])value));
            // if value is Enumerable
            else if (value is IList && valueType.IsGenericType) this.Add(key, new JArray(((IList)value).Cast<object>().ToArray()));
            else throw new SerializationException(this, "Could not serialize type: " + valueType.FullName);
        }
    }
}
