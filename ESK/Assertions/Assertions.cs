using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using System.Runtime.CompilerServices;

namespace Framework.Api.Systems
{
    static class Assertions
    {
        public static string ParseArrayResponseCode(IRestResponse response)
        {
            var jArray = JArray.Parse(response.Content);
            var jObject = JObject.Parse(jArray[0].ToString());
            return jObject.GetValue("code").ToString();
        }
        public static string ParseArrayResponseMessage(IRestResponse response)
        {
            var jArray = JArray.Parse(response.Content);
            var jObject = JObject.Parse(jArray[0].ToString());
            return jObject.GetValue("message").ToString();
        }

        public static bool IsResponseInArray(IRestResponse response)
        {
            try
            {
           
                JArray.Parse(response.Content);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
