
using GringottsBank.Application.AccountServices.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GringottsBank.Application.Interfaces
{
    public interface IAccountService
    {
        Task<Guid> CreateAccount(AccountCreateDto accountDto);
        Task AddMoney(AddMoneyDto addMoneyDto);
        Task WithDrawMoney(WithdrawMoneyDto withdrawMoneyDto);
        Task<List<BankTransactionDto>> GetAccountAllTransaction(GetAccountTransactionDto getAccountTransactionDto);
        Task<List<BankTransactionDto>> GetAccountTransactionBetweenPeriod(GetAccountTransactionWithTimePeriodDto transactionWithTimePeriodDto);
    }
}
