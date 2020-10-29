using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;


namespace SapphireApiFramework
{
    class SbsEndpointData : PortalEndpointData
    {
        public SbsEndpointData(Dictionary<string, string> filePath, Enviroment baseUrl, AuthTokens authValue)
        {
            BaseAddress = (int)baseUrl;
            AuthValue = (int)authValue;
            FilePath = filePath;
        }
    }
}