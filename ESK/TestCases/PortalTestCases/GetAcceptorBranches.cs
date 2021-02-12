using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Framework.Api.Systems;


namespace Framework.Api.Portal
{
    [Parallelizable(ParallelScope.All)]
    class GetAcceptorBranches : PortalEndpoints
    {
        [TestCase(TestName = "200, ОК")]
        public void ResponseCodeIs200()
        {
            var callData = new PortalData(Enviroment, Auth,OptionalParam.uid, "7");
            var response = GetAcceptorBranches(callData);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
