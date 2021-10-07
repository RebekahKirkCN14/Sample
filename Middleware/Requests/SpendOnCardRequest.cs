using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSample.Middleware.Requests
{
    public class SpendOnCardRequest
    {
        [JsonProperty("employeeid")]
        public Guid EmployeeId { get; set; }

        [JsonProperty("cardnumber")]
        public string CardNumber { get; set; }

        [JsonProperty("balance")]
        public string Balance { get; set; }
    }
}
