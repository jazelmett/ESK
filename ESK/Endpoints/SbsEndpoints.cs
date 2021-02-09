using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Api.Systems
{
    class SbsEndpoints : BaseEndpointData
    {
        public Enviroment Enviroment = Enviroment.sbussStage;
        public AuthTokens Auth = AuthTokens.sbsApi;

        public IRestResponse GetCheckActiveCard(SbsEndpointData callParams)
            => GetRequestInit(callParams, Method.GET, $"CheckActiveCard{callParams.UidParam}{callParams.OptParamValue}");

        public IRestResponse PostCancelTransactions(SbsEndpointData callParams)
            => PostRequestInitWithBody(callParams, Method.POST, "RegisterClient", callParams.RequestBody);

        public IRestResponse PostRegisterTransactions(SbsEndpointData callParams)
            => PostRequestInitWithFileNoMultipart(callParams, Method.POST, "RegisterTransactions", callParams.FilePath);
    }
}
