using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Framework.Api.Systems;

namespace Framework.Api.Portal
{
    [Parallelizable(ParallelScope.All)]
    public class GetIssuePointOrganization : PortalEndpoints
    {
        [TestCase(TestName = "200, Œ ")]
        public void ResponseCodeIs200()
        {
            var callData = new PortalData(Enviroment, Auth);
            var response = GetIssuePointOrganizations(callData);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}