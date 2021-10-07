using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSample.Middleware.Commands
{
    public class BaseCommand
    {
        public BaseCommand()
        {
            this.CorrelationId = Guid.NewGuid().ToString();
        }
        public string Username { get; set; }
        public string CorrelationId { get; set; }
    }
}
