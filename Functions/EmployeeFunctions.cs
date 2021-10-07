using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AutoMapper;
using ApiSample.Middleware.Interfaces;
using ApiSample.Middleware.Commands;
using ApiSample.Middleware.Requests;

namespace ApiSample.Functions
{
    public class EmployeeFunctions
    {
        private const string defaultGuid = "00000000-0000-0000-0000-000000000000";
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeFunctions> _logger;

        public EmployeeFunctions(IEmployeeService employeeService, IMapper mapper, ILogger<EmployeeFunctions> logger)
        {
            this._employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            this._logger = logger;
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [FunctionName("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "employee")] [FromBody] CreateEmployeeRequest request)
        {
            var command = _mapper.Map<CreateEmployeeCommand>(request);
            command.Username = "system";
            command.EmployeeId = Guid.NewGuid();
            _logger.LogInformation("C# Trigger create new customer");

            try
            {
                await _employeeService.CreateEmployee(command);
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            return new OkObjectResult(command.EmployeeId);
        }

        [FunctionName("TopUpCard")]
        public async Task<IActionResult> TopUpCard(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "topupcard")][FromBody] TopUpCardRequest request)
        {

            var command = _mapper.Map<TopUpCardCommand>(request);
            command.Username = "system";
            _logger.LogInformation("C# HTTP Trigger PUT - top up card");

            try
            {
                var balance = await _employeeService.TopUpCard(command);
                return new OkObjectResult($"Top Up Sucessful - Your new balance is {balance}");
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }


        [FunctionName("SpendOnCard")]
        public async Task<IActionResult> SpendOnCard(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "spendoncard")][FromBody] SpendOnCardRequest request)
        {
            var command = _mapper.Map<SpendOnCardCommand>(request);
            command.Username = "system";
            _logger.LogInformation("C# HTTP Trigger PUT - top up card");

            try
            {
                await _employeeService.SpendOnCard(command);
                return new OkObjectResult($"Payment complete, thank you.");
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }

}

    

