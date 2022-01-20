
using System;

namespace GringottsBank.Infrastructure.DatabaseService.AccountRepositories
{
    public class AccountDbModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Description { get; set; }
        public decimal Balance { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public AccountDbModel(Guid customerId, string description, decimal balance)
        {
            CustomerId = customerId;
            Description = description;
            Balance = balance;

        }
    }
}
