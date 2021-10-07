using ApiSample.Middleware.Entities;
using ApiSample.Middleware.Interfaces;
using ApiSample.Middleware.Respositories;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

[assembly: FunctionsStartup(typeof(ApiSample.Functions.Startup))]

namespace ApiSample.Functions
{
    public  class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = new Config
            {
                ConnectionString = Environment.GetEnvironmentVariable("ConnectionString")
            };
            builder.Services.AddLogging();
            builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
            builder.Services.AddAutoMapper(Assembly.GetAssembly(this.GetType()));
            builder.Services.AddSingleton<ISqlRepository, SqlRepository>(s => new SqlRepository(config.ConnectionString.ToString()));
        }
    }
}
