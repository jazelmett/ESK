using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Api.Systems
{
    public class RegisterTransactionsJson
    {
        public string id;
        public string UID;
        public string NumESK;
        public string TransactionTimeStamp;
        public string DepartureDateTime;
        public string DeparturePoint;
        public string Destination;
        public string TariffZone;
        public double Sum;
        public string TicketNum;
        public string TicketCategory;
    }
}