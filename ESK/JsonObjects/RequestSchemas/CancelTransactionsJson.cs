using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Api.Systems
{
    public class CancelTransactionsJson
    {
        public string id;
        public string BusStationID;
        public string dateTime;
        public int cancelReason;
    }
}
