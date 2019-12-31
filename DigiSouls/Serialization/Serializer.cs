using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

using DigiSouls.Assets;
using Microsoft.Xna.Framework;
using System.Reflection;

namespace DigiSouls.Serialization
{
    public static class Serializer
    {
        private static readonly Regex typeRegex = new Regex(@"^{(.*)}:{(.*)}$");

        public static object Deserialize(string json)
        {
            JObject root = JObject.Parse(json);
            return GetObject(root);
        }

        public static Vector2 DeserializeVector2(JObject obj)
        {
            float x = obj.Value<float>("X");
            float y = obj.Value<float>("Y");
            return new Vector2(x, y);
        }

        public static Vector3 DeserializeVector3(JObject obj)
        {
            float x = obj.Value<float>("X");
            float y = obj.Value<float>("Y");
            float z = obj.Value<float>("Z");
            return new Vector3(x, y, z);
        }

        public static object[] DeserializeArray(JArray arr)
        {
            var items = new List<object>();

            foreach(JToken i in arr)
            {
                if (i is JObject) items.Add(GetObject(i as JObject));
            }

            return items.ToArray();
        }

        private static Type GetObjectType(JObject obj)
        {
            string typeString = obj["__ClassType"].ToString();
            return Type.GetType(typeString);
        }

        private static object GetObject(JObject obj)
        {
            try
            {
                Type objType = GetObjectType(obj);
                if (typeof(Asset).IsAssignableFrom(objType))
                {
                    MethodInfo deserializeMethod = objType.GetMethods().Where(m => m.IsStatic && m.Name == "Deserialize").FirstOrDefault();
                    return deserializeMethod.Invoke(null, new object[] { obj["Name"].Value<string>() });
                }
                else return Activator.CreateInstance(objType, obj);
            }
            catch (Exception e)
            {
                throw new SerializationException(obj, $"Could not create instance of class: {e.Message}.{Environment.NewLine}See inner exception.", e);
            }
        }
    }
}
