using RestSharp;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;

namespace Framework.Api.Systems
{
    public class PortalData : BaseData
    {
        public PortalData() { }

        public PortalData
            (Enviroment baseUrl, AuthTokens authValue, object requestContents)
            : base(baseUrl, authValue, requestContents) {}

        public PortalData(Enviroment baseUrl, AuthTokens authValue, OptionalParam optParam = OptionalParam.noParam, 
            string optParamValue = null, 
            Dictionary<string, string> bodyParams = null, Dictionary<string, string> filePath = null)
            : base(baseUrl, authValue, optParam, optParamValue, bodyParams, filePath) {}

        public PortalData(Enviroment baseUrl, AuthTokens authValue, 
            Dictionary<string, string> bodyParams, Dictionary<string, string> filePath)
        {
            BaseAddress = baseUrl;
            AuthValue = authValue;
            BodyParams = bodyParams;
            FilePath = filePath;
        }
    }
}
