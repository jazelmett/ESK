using NUnit.Framework;
using System.Net;
using System.Runtime.CompilerServices;
using Newtonsoft;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using System;
using Newtonsoft.Json.Linq;
using Framework.Api.Systems;

namespace Framework.Api.Portal
{
    [Parallelizable(ParallelScope.All)]
    public class GetIssuePoints : PortalEndpoints
    {
        [TestCase(TestName = "200, ОК")]
        public void ResponseCodeIs200()
        {
            var callData = new PortalEndpointData(OptionalParam.uid, "5", Enviroment, Auth);
            var response = GetIssuePoints(callData);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assertions.IsResponseInArray(response);
/*
            JSchemaGenerator generator = new JSchemaGenerator();
            {
                generator.SchemaLocationHandling = SchemaLocationHandling.Inline;
            }

            JSchema expectedJsonSchema = generator.Generate(typeof(IssuePointsJson));

            JArray parsedArray = JArray.Parse(response.Content);
            JObject actualJsonSchema = JObject.Parse(parsedArray[0].ToString());

            var isValid = parsedArray.IsValid(expectedJsonSchema);

            Assert.AreEqual(expectedJsonSchema, parsedArray);*/
        }

        [TestCase(TestName = "400, Отсутствует Организация с указанным идентификатором")]
        public void SpeicifiedOrgIsNotPresent()
        {
            var callData = new PortalEndpointData(OptionalParam.uid, "2", Enviroment, Auth);

            var response = GetIssuePoints(callData);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assertions.IsResponseInArray(response);
            Assert.AreEqual("1", Assertions.ParseArrayResponseCode(response));
            Assert.AreEqual("Отсутствует Организация с указанным идентификатором", Assertions.ParseArrayResponseMessage(response));
        }

        [TestCase(TestName = "400, Отсутствует ?uid= и значение uid")]
        public void NoUidParam()
        {
            var callData = new PortalEndpointData(Enviroment, Auth);
            var response = GetIssuePoints(callData);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestCase(TestName = "400, Отсутствует значение uid")]
        public void NoUidValue()
        {
            var callData = new PortalEndpointData("?uid=", Enviroment, Auth);
            var response = GetIssuePoints(callData);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}