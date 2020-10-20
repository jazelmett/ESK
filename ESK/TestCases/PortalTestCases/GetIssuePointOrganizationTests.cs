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
            var response = GetIssuePointOrganizations(new EndpointCallData(Enviroment, Auth));

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}