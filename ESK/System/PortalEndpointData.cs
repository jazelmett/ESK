using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;

namespace SapphireApiFramework
{
    public enum Enviroment
    {
        bankStage,
        portalStage,
        acceptorStage,
        sbussStage,
        lkStage,
        bankTest,
        portalTest,
        acceptorTest,
        sbussTest,
        lkTest
    }

    public enum AuthTokens
    {
        portalFive = 5,
        sbsApi = 1
    }

    public class PortalEndpointData
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
            (string uidParam,
            Enviroment baseUrl, AuthTokens authValue)
        {
            BaseAddress = (int)baseUrl;
            AuthValue = (int)authValue;
            UidParam = uidParam;
        }

        public PortalEndpointData
            (string uidParam, int uidValue,
            Enviroment baseUrl, AuthTokens authValue)
        {
            BaseAddress = (int)baseUrl;
            AuthValue = (int)authValue;
            UidParam = uidParam;
            UidValue = uidValue;
        }

        public PortalEndpointData
            (string uidParam, string getFileUid,
            Enviroment baseUrl, AuthTokens authValue)
        {
            BaseAddress = (int)baseUrl;
            AuthValue = (int)authValue;
            GetFileUid = getFileUid;
            UidParam = uidParam;
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

        protected static IRestResponse GetRequestInit
            (PortalEndpointData callParams, Method httpMethod, string relativeAddress)
        {
            var api = new RestClient(callParams.baseAddress);
            var request = new RestRequest(relativeAddress, httpMethod);
            request.AddHeader("Authorization", callParams.authValue);
            var response = api.Execute(request);
            RequestsInfo(request, response);
            return response;
        }

        protected static IRestResponse PostRequestInitWithBody
            (PortalEndpointData callParams, Method httpMethod, string relativeAddress, object jsonBody)
        {
            var api = new RestClient(callParams.baseAddress);
            var request = new RestRequest(relativeAddress, httpMethod);
            request.AddHeader("Authorization", callParams.authValue);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(jsonBody);
            var response = api.Execute(request);
            RequestsInfo(request, response);
            return response;
        }

        protected static IRestResponse PostRequestInitWithParamsAndFile
            (PortalEndpointData callParams, Method httpMethod, string relativeAddress,
            Dictionary<string, string> parameters, Dictionary<string, string> filePaths)
        {
            var api = new RestClient(callParams.baseAddress);
            var request = new RestRequest(relativeAddress, httpMethod) { AlwaysMultipartFormData = true };
            request.AddHeader("Authorization", callParams.authValue);
            foreach (var parameter in parameters) request.AddParameter(parameter.Key, parameter.Value);
            foreach (var path in filePaths) request.AddFile(path.Key, path.Value);
            var response = api.Execute(request);
            RequestsInfo(request, response);
            return response;
        }

        protected static IRestResponse PostRequestInitWithFileNoMultipart
            (PortalEndpointData callParams, Method httpMethod, string relativeAddress, Dictionary<string, string> filePaths)
        {
            var api = new RestClient(callParams.baseAddress);
            var request = new RestRequest(relativeAddress, httpMethod);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", callParams.authValue);
            foreach (var path in filePaths) request.AddFile(path.Key, path.Value);
            var response = api.Execute(request);
            RequestsInfo(request, response);
            return response;
        }

        protected static IRestResponse PostRequestInitWithParams
            (PortalEndpointData callParams, Method httpMethod, string relativeAddress,
            Dictionary<string, string> parameters)
        {
            var api = new RestClient(callParams.baseAddress);
            var request = new RestRequest(relativeAddress, httpMethod) { AlwaysMultipartFormData = true };
            request.AddHeader("Authorization", callParams.authValue);
            foreach (var parameter in parameters) request.AddParameter(parameter.Key, parameter.Value);
            var response = api.Execute(request);
            RequestsInfo(request, response);
            return response;
        }

        public static void SaveResponseToFile(IRestResponse file)
        {
            var path = @"C:\Repos\GitHub\SapphireApiFramework\SavedFiles";
            var directory = new DirectoryInfo(path);

            if (!directory.Exists) directory.Create();

            var content = file.Content;
            using var stream = new FileStream($@"{path}\GetFileResponse.txt", FileMode.OpenOrCreate);
            var array = System.Text.Encoding.Default.GetBytes(content);
            stream.Write(array, 0, array.Length);

            Console.Out.WriteLine("Файл сохранен.");
        }

        public static void RequestsInfo(RestRequest request, IRestResponse response)
        {
            Console.Out.WriteLine("======================================================");
            Console.WriteLine   
                ($"Endpoint: {request.Method} {request.Resource}" +
                $"\nResponse Message: {(int)response.StatusCode} {response.StatusDescription}" +
                $"\nURL: {response.ResponseUri}");

            foreach (var param in request.Parameters) Console.Out.WriteLine(param);

            Console.Out.WriteLine("======================================================");
            Console.Out.WriteLine(response.Content);
        }

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
        public object RequestBody { get; set; }
        public string GetFileUid { get; }
        public string UidParam { get; set; }
        public int UidValue { get; set; }

        public Dictionary<string, string> FilePath { get; set; }
        public Dictionary<string, string> BodyParams { get; set; }

        private string authValue;
        public int AuthValue
        {
            set
            {
                if (value == 5) authValue = portalFive;
                if (value == 1) authValue = sbsApi;
            }
        }

        private string baseAddress;
        public int BaseAddress
        {
            set
            {
                if (value == 0) baseAddress = bankStage;
                if (value == 1) baseAddress = portalStage;
                if (value == 2) baseAddress = acceptorStage;
                if (value == 3) baseAddress = sbsStage;
                if (value == 4) baseAddress = lkStage;
                if (value == 5) baseAddress = bankTest;
                if (value == 6) baseAddress = portalTest;
                if (value == 7) baseAddress = acceptorTest;
                if (value == 8) baseAddress = sbsTest;
                if (value == 9) baseAddress = lkTest;
            }
        }
    }
}
