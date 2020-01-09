using System.IO;

using Newtonsoft.Json;

namespace Radiance.Serialization
{
    public static class Serializer
    {
        private readonly static JsonSerializerSettings serializationSettings = new JsonSerializerSettings
        {
            PreserveReferencesHandling = PreserveReferencesHandling.Objects
        };

        public static string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj, Serializer.serializationSettings);
        }

        public static void SerializeObjectToFile(object obj, string filePath)
        {
            using (StreamWriter file = File.CreateText(filePath))
            {
                var ser = JsonSerializer.Create(Serializer.serializationSettings);
                ser.Serialize(file, obj);
            }
        }
    }
}
