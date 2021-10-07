using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSample.Middleware.Requests
{
   public class TopUpCardRequest
    {
        [JsonProperty("employeeid")]
        public Guid EmployeeId { get; set; }

        [JsonProperty("cardnumber")]
        public int CardNumber { get; set; }

        [JsonProperty("balance")]
        public string Balance { get; set; }
    }
}
