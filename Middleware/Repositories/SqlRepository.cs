using ApiSample.Helpers;
using ApiSample.Middleware.Interfaces;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace ApiSample.Middleware.Respositories
{
    public class SqlRepository : ISqlRepository
    {
        private readonly string _connectionString;

        public SqlRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string GetConnectionName()
        {
            return _connectionString.ToString();
        }

        public async Task CreateEmployeeAsync(DateTime modifiedDate, string modifiedBy, int cardNumber, Guid employeeId, string employeeName, string companyName, int balance)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                await sqlConnection.ExecuteAsync($"[dbo].[uspEmployeeCrud]", new
                {
                    modifiedDate,
                    modifiedBy,
                    cardNumber,
                    employeeId,
                    employeeName,
                    companyName,
                    balance,
                    Mode = SaveModeHelper.Create
                },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task TopUpCardAsync(string cardNumber, string balance, Guid employeeId)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                await sqlConnection.ExecuteAsync($"[dbo].[uspEmployeeCrud]", new
                {
                    cardNumber,
                    employeeId,
                    balance,
                    Mode = SaveModeHelper.Update
                },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task SpendOnCardAsync(string cardNumber, string balance, Guid employeeId)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                await sqlConnection.ExecuteAsync($"[dbo].[uspEmployeeCrud]", new
                {
                    cardNumber,
                    employeeId,
                    balance,
                    Mode = SaveModeHelper.Update
                },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<string> GetBalanceAsync(string cardNumber)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var balance = await sqlConnection.ExecuteScalarAsync($"[dbo].[uspEmployeeCrud]", new
                {
                    cardNumber,
                    Mode = SaveModeHelper.Balance
                },
                    commandType: CommandType.StoredProcedure);

                return balance.ToString();
            }
            
        }
    }
}
    

