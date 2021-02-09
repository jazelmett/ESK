using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Api.Systems
{
    public class RegisterClientJson
    {
        public string firstName;
        public string lastName;
        public string middleName;
        public string birthDate;
        public string birthPlace;
        public int sex;
        public Contacts contacts;
        public Events events;
        public Docs docs;
    }

    public class Contacts
    {
        public string address;
        public string mobilePhone;
        public string email;
    }
    public class Events
    {
        public bool isSms;
        public bool isEmail;
    }
    public class Docs
    {
        public Passport passport;
        public string snils;
    }
    public class Passport
    {
        public string num;
        public string date;
        public string codeOrg;
        public string org;
        public string addressReg;
    }
}



