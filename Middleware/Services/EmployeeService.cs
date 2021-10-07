using ApiSample.Middleware.Interfaces;
using ApiSample.Middleware.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApiSample.Middleware.Commands;

namespace ApiSample.Middleware.Respositories
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ISqlRepository _sqlRepository;

        public EmployeeService(ISqlRepository sqlRepository)
        {
            this._sqlRepository = sqlRepository;
        }
        public async Task CreateEmployee(CreateEmployeeCommand command)
        {
            await _sqlRepository.CreateEmployeeAsync(command.ModifiedDate, command.ModifiedBy, command.CardNumber, command.EmployeeId, command.EmployeeName, command.CompanyName, command.Balance);
        }
        public async Task<string> TopUpCard(TopUpCardCommand command)
        {
            var currentBalance = await _sqlRepository.GetBalanceAsync(command.CardNumber);
            var newBalance = Int32.Parse(currentBalance) + Int32.Parse(command.Balance);
            await _sqlRepository.TopUpCardAsync(command.CardNumber, newBalance.ToString(), command.EmployeeId);
            return newBalance.ToString();
        }
        public async Task<string> SpendOnCard(SpendOnCardCommand command)
        {
            var currentBalance = await _sqlRepository.GetBalanceAsync(command.CardNumber);

            if (Int32.Parse(command.Balance) >= Int32.Parse(currentBalance))
            {
                return ("Your available balance is less than your required spend, please top up first.");
            }
            else
            {   
                var newBalance = Int32.Parse(currentBalance) - Int32.Parse(command.Balance);
                await _sqlRepository.SpendOnCardAsync(command.CardNumber, newBalance.ToString(), command.EmployeeId);
                return newBalance.ToString();
            }
        }
    }
}
