using NUnit.Framework;
using RestSharp;
using System.Threading.Tasks;

namespace Framework.Api.Systems
{
    public class PortalEndpoints : PortalData
    {
        public Enviroment Enviroment = Enviroment.portalStage;
        public AuthTokens Auth = AuthTokens.portalFive;

        public IRestResponse GetIssuePointOrganizations(PortalData callParams)
            => GetRequestInit(callParams, Method.GET, "IssuePointOrganizations");

        public IRestResponse GetIssuePoints(PortalData callParams)
        {
            if (callParams.OptParamValue == null)
                return GetRequestInit(callParams, Method.GET, $"IssuePoints{callParams.OptParam}");
            else if (callParams.OptParamValue == null && callParams.OptParam == null)
                return GetRequestInit(callParams, Method.GET, $"IssuePoints");
            else
                return GetRequestInit(callParams, Method.GET, $"IssuePoints{callParams.OptParam}{callParams.OptParamValue}");
        }

        public IRestResponse GetListAcceptors(PortalData callParams)
            => GetRequestInit(callParams, Method.GET, "ListAcceptors");

        public IRestResponse GetAcceptorBranches(PortalData callParams)
            => GetRequestInit(callParams, Method.GET, $"AcceptorBranches{callParams.OptParam}{callParams.OptParamValue}");

        public IRestResponse GetLoyaltyProgramBranches(PortalData callParams)
            => GetRequestInit(callParams, Method.GET, $"LoyaltyProgramBranches{callParams.OptParam}{callParams.OptParamValue}");

        public IRestResponse GetListLoyaltyPrograms(PortalData callParams)
            => GetRequestInit(callParams, Method.GET, $"ListLoyaltyPrograms");

        public IRestResponse GetListLocalitites(PortalData callParams)
            => GetRequestInit(callParams, Method.GET, "ListLocalities");

        public IRestResponse GetListAcceptorCategories(PortalData callParams)
            => GetRequestInit(callParams, Method.GET, "ListAcceptorCategories");

        public IRestResponse GetKeyPartners(PortalData callParams)
            => GetRequestInit(callParams, Method.GET, "KeyPartners");

        public IRestResponse GetListFeedbackThemes(PortalData callParams)
            => GetRequestInit(callParams, Method.GET, "ListFeedbackThemes");

        public IRestResponse GetListStatePrograms(PortalData callParams)
            => GetRequestInit(callParams, Method.GET, "ListStatePrograms");

        public IRestResponse GetListStateAssignments(PortalData callParams)
            => GetRequestInit(callParams, Method.GET, "ListStateAssignments");

        public IRestResponse GetListExpenseLiabilities(PortalData callParams)
            => GetRequestInit(callParams, Method.GET, "ListStateAssignments");

        public IRestResponse GetFile(PortalData callParams)
        {
            var response = GetRequestInit(callParams, Method.GET, $"File{callParams.OptParam}{callParams.OptParamValue}");
            SaveResponseToFile(response);
            return response;
        }

        public IRestResponse PostFeedback(PortalData callParams)
        {
            if (callParams.FilePath == null)
                return PostRequestInitWithParams(callParams, Method.POST, "Feedback", callParams.BodyParams);
            else
                return PostRequestInitWithParamsAndFile(callParams, Method.POST, "Feedback", callParams.BodyParams, callParams.FilePath);
        }

        public IRestResponse PostRegisterClient(PortalData callParams)
            => PostRequestInitWithBody(callParams, Method.POST, "RegisterClient", callParams.RequestContents);


    }
}
