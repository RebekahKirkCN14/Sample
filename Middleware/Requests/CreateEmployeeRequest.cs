using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSample.Middleware.Requests
{
    public class CreateEmployeeRequest
    { 
        [JsonProperty("modifieddate")]
        public DateTime ModifiedDate { get; set; }

        [JsonProperty("modifiedby")]
        public string ModifiedBy { get; set; }

        [JsonProperty("cardnumber")]
        public int CardNumber { get; set; }

        [JsonProperty("employeeid")]
        public Guid EmployeeId { get; set; }

        [JsonProperty("employeename")]
        public string EmployeeName { get; set; }

        [JsonProperty("companyname")]
        public string CompanyName { get; set; }

        [JsonProperty("balance")]
        public int Balance { get; set; }

        
    }
}
