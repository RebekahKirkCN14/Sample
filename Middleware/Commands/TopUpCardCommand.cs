using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSample.Middleware.Commands
{
    public class TopUpCardCommand : BaseCommand
    {
        public string Balance { get; set; }
        public string CardNumber { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
