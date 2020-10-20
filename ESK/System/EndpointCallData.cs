using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
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
        portalFive = 5
    }

    public class EndpointCallData
    {
        public EndpointCallData() { }
        public EndpointCallData
            (AuthTokens authValue)
        {
            AuthValue = (int)authValue;
        }

        public EndpointCallData
            (Enviroment baseUrl)
        {
            BaseAddress = (int)baseUrl;
        }

        public EndpointCallData
            (Enviroment baseUrl, AuthTokens authValue)
        {
            BaseAddress = (int)baseUrl;
            AuthValue = (int)authValue;
        }
        public EndpointCallData
            (string uidParam,
            Enviroment baseUrl, AuthTokens authValue)
        {
            BaseAddress = (int)baseUrl;
            AuthValue = (int)authValue;
            UidParam = uidParam;
        }

        public EndpointCallData
            (string uidParam, int uidValue,
            Enviroment baseUrl, AuthTokens authValue)
        {
            BaseAddress = (int)baseUrl;
            AuthValue = (int)authValue;
            UidParam = uidParam;
            UidValue = uidValue;
        }

        public EndpointCallData
            (string uidParam, string getFileUid,
            Enviroment baseUrl, AuthTokens authValue)
        {
            BaseAddress = (int)baseUrl;
            AuthValue = (int)authValue;
            GetFileUid = getFileUid;
            UidParam = uidParam;
        }

        public EndpointCallData
            (object requestBody,
            Enviroment baseUrl, AuthTokens authValue)
        {
            BaseAddress = (int)baseUrl;
            AuthValue = (int)authValue;
            RequestBody = requestBody;
        }

        public EndpointCallData
            (Dictionary<string, string> bodyParams,
            Enviroment baseUrl, AuthTokens authValue)
        {
            BaseAddress = (int)baseUrl;
            AuthValue = (int)authValue;
            BodyParams = bodyParams;
        }

        public EndpointCallData
            (Dictionary<string, string> bodyParams, Dictionary<string, string> filePath,
            Enviroment baseUrl, AuthTokens authValue)
        {
            BaseAddress = (int)baseUrl;
            AuthValue = (int)authValue;
            BodyParams = bodyParams;
            FilePath = filePath;
        }


        public const string bankStage = "http://webservice.uralsoccard.ru:9696/IP/API/1_0/";
        public const string portalStage = "http://webservice.uralsoccard.ru:9698/IP/API/1_0/";
        public const string acceptorStage = "http://webservice.uralsoccard.ru:9695/IP/API/1_0/";
        public const string sbussStage = "http://webservice.uralsoccard.ru:9695/IP/API/1_0/";
        public const string lkStage = "http://webservice.uralsoccard.ru:9697/IP/API/1_0/";
        public const string bankTest = "http://test-esk-api.nposapfir.ru:17065/IP/API/1_0/";
        public const string portalTest = "http://webservice.uralsoccard.ru:17055/IP/API/1_0/";
        public const string acceptorTest = "http://test-esk-api.nposapfir.ru:17075/IP/API/1_0/";
        public const string sbussTest = "http://test-esk-api.nposapfir.ru:17105/IP/API/1_0/";
        public const string lkTest = "not implemented";

        public const string portalFive = "4493ed42-a53d-4e61-8601-4e3c0ecb215a";

        protected async static Task<IRestResponse> GetRequestInit
            (EndpointCallData callParams, Method httpMethod, string relativeAddress)
        {
            var api = new RestClient(callParams.baseAddress);
            var request = new RestRequest(relativeAddress, httpMethod);
            request.AddHeader("Authorization", callParams.authValue);
            var response = await api.ExecuteAsync(request);
            Console.Out.WriteLine(ResponseInfo(response));
            Console.Out.WriteLine(response.Content);
            return response;
        }

        protected async static Task<IRestResponse> PostRequestInitWithBody
            (EndpointCallData callParams, Method httpMethod, string relativeAddress, object jsonBody)
        {
            var api = new RestClient(callParams.baseAddress);
            var request = new RestRequest(relativeAddress, httpMethod);
            request.AddHeader("Authorization", callParams.authValue);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(jsonBody);
            var response = await api.ExecuteAsync(request);
            Console.Out.WriteLine(ResponseInfo(response));
            Console.Out.WriteLine(response.Content);
            return response;
        }

        protected async static Task<IRestResponse> PostRequestInitWithParamAndFile
            (EndpointCallData callParams, Method httpMethod, string relativeAddress,
            Dictionary<string, string> parameters, Dictionary<string, string> filePaths)
        {
            var api = new RestClient(callParams.baseAddress);
            var request = new RestRequest(relativeAddress, httpMethod) { AlwaysMultipartFormData = true };
            request.AddHeader("Authorization", callParams.authValue);
            foreach (var parameter in parameters) request.AddParameter(parameter.Key, parameter.Value);
            foreach (var path in filePaths) request.AddFile(path.Key, path.Value);
            var response = await api.ExecuteAsync(request);
/*            Console.Out.WriteLine(ResponseInfo(response));
            Console.Out.WriteLine(response.Content);*/
            return response;
        }

        protected async static Task<IRestResponse> PostRequestInitWithParams
            (EndpointCallData callParams, Method httpMethod, string relativeAddress, 
            Dictionary<string, string> parameters)
        {
            var api = new RestClient(callParams.baseAddress);
            var request = new RestRequest(relativeAddress, httpMethod) { AlwaysMultipartFormData = true };
            request.AddHeader("Authorization", callParams.authValue);
            foreach (var parameter in parameters) request.AddParameter(parameter.Key, parameter.Value);
            var response = await api.ExecuteAsync(request);
/*            Console.Out.WriteLine(ResponseInfo(response));
            Console.Out.WriteLine(response.Content);*/
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

        public static string ResponseInfo(IRestResponse response)
        {
            return

                $"Endpoint: {response.Request.Method} {response.Request.Resource}" +
                $"\nURL: {response.ResponseUri}" +
                $"\nResponse Message: {(int)response.StatusCode} {response.StatusDescription}" +
                $"\nReponse Content-Type: {response.ContentType}";
        }

        public string FileKeyName { get; set; }
        public object RequestBody { get; set; }
        public string GetFileUid { get; }
        public string UidParam { get; set; }
        public int UidValue { get; set; }

        public Dictionary<string, string> FilePath { get; set; }
        public Dictionary<string, string> BodyParams { get; set; }

        private string authValue;
        public int AuthValue { set { if (value == 5) authValue = portalFive; } }

        private string baseAddress;
        public int BaseAddress
        {
            set
            {
                if (value == 0) baseAddress = bankStage;
                if (value == 1) baseAddress = portalStage;
                if (value == 2) baseAddress = acceptorStage;
                if (value == 3) baseAddress = sbussStage;
                if (value == 4) baseAddress = lkStage;
                if (value == 5) baseAddress = bankTest;
                if (value == 6) baseAddress = portalTest;
                if (value == 7) baseAddress = acceptorTest;
                if (value == 8) baseAddress = sbussTest;
                if (value == 9) baseAddress = lkTest;
            }
        }
    }
}
