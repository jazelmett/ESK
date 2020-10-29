using NUnit.Framework;
using RestSharp;
using System.Threading.Tasks;

namespace SapphireApiFramework
{
    public class PortalEndpoints : PortalEndpointData
    {
        public Enviroment Enviroment = Enviroment.portalStage;
        public AuthTokens Auth = AuthTokens.portalFive;

        public IRestResponse GetIssuePointOrganizations(PortalEndpointData callParams)
            => GetRequestInit(callParams, Method.GET, "IssuePointOrganizations");

        public IRestResponse GetIssuePoints(PortalEndpointData callParams)
        {
            if (callParams.UidValue == 0)
                return GetRequestInit(callParams, Method.GET, $"IssuePoints{callParams.UidParam}");
            else if (callParams.UidValue == 0 && callParams.UidParam == null)
                return GetRequestInit(callParams, Method.GET, $"IssuePoints");
            else
                return GetRequestInit(callParams, Method.GET, $"IssuePoints{callParams.UidParam}{callParams.UidValue}");
        }

        public IRestResponse GetListAcceptors(PortalEndpointData callParams)
            => GetRequestInit(callParams, Method.GET, "ListAcceptors");

        public IRestResponse GetAcceptorBranches(PortalEndpointData callParams)
            => GetRequestInit(callParams, Method.GET, $"AcceptorBranches{callParams.UidParam}{callParams.UidValue}");

        public IRestResponse GetLoyaltyProgramBranches(PortalEndpointData callParams)
            => GetRequestInit(callParams, Method.GET, $"LoyaltyProgramBranches{callParams.UidParam}{callParams.UidValue}");

        public IRestResponse GetListLoyaltyPrograms(PortalEndpointData callParams)
            => GetRequestInit(callParams, Method.GET, $"ListLoyaltyPrograms");

        public IRestResponse GetListLocalitites(PortalEndpointData callParams)
            => GetRequestInit(callParams, Method.GET, "ListLocalities");

        public IRestResponse GetListAcceptorCategories(PortalEndpointData callParams)
            => GetRequestInit(callParams, Method.GET, "ListAcceptorCategories");

        public IRestResponse GetKeyPartners(PortalEndpointData callParams)
            => GetRequestInit(callParams, Method.GET, "KeyPartners");

        public IRestResponse GetListFeedbackThemes(PortalEndpointData callParams)
            => GetRequestInit(callParams, Method.GET, "ListFeedbackThemes");

        public IRestResponse GetListStatePrograms(PortalEndpointData callParams)
            => GetRequestInit(callParams, Method.GET, "ListStatePrograms");

        public IRestResponse GetListStateAssignments(PortalEndpointData callParams)
            => GetRequestInit(callParams, Method.GET, "ListStateAssignments");

        public IRestResponse GetListExpenseLiabilities(PortalEndpointData callParams)
            => GetRequestInit(callParams, Method.GET, "ListStateAssignments");

        public IRestResponse GetFile(PortalEndpointData callParams)
        {
            var response = GetRequestInit(callParams, Method.GET, $"File{callParams.UidParam}{callParams.GetFileUid}");
            SaveResponseToFile(response);
            return response;
        }

        public IRestResponse PostFeedback(PortalEndpointData callParams)
        {
            if (callParams.FilePath == null)
                return PostRequestInitWithParams(callParams, Method.POST, "Feedback", callParams.BodyParams);
            else
                return PostRequestInitWithParamsAndFile(callParams, Method.POST, "Feedback", callParams.BodyParams, callParams.FilePath);
        }

        public IRestResponse PostRegisterClient(PortalEndpointData callParams)
            => PostRequestInitWithBody(callParams, Method.POST, "RegisterClient", callParams.RequestBody);
    }
}
