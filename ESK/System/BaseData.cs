using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using System.IO;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Net;
using Framework.Api.Systems;

namespace Framework.Api.Systems
{
    public enum Enviroment
    {
        bankStage,
        portalStage,
        acceptorStage,
        sbsStage,
        lkStage,
        bankTest,
        portalTest,
        acceptorTest,
        sbsTest,
        lkTest
    }

    public enum AuthTokens
    {
        noAuth = 0,
        portalFive = 5,
        sbsApi = 1
    }

    public enum OptionalParam
    {
        noParam,
        uid,
        numCardESK,
        from,
    }

    public class BaseData : SystemNecessities
    {
        public const string bankStage = "http://webservice.uralsoccard.ru:9696/IP/API/1_0/";
        public const string portalStage = "http://webservice.uralsoccard.ru:9698/IP/API/1_0/";
        public const string acceptorStage = "http://webservice.uralsoccard.ru:9695/IP/API/1_0/";
        public const string sbsStage = "http://webservice.uralsoccard.ru:9695/SBS/API/1_0/";
        public const string lkStage = "http://webservice.uralsoccard.ru:9697/IP/API/1_0/";
        public const string bankTest = "http://test-esk-api.nposapfir.ru:17065/IP/API/1_0/";
        public const string portalTest = "http://webservice.uralsoccard.ru:17055/IP/API/1_0/";
        public const string acceptorTest = "http://test-esk-api.nposapfir.ru:17075/IP/API/1_0/";
        public const string sbsTest = "http://test-esk-api.nposapfir.ru:17105/SBS/API/1_0/";
        public const string lkTest = "not implemented";

        public const string portalFive = "4493ed42-a53d-4e61-8601-4e3c0ecb215a";
        public const string sbsApi = "47897c5d-918c-4d9a-9380-5ea7d1fcdb34";

        public string FileKeyName { get; set; }
        public object RequestContents { get; set; }
        public string GetFileUid { get; set; }
        public string OptParamValue { get; set; }

        public Dictionary<string, string> FilePath { get; set; }
        public object JsonObject { get; set; }

        public Dictionary<string, string> BodyParams { get; set; }

        protected string uidParam;
        public object OptParam
        {
            get 
            { 
                return uidParam; 
            }
            set
            {
                if (value.Equals(OptionalParam.from)) uidParam = "?from=";
                if (value.Equals(OptionalParam.uid)) uidParam = "?uid=";
                if (value.Equals(OptionalParam.numCardESK)) uidParam = "?numCardESK=";
                if (value.Equals(OptionalParam.noParam)) uidParam = null;
            }
        }

        protected string authValue;
        public object AuthValue
        {
            get
            {
                return authValue;
            }
            set
            {
                if (value.Equals(AuthTokens.noAuth)) authValue = null;
                if (value.Equals(AuthTokens.sbsApi)) authValue = sbsApi;
                if (value.Equals(AuthTokens.portalFive)) authValue = portalFive;
            }
        }

        protected string baseAddress;
        public object BaseAddress
        {
            get
            {
                return baseAddress;
            }
            set
            {
                if (value.Equals(Enviroment.bankStage)) baseAddress = bankStage;
                if (value.Equals(Enviroment.portalStage)) baseAddress = portalStage;
                if (value.Equals(Enviroment.acceptorStage)) baseAddress = acceptorStage;
                if (value.Equals(Enviroment.sbsStage)) baseAddress = sbsStage;
                if (value.Equals(Enviroment.lkStage)) baseAddress = lkStage;
                if (value.Equals(Enviroment.bankTest)) baseAddress = bankTest;
                if (value.Equals(Enviroment.portalTest)) baseAddress = portalTest;
                if (value.Equals(Enviroment.acceptorTest)) baseAddress = acceptorTest;
                if (value.Equals(Enviroment.sbsTest)) baseAddress = sbsTest;
                if (value.Equals(Enviroment.lkTest)) baseAddress = lkTest;
            }
        }

        public BaseData
(Enviroment baseUrl, AuthTokens authValue, OptionalParam optParam = OptionalParam.noParam,
string optParamValue = null, Dictionary<string, string> bodyParams = null, Dictionary<string, string> filePath = null)
        {
            BaseAddress = baseUrl;
            AuthValue = authValue;
            BodyParams = bodyParams;
            FilePath = filePath;
            OptParam = optParam;
            OptParamValue = optParamValue;
        }

        public BaseData
    (Enviroment baseUrl, AuthTokens authValue, object requestContents)
        {
            BaseAddress = baseUrl;
            AuthValue = authValue;
            RequestContents = requestContents;
        }

        public BaseData() { }
    }
}
