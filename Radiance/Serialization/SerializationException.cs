using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiance.Serialization
{
    public class SerializationException : Exception 
    {
        private JObject jObj;

        public override string Message
        {
            get
            {
                string prefix = "";
                if (this.jObj.ContainsKey("__ClassType"))
                {
                    prefix = $"An error occured deserializing an object of type '{this.jObj["__ClassType"].ToString()}':{Environment.NewLine}";
                }
                return prefix + base.Message;
            }
        }

        public SerializationException(JObject jObj, string message): base(message)
        {
            this.jObj = jObj;
        }
        public SerializationException(JObject jObj, string message, Exception inner): base(message, inner)
        {
            this.jObj = jObj;
        }
    }
}
