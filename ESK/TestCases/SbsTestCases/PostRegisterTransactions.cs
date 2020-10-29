using NUnit.Framework;
using System.Net;
using System.Runtime.CompilerServices;
using Newtonsoft;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace SapphireApiFramework
{
    [Parallelizable(ParallelScope.All)]
    class PostRegisterTransactions : SbsEndpoints
    {
        [TestCase(TestName = "200, Json")]
        public void ResponseCodeIs200JsonUplaod()
        {
            var files = new Dictionary<string, string>
            {
                {"", @"C:\FileUpload\Transactions.json"}
            };

            var callData = new SbsEndpointData(files, Enviroment, Auth);

            var response = PostRegisterTransactions(callData);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestCase(TestName = "200, Zip")]
        public void ResponseCodeis200ZipUpload()
        {
            var files = new Dictionary<string, string>
            {
                {"Transactions", @"C:\FileUpload\Transactions.zip"}
            };

            var callData = new SbsEndpointData(files, Enviroment, Auth);

            var response = PostRegisterTransactions(callData);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
