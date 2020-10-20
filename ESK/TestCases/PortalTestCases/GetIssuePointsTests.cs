using NUnit.Framework;
using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace SapphireApiFramework
{
    [Parallelizable(ParallelScope.All)]
    public class GetIssuePointsTests : PortalEndpoints
    {
        [TestCase(TestName = "400, Отсутствует Организация с указанным идентификатором")]
        public async Task ResponseCodeis400()
        { 
            var response = await GetIssuePoints(new EndpointCallData("?uid=", 2, Enviroment, Auth));

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestCase(TestName = "400, Отсутствует ?uid= и значение uid")]
        public async Task NoUidParam()
        {
            var response = await GetIssuePoints(new EndpointCallData(Enviroment, Auth));

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestCase(TestName = "400, Отсутствует значение uid")]
        public async Task NoUidValue()
        {
            var response = await GetIssuePoints(new EndpointCallData("?uid=", Enviroment, Auth));

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}