﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Framework.Api.Systems;

namespace Framework.Api.Portal
{
    class GetListStatePrograms : PortalEndpoints
    {
        [TestCase(TestName = "200, ОК")]
        public void ResponseCodeIs200()
        {
            var callData = new PortalData(Enviroment, Auth);
            var response = GetListStatePrograms(callData);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assertions.IsResponseInArray(response);
        }
    }
}
