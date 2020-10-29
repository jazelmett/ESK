using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace SapphireApiFramework
{
    class SbsEndpoints : PortalEndpointData
    {
        public Enviroment Enviroment = Enviroment.sbussStage;
        public AuthTokens Auth = AuthTokens.sbsApi;

        public IRestResponse GetCheckActiveCard(PortalEndpointData callParams)
            => GetRequestInit(callParams, Method.GET, $"CheckActiveCard{callParams.UidParam}{callParams.UidValue}");

        public IRestResponse PostCancelTransactions(PortalEndpointData callParams)
            => PostRequestInitWithBody(callParams, Method.POST, "RegisterClient", callParams.RequestBody);

        public IRestResponse PostRegisterTransactions(PortalEndpointData callParams)
            => PostRequestInitWithFileNoMultipart(callParams, Method.POST, "RegisterTransactions", callParams.FilePath);
    }
}
