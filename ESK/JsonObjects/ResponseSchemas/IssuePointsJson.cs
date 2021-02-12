using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Framework.Api.Systems
{
    public class IssuePointsJson
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

    public class Geolocation
    {
        public Point x;
        public Point y;
    }

    public class Organization
    {
        public int id;
        public string name;
        public bool isBankCardIssuer;
        public bool isNonFinancialCardIssuer;
        public string iconUrl;
    }
}