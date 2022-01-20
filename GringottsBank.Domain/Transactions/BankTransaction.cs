using GringottsBank.Domain.SeedWork;
using System;

namespace GringottsBank.Domain.Transactions
{
    public class BankTransaction : EntityObject
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public DateTime Date { get; set; }
        public TransactionType Type { get; set; }
        public string Description { get; set; }

        public BankTransaction(Guid accountId, decimal amount, decimal balance, DateTime date, TransactionType type, string description)
        {
            AccountId = accountId;
            Amount = amount;
            Balance = balance;
            Date = date;
            Type = type;
            Description = description;

        }
    }
}
