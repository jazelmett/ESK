using NUnit.Framework;
using System.Net;
using Framework.Api.Systems;

namespace Framework.Api.Portal
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
                birthDate = "11.07.2018",
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

            payload.contacts.mobilePhone = "+79995196919";
            payload.contacts.email = "testmail10@atlas.com";
            payload.docs.passport.num = "8748345672";
            payload.docs.snils = "11809469473";

            var callData = new PortalData(Enviroment, Auth, payload);
            var response = PostRegisterClient(callData);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}