using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Framework.Api.Systems;

namespace Framework.Api.Portal
{
    [Parallelizable(ParallelScope.All)]
    class GetFile : PortalEndpoints
    {
        [TestCase(TestName = "200, Файл загружен")]
        public void ResponseCodeIs200()
        {
            var callData = new PortalEndpointData(OptionalParam.uid, "d1098f29-8fae-47b1-a777-71a800dc85f8", Enviroment, Auth);
            var response = GetFile(callData);
            var s = "ss";
            Console.Out.WriteLine(s.ToString());
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
