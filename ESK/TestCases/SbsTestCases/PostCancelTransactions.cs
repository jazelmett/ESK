using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Framework.Api.Systems;
using Newtonsoft.Json;

namespace Framework.Api.Sbs
{
    [Parallelizable(ParallelScope.All)]
    class PostCancelTransactions : SbsEndpoints
    {
        [TestCase(TestName = "200, OK")]
        public void ResponseCodeIs200JsonUpload()
        {
            var obj1 = new CancelTransactionsJson
            {
                id = "555",
                BusStationID = "5",
                dateTime = "2020-08-12T15:59Z",
                cancelReason = 2
            };

            var obj2 = new CancelTransactionsJson
            {
                id = "555",
                BusStationID = "5",
                dateTime = "2020-08-12T15:59Z",
                cancelReason = 2
            };

            List<CancelTransactionsJson> l = new List<CancelTransactionsJson>
            {
                obj1,
                obj2
            };

            string payload = JAssistant<CancelTransactionsJson>.SerializeJsonIntoStringArray(l);
            var callData = new SbsData(Enviroment, Auth, payload);
            var response = PostCancelTransactions(callData);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
