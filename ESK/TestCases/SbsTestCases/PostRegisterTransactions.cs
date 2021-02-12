using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using Framework.Api.Systems;


namespace Framework.Api.Sbs
{
    [Parallelizable(ParallelScope.All)]
    class PostRegisterTransactions : SbsEndpoints
    {
        [TestCase(TestName = "200, Json")]
        public void ResponseCodeIs200JsonUpload()
        {
            var json = JAssistant<RegisterTransactionsJson>.DeserializeJsonFromFile(@"C:\FileUpload\Transactions.json");
            var callData = new SbsData<List<RegisterTransactionsJson>>(Enviroment, Auth, json);
            var response = PostRegisterTransactions(callData);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestCase(TestName = "200, Zip")]
        public void ResponseCodeIs200ZipUpload()
        {
            var files = new Dictionary<string, string>
            {
                {"Transactions", @"C:\FileUpload\Transactions.zip"}
            };

            var callData = new SbsData<Dictionary<string, string>>(Enviroment, Auth, files);
            var response = PostRegisterTransactions(callData);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
