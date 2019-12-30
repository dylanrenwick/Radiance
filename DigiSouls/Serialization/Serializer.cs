using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

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
                return Activator.CreateInstance(objType, obj);
            }
            catch (Exception e)
            {
                throw new SerializationException(obj, $"Could not create instance of class: {e.Message}.{Environment.NewLine}See inner exception.", e);
            }
        }
    }
}
