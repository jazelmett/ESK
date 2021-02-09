using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;

namespace Framework.Api.Systems
{
    public class PortalEndpointData : BaseEndpointData
    {
        public PortalEndpointData() { }
        public PortalEndpointData
            (AuthTokens authValue)
        {
            AuthValue = (int)authValue;
        }

        public PortalEndpointData
            (Enviroment baseUrl)
        {
            BaseAddress = (int)baseUrl;
        }

        public PortalEndpointData
            (Enviroment baseUrl, AuthTokens authValue)
        {
            BaseAddress = (int)baseUrl;
            AuthValue = (int)authValue;
        }

        public PortalEndpointData
            (OptionalParam optParam, string optParamValue,
            Enviroment baseUrl, AuthTokens authValue)
        {
            BaseAddress = (int)baseUrl;
            AuthValue = (int)authValue;
            UidParam = optParam;
            OptParamValue = optParamValue;
        }

        public PortalEndpointData
            (object requestBody,
            Enviroment baseUrl, AuthTokens authValue)
        {
            BaseAddress = (int)baseUrl;
            AuthValue = (int)authValue;
            RequestBody = requestBody;
        }

        public PortalEndpointData
            (Dictionary<string, string> bodyParams,
            Enviroment baseUrl, AuthTokens authValue)
        {
            BaseAddress = (int)baseUrl;
            AuthValue = (int)authValue;
            BodyParams = bodyParams;
        }

        public PortalEndpointData
            (Dictionary<string, string> bodyParams, Dictionary<string, string> filePath,
            Enviroment baseUrl, AuthTokens authValue)
        {
            BaseAddress = (int)baseUrl;
            AuthValue = (int)authValue;
            BodyParams = bodyParams;
            FilePath = filePath;
        }
    }
}
