using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.Middleware.Interfaces
{
    public interface ISqlRepository
    {
        Task CreateEmployeeAsync(DateTime modifiedDate, string modifiedBy, int cardNumber, Guid employeeId, string employeeName, string companyName, int balance);
        Task TopUpCardAsync(string cardNumber, string balance, Guid employeeId);
        Task SpendOnCardAsync(string cardNumber, string balance, Guid employeeId);
        Task<string> GetBalanceAsync(string cardNumber);
        
    }
}
