using GringottsBank.Domain.Transactions;
using MediatR;
using System;

namespace GringottsBank.Application.TransactionEvents
{
    public class TransactionCreatedEvent : INotification
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Balance { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }

        public TransactionCreatedEvent(Guid id,Guid accountId,DateTime date, TransactionType type,decimal balance,decimal amount)
        {
            Id = id;
            AccountId = accountId;
            Date = date;
            Description = "";
            Type = type;
            Balance = balance;
            Amount = amount;
        }
    }
}
