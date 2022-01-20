
using GringottsBank.Domain.Transactions;
using System;

namespace GringottsBank.Application.AccountServices.Dto
{
    public class BankTransactionDto
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType Type { get; set; }
        public string Description { get; set; }
    }
}
