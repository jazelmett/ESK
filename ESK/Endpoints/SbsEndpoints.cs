using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Api.Systems
{
    class SbsEndpoints : BaseData
    {
        public Enviroment Enviroment = Enviroment.sbsStage;
        public AuthTokens Auth = AuthTokens.sbsApi;

        public IRestResponse GetCheckActiveCard(SbsData callParams)
            => GetRequestInit(callParams, Method.GET, $"CheckActiveCard{callParams.OptParam}{callParams.OptParamValue}");

        public IRestResponse PostCancelTransactions(SbsData callParams)
            => PostRequestInitWithBody(callParams, Method.POST, "CancelTransactions", callParams.RequestContents);

        public IRestResponse PostRegisterTransactions(SbsData<Dictionary<string, string>> callParams) 
            => PostRequestInitFileMultipart(callParams, Method.POST, "RegisterTransactions", callParams.ObjectToSend);

        public IRestResponse PostRegisterTransactions(SbsData<List<RegisterTransactionsJson>> callParams) 
            => PostRequestInitWithBody(callParams, Method.POST, "RegisterTransactions", callParams.ObjectToSend);

    }
}
