using System.Net;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace SapphireApiFramework
{
    [Parallelizable(ParallelScope.All)]
    class APostFeedbackTests : PortalEndpoints
    {
        [TestCase(TestName = "400, С файлом > 14mb")]
        public async Task ResponseCodeIs400WithLargeFile()
        {
            var parameters = new Dictionary<string, string>
            {
                {"subject_id","2"},
                {"body","Привет"},
                {"name","dd"},
                {"lastname","aa"},
                {"answer_method","0"},
                {"phone","1111111334"},
                {"email","adc@atlas.com"}
            };

            var files = new Dictionary<string, string>
            {
                {"file[]", @"C:\FileUpload\feedbackuplaod\Harvey Excel 1.pdf"}
            };

            var callData = new EndpointCallData(parameters, files, Enviroment, Auth);

            var response = await PostFeedback(callData);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Parallelizable(ParallelScope.All)]
        [TestCase(TestName = "200, Без файла.")]
        public async Task ResponseCodeis200NoFilePassed()
        {
            var parameters = new Dictionary<string, string>
            {
                {"subject_id","2"},
                {"body","Привет"},
                {"name","dd"},
                {"lastname","aa"},
                {"answer_method","0"},
                {"phone","1111111334"},
                {"email","adc@atlas.com"}
            };

            var callData = new EndpointCallData(parameters, Enviroment, Auth);

            var response = await PostFeedback(callData);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}

