using ApiSample.Middleware.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.Middleware.Interfaces
{
  public interface IEmployeeService
    {
        Task CreateEmployee(CreateEmployeeCommand command);
        Task<string> TopUpCard(TopUpCardCommand command);
        Task<string> SpendOnCard(SpendOnCardCommand command);
    }
}
