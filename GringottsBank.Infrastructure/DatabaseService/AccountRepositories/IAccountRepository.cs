using GringottsBank.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GringottsBank.Application.Interfaces
{
    public interface IAccountRepository
    {
        Task<Guid> CreateAccount(Account entity);
        Task<List<Account>> GetCustomersAllAccount(Guid customerId);
        void UpdateBalanceAccount(Account entity);
        Task<Account> GetAccountDetails(Guid id);


    }
}
