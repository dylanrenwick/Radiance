using Microsoft.Xna.Framework;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiSouls.Serialization
{
    public static class SerializationExtensions
    {
        public static JObject Serialize(this Vector2 v)
        {
            var jObj = new JObject();
            jObj.Add("X", v.X);
            jObj.Add("Y", v.Y);
            return jObj;
        }

        public static JObject Serialize(this Vector3 v)
        {
            var jObj = new JObject();
            jObj.Add("X", v.X);
            jObj.Add("Y", v.Y);
            jObj.Add("Z", v.Z);
            return jObj;
        }

        public static JObject Serialize(this Rectangle r)
        {
            var jObj = new JObject();
            jObj.Add("X", r.X);
            jObj.Add("Y", r.Y);
            jObj.Add("W", r.Width);
            jObj.Add("H", r.Height);
            return jObj;
        }
    }
}
