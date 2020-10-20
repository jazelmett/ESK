using System.Net;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace SapphireApiFramework
{
    [Parallelizable(ParallelScope.All)]
    class PostFeedbackTests : PortalEndpoints
    {
        [TestCase(TestName = "400, Размер файла > 14mb")]
        public void ResponseCodeIs400WithLargeFile()
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

            var response = PostFeedback(callData);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestCase(TestName = "200, Без файла.")]
        public void ResponseCodeis200NoFilePassed()
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

            var response = PostFeedback(callData);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}

