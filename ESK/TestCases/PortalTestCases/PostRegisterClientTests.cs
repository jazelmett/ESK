using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using NUnit.Framework;

namespace SapphireApiFramework
{
    [Parallelizable(ParallelScope.All)]
    class PostRegisterClient : PortalEndpoints
    {
        [TestCase(TestName = "400, Клиент с указанным СНИЛС уже зарегистрирован")]
        public void CustomerWithSpecifiedSnilsAlreadyRegistered()
        {
            var payload = new RegisterClientJson
            {
                firstName = "Тестов",
                lastName = "Тест",
                middleName = "Тестович",
                birthDate = "01.01.2018",
                birthPlace = "Свердловская обл. г. Екатеринбург",
                sex = 1,
                contacts = new Contacts
                {
                    address = "Екатеринбург, ул. Гоголя, д. 36, оф. 900",
                    mobilePhone = "+799999999123",
                    email = "testmail70@atlas.com",
                },
                events = new Events
                {
                    isSms = true,
                    isEmail = false
                },
                docs = new Docs
                {
                    passport = new Passport
                    {
                        num = "8748345671",
                        date = "08.07.2016",
                        codeOrg = "660123",
                        org = "ОТДЕЛЕНИЕМ УФМС РОССИИ ПО СВЕРДЛОВСКОЙ ОБЛАСТИ ГОР. ЕКАТЕРИНБУРГ",
                        addressReg = "г. Екатеринбург, ул. Учителей, д. 15"
                    },
                    snils = "66405463397"
                }
            };

            var callData = new PortalEndpointData(payload, Enviroment, Auth);
            var response = PostRegisterClient(callData);


            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
