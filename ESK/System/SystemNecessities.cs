using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;

namespace Framework.Api.Systems
{
    public class SystemNecessities
    {
        protected static IRestResponse GetRequestInit
         (BaseData callParams, Method httpMethod, string relativeAddress)
        {
            var api = new RestClient(callParams.BaseAddress.ToString());
            var request = new RestRequest(relativeAddress, httpMethod);
            request.AddHeader("Authorization", callParams.AuthValue.ToString());
            var response = api.Execute(request);
            RequestsInfo(request, response);
            return response;
        }

        protected static IRestResponse PostRequestInitWithBody
            (BaseData callParams, Method httpMethod, string relativeAddress, object jsonBody)
        {
            var api = new RestClient(callParams.BaseAddress.ToString());
            var request = new RestRequest(relativeAddress, httpMethod);
            request.AddHeader("Authorization", callParams.AuthValue.ToString());
            if (jsonBody is string)
                request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);
            else
                request.AddJsonBody(jsonBody);
            var response = api.Execute(request);
            RequestsInfo(request, response);
            return response;
        }

        protected static IRestResponse PostRequestInitWithParamsAndFile
            (BaseData callParams, Method httpMethod, string relativeAddress,
            Dictionary<string, string> parameters, Dictionary<string, string> filePaths)
        {
            var api = new RestClient(callParams.BaseAddress.ToString());
            var request = new RestRequest(relativeAddress, httpMethod) { AlwaysMultipartFormData = true };
            request.AddHeader("Authorization", callParams.AuthValue.ToString());
            foreach (var parameter in parameters) request.AddParameter(parameter.Key, parameter.Value);
            foreach (var path in filePaths) request.AddFile(path.Key, path.Value);
            var response = api.Execute(request);
            RequestsInfo(request, response);
            return response;
        }

        protected static IRestResponse PostRequestInitFileMultipart
    (BaseData callParams, Method httpMethod, string relativeAddress, Dictionary<string, string> filePaths)
        {
            var api = new RestClient(callParams.BaseAddress.ToString());
            var request = new RestRequest(relativeAddress, httpMethod);

            request.AddHeader("Content-Type", "multipart/form-data");
            request.AddHeader("Authorization", callParams.AuthValue.ToString());
            foreach (var path in filePaths) request.AddFile(path.Key, path.Value);
            var response = api.Execute(request);
            RequestsInfo(request, response);
            return response;
        }

        protected static IRestResponse PostRequestInitWithParams
            (BaseData callParams, Method httpMethod, string relativeAddress,
            Dictionary<string, string> parameters)
        {
            var api = new RestClient(callParams.BaseAddress.ToString());
            var request = new RestRequest(relativeAddress, httpMethod) { AlwaysMultipartFormData = true };
            request.AddHeader("Authorization", callParams.AuthValue.ToString());
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
    }

}