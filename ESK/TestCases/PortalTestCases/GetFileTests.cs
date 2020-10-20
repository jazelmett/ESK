using NUnit.Framework;
using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace SapphireApiFramework
{
    [Parallelizable(ParallelScope.All)]
    class GetFileTests : PortalEndpoints
    {
        [TestCase(TestName = "200, Файл загружен")]
        public void ResponseCodeIs200()
        {
            var response = GetFile
                (new EndpointCallData("?uid=", "d1098f29-8fae-47b1-a777-71a800dc85f8", Enviroment, Auth));
 
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
