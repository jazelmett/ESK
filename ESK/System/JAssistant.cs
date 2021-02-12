using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Framework.Api.Systems
{
    public class JAssistant<T>
    {
        public static string SerializeJsonIntoStringArray(T payload)
        {
            List<T> l = new List<T> { payload };
            return JsonConvert.SerializeObject(l, Formatting.Indented);
        }
        public static string SerializeJsonIntoStringArray(List<T> payload)
        {
            return JsonConvert.SerializeObject(payload, Formatting.Indented);
        }

        public static List<T> DeserializeJsonFromFile(string filePath)
        {
            using StreamReader streamReader = new StreamReader($"{filePath}");
            string json = streamReader.ReadToEnd();
            return JsonConvert.DeserializeObject<List<T>>(json);
        }
    }

}

