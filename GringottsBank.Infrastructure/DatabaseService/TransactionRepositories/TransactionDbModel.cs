using GringottsBank.Domain.Transactions;
using System;

namespace GringottsBank.Infrastructure.DatabaseService.TransactionRepositories
{
    public class TransactionDbModel
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public DateTime Date { get; set; }
        public TransactionType Type { get; set; }
        public string Description { get; set; }
    }
}
