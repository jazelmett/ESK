using NUnit.Framework;
using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace SapphireApiFramework
{
    [Parallelizable(ParallelScope.All)]
    public class GetIssuePointOrganizationTests : PortalEndpoints
    {
        [TestCase(TestName = "200, Œ ")]
        public void ResponseCodeIs200()
        {
            var callData = new PortalEndpointData(Enviroment, Auth);
            var response = GetIssuePointOrganizations(callData);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}