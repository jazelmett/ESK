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
            var callData = new PortalData(Enviroment, Auth, OptionalParam.uid, "d1098f29-8fae-47b1-a777-71a800dc85f8");
            var response = GetFile(callData);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestCase(TestName = "400, Not Found")]
        public void ResponseCodeIs400()
        {
            var callData = new PortalData(Enviroment, Auth, OptionalParam.uid, "d1098f29-8fae-47b1-a777-71a800dc85f1");
            var response = GetFile(callData);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
