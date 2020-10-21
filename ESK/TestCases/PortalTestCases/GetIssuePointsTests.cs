using NUnit.Framework;
using System.Net;
using System.Runtime.CompilerServices;
using Newtonsoft;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using System;
using Newtonsoft.Json.Linq;

namespace SapphireApiFramework
{
    [Parallelizable(ParallelScope.All)]
    public class GetIssuePointsTests : PortalEndpoints
    {
        [TestCase(TestName = "200, ОК")]
        public void ResponseCodeIs200()
        {
            var callData = new EndpointCallData("?uid=", 5, Enviroment, Auth);

            var response = GetIssuePoints(callData);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            AssertNew.IsResponseInArray(response);

/*            JSchemaGenerator generator = new JSchemaGenerator();
            {
                generator.SchemaLocationHandling = SchemaLocationHandling.Inline;
            }
            JSchema expectedJsonSchema = generator.Generate(typeof(IssuePointsJson));
            JArray parsedArray = JArray.Parse(response.Content);
            JObject actualJsonSchema = JObject.Parse(parsedArray[0].ToString());

            Assert.AreEqual(expectedJsonSchema, actualJsonSchema);*/

        }

        [TestCase(TestName = "400, Отсутствует Организация с указанным идентификатором")]
        public void SpeicifiedOrgIsNotPresent()
        {
            var callData = new EndpointCallData("?uid=", 2, Enviroment, Auth);

            var response = GetIssuePoints(callData);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            AssertNew.IsResponseInArray(response);
            Assert.AreEqual("1", AssertNew.ParseArrayResponseCode(response));
            Assert.AreEqual("Отсутствует Организация с указанным идентификатором", AssertNew.ParseArrayResponseMessage(response));
        }

        [TestCase(TestName = "400, Отсутствует ?uid= и значение uid")]
        public void NoUidParam()
        {
            var callData = new EndpointCallData(Enviroment, Auth);

            var response = GetIssuePoints(callData);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);


        }

        [TestCase(TestName = "400, Отсутствует значение uid")]
        public void NoUidValue()
        {
            var callData = new EndpointCallData("?uid=", Enviroment, Auth);

            var response = GetIssuePoints(callData);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}