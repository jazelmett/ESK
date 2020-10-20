using NUnit.Framework;
using RestSharp;
using System.Threading.Tasks;

namespace SapphireApiFramework
{
    public class PortalEndpoints : EndpointCallData
    {
        public Enviroment Enviroment = Enviroment.portalStage;
        public AuthTokens Auth = AuthTokens.portalFive;

        public IRestResponse GetIssuePointOrganizations(EndpointCallData callParams)
        {
            return GetRequestInit(callParams, Method.GET, "IssuePointOrganizations");
        }

        public IRestResponse GetIssuePoints(EndpointCallData callParams)
        {
            if (callParams.UidValue == 0)
                return GetRequestInit(callParams, Method.GET, $"IssuePoints{callParams.UidParam}");
            if (callParams.UidValue == 0 && callParams.UidParam == null) 
                return GetRequestInit(callParams, Method.GET, $"IssuePoints");

            return GetRequestInit (callParams, Method.GET, $"IssuePoints{callParams.UidParam}{callParams.UidValue}");
        }

        public IRestResponse GetListAcceptors(EndpointCallData callParams)
        {
            return GetRequestInit(callParams, Method.GET, "ListAcceptors");
        }

        public IRestResponse GetAcceptorBranches(EndpointCallData callParams)
        {
            return GetRequestInit(callParams, Method.GET, $"AcceptorBranches{callParams.UidParam}{callParams.UidValue}");
        }

        public IRestResponse GetLoyaltyProgramBranches(EndpointCallData callParams)
        {
            return GetRequestInit(callParams, Method.GET, $"LoyaltyProgramBranches{callParams.UidParam}{callParams.UidValue}");
        }

        public IRestResponse GetListLoyaltyPrograms(EndpointCallData callParams)
        {
            return GetRequestInit(callParams, Method.GET, $"ListLoyaltyPrograms");
        }

        public IRestResponse GetListLocalitites(EndpointCallData callParams)
        {
            return GetRequestInit(callParams, Method.GET, "ListLocalities");
        }

        public IRestResponse GetListAcceptorCategories(EndpointCallData callParams)
        {
            return GetRequestInit(callParams, Method.GET, "ListAcceptorCategories");
        }

        public IRestResponse GetKeyPartners(EndpointCallData callParams)
        {
            return GetRequestInit(callParams, Method.GET, "KeyPartners");
        }

        public IRestResponse GetListFeedbackThemes(EndpointCallData callParams)
        {
            return GetRequestInit(callParams, Method.GET, "ListFeedbackThemes");
        }

        public IRestResponse GetListStatePrograms(EndpointCallData callParams)
        {
            return GetRequestInit(callParams, Method.GET, "ListStatePrograms");
        }

        public IRestResponse GetListStateAssignments(EndpointCallData callParams)
        {
            return GetRequestInit(callParams, Method.GET, "ListStateAssignments");
        }

        public IRestResponse GetListExpenseLiabilities(EndpointCallData callParams)
        {
            return GetRequestInit(callParams, Method.GET, "ListStateAssignments");
        }

        public IRestResponse GetFile(EndpointCallData callParams)
        {
            var response = GetRequestInit(callParams, Method.GET, $"File{callParams.UidParam}{callParams.GetFileUid}");
            SaveResponseToFile(response);
            return response;
        }

        public IRestResponse PostFeedback(EndpointCallData callParams)
        {
            if (callParams.FilePath == null)
                return PostRequestInitWithParams(callParams, Method.POST, "Feedback", callParams.BodyParams);
            else
                return PostRequestInitWithParamAndFile(callParams, Method.POST, "Feedback", callParams.BodyParams, callParams.FilePath);
        }

        public IRestResponse PostRegisterClient(EndpointCallData callParams)
        {
            return PostRequestInitWithBody(callParams, Method.POST, "RegisterClient", callParams.RequestBody);
        }
    }
}
