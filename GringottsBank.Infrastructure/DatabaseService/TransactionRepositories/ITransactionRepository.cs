
using GringottsBank.Domain.Transactions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GringottsBank.Application.Interfaces
{
    public interface ITransactionRepository
    {
       Task AddTransaction(BankTransaction entity);
       Task<List<BankTransaction>> GetAccountTranscation(Guid id);
       Task<List<BankTransaction>> GetAccountTranscationWithTime(Guid id, DateTime startDate, DateTime endDate);
    }
}
