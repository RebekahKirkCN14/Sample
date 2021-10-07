using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSample.Middleware.Responses
{
    public class EmployeeResponse
    {
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public int CardNumber { get; set; }
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string CompanyName { get; set; }
        public string Balance { get; set; }
    }
}
