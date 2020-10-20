using NUnit.Framework;
using System.Net;

namespace SapphireApiFramework
{
    [Parallelizable(ParallelScope.All)]
    public class GetIssuePointsTests : PortalEndpoints
    {
        [TestCase(TestName = "400, Отсутствует Организация с указанным идентификатором")]
        public void SpeicifiedOrgIsNotPresent()
        { 
            var response = GetIssuePoints(new EndpointCallData("?uid=", 2, Enviroment, Auth));

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestCase(TestName = "400, Отсутствует ?uid= и значение uid")]
        public void NoUidParam()
        {
            var response = GetIssuePoints(new EndpointCallData(Enviroment, Auth));

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestCase(TestName = "400, Отсутствует значение uid")]
        public void NoUidValue()
        {
            var response = GetIssuePoints(new EndpointCallData("?uid=", Enviroment, Auth));

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}