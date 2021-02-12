using NUnit.Framework;
using System.Net;
using Framework.Api.Systems;

namespace Framework.Api.Portal
{
    [Parallelizable(ParallelScope.All)]
    class GetKeyPartners : PortalEndpoints
    {
        [TestCase(TestName = "200, ОК")]
        public void ResponseCodeIs200()
        {
            var callData = new PortalData(Enviroment, Auth);
            var response = GetKeyPartners(callData);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assertions.IsResponseInArray(response);

        }
    }
}
