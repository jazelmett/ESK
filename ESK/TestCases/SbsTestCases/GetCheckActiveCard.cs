using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Framework.Api.Systems;

namespace Framework.Api.Sbs
{
    [Parallelizable(ParallelScope.All)]
    class GetCheckActiveCard : SbsEndpoints
    {
        [TestCase(TestName = "200, ОК")]
        public void ResponseCodeIs200()
        {
            var callData = new SbsData(Enviroment, Auth, OptionalParam.uid, "018324E865D000");
            var response = GetCheckActiveCard(callData);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assertions.IsResponseInArray(response);
        }

    }
}
