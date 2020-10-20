using NUnit.Framework;
using RestSharp;
using System.Threading.Tasks;

namespace SapphireApiFramework
{
    public class PortalEndpoints : EndpointCallData
    {
        public Enviroment Enviroment = Enviroment.portalStage;
        public AuthTokens Auth = AuthTokens.portalFive;


        public Task<IRestResponse> GetIssuePointOrganizations(EndpointCallData callParams)
        {
            return GetRequestInit(callParams, Method.GET, "IssuePointOrganizations");
        }

        public Task<IRestResponse> GetIssuePoints(EndpointCallData callParams)
        {
            if (callParams.UidValue == 0 && callParams.UidParam == null) 
                return GetRequestInit(callParams, Method.GET, $"IssuePoints");
            else if (callParams.UidValue == 0) 
                return GetRequestInit
                    (callParams, Method.GET, $"IssuePoints{callParams.UidParam}");
            else
                return GetRequestInit
                    (callParams, Method.GET, $"IssuePoints{callParams.UidParam}{callParams.UidValue}");
        }

        public Task<IRestResponse> GetListAcceptors(EndpointCallData callParams)
        {
            return GetRequestInit(callParams, Method.GET, "ListAcceptors");
        }

        public Task<IRestResponse> GetAcceptorBranches(EndpointCallData callParams)
        {
            return GetRequestInit(callParams, Method.GET, $"AcceptorBranches{callParams.UidParam}{callParams.UidValue}");
        }

        public Task<IRestResponse> GetLoyaltyProgramBranches(EndpointCallData callParams)
        {
            return GetRequestInit(callParams, Method.GET, $"LoyaltyProgramBranches{callParams.UidParam}{callParams.UidValue}");
        }

        public Task<IRestResponse> GetListLoyaltyPrograms(EndpointCallData callParams)
        {
            return GetRequestInit(callParams, Method.GET, $"ListLoyaltyPrograms");
        }

        public Task<IRestResponse> GetListLocalitites(EndpointCallData callParams)
        {
            return GetRequestInit(callParams, Method.GET, "ListLocalities");
        }

        public Task<IRestResponse> GetListAcceptorCategories(EndpointCallData callParams)
        {
            return GetRequestInit(callParams, Method.GET, "ListAcceptorCategories");
        }

        public Task<IRestResponse> GetKeyPartners(EndpointCallData callParams)
        {
            return GetRequestInit(callParams, Method.GET, "KeyPartners");
        }

        public Task<IRestResponse> GetListFeedbackThemes(EndpointCallData callParams)
        {
            return GetRequestInit(callParams, Method.GET, "ListFeedbackThemes");
        }

        public Task<IRestResponse> GetListStatePrograms(EndpointCallData callParams)
        {
            return GetRequestInit(callParams, Method.GET, "ListStatePrograms");
        }

        public Task<IRestResponse> GetListStateAssignments(EndpointCallData callParams)
        {
            return GetRequestInit(callParams, Method.GET, "ListStateAssignments");
        }

        public Task<IRestResponse> GetListExpenseLiabilities(EndpointCallData callParams)
        {
            return GetRequestInit(callParams, Method.GET, "ListStateAssignments");
        }

        public Task<IRestResponse> GetFile(EndpointCallData callParams)
        {
            var response = GetRequestInit(callParams, Method.GET, $"File{callParams.UidParam}{callParams.GetFileUid}");
            SaveResponseToFile(response.Result);
            return response;
        }

        public async Task<IRestResponse> PostFeedback(EndpointCallData callParams)
        {
            if (callParams.FilePath == null)
                return await PostRequestInitWithParams
                    (callParams, Method.POST, "Feedback", callParams.BodyParams);
            else
                return await PostRequestInitWithParamAndFile
                    (callParams, Method.POST, "Feedback", callParams.BodyParams, callParams.FilePath);
        }

        public async Task<IRestResponse> PostRegisterClient(EndpointCallData callParams)
        {
            return await PostRequestInitWithBody(callParams, Method.POST, "RegisterClient", callParams.RequestBody);
        }
    }
}
