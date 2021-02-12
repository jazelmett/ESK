using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;


namespace Framework.Api.Systems
{
    class SbsData<T> : BaseData
    {
        public T ObjectToSend { get; set; }

        public SbsData(Enviroment baseUrl, AuthTokens authValue, T objectToSend)
        {
            BaseAddress = baseUrl;
            AuthValue = authValue;
            ObjectToSend = objectToSend;
        }
    }

    class SbsData : BaseData
    {
        public SbsData(Enviroment baseUrl, AuthTokens authValue)
        {
            BaseAddress = baseUrl;
            AuthValue = authValue;
        }

        public SbsData
            (Enviroment baseUrl, AuthTokens authValue, object requestContents) 
            : base(baseUrl, authValue, requestContents) { }

        public SbsData
            (Enviroment baseUrl, AuthTokens authValue, OptionalParam optParam, string optParamValue)
            : base(baseUrl, authValue, optParam, optParamValue) { }
    }
}