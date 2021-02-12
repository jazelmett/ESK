using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Framework.Api.Systems;

namespace Framework.Api.Portal
{
    [Parallelizable(ParallelScope.All)]
    class PostFeedback : PortalEndpoints
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

            var callData = new PortalData(Enviroment, Auth, parameters, files);

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

            var callData = new PortalData(Enviroment, Auth, parameters);

            var response = PostFeedback(callData);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}

