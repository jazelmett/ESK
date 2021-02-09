using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Framework.Api.Systems
{
    class IssuePointsJson
    {
        public string id;
        public string name;
        public string address;
        public string phone;
        public string operationMode;
        public Geolocation geolocation;
        public int city;
        public Organization organization;
    }

    class Geolocation
    {
        public Point x;
        public Point y;
    }

    class Organization
    {
        public int id;
        public string name;
        public bool isBankCardIssuer;
        public bool isNonFinancialCardIssuer;
        public string iconUrl;
    }
}