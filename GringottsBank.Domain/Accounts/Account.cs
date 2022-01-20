using GringottsBank.Domain.Accounts.Rules;
using GringottsBank.Domain.SeedWork;
using System;


namespace GringottsBank.Domain.Accounts
{
    public class Account : EntityObject
    {
        public Guid CustomerId { get; set; }
        public string Description { get; set; }
        public decimal Balance { get; set; }
     
        public static Account Create(Guid id,Guid customerId,string desription, decimal startingBalance)
        {
            CheckRule(new IdCannotBeNull(id));
            CheckRule(new IdCannotBeNull(customerId));
            CheckRule(new DescriptionCannotBeNull(desription));
            CheckRule(new BalanceCannotBeNegative(startingBalance));

            var account = new Account
            {
                Id = id,
                CustomerId = customerId,
                Description = desription,
                Balance = startingBalance
            };

            return account;
        }
       
        public object padlock = new();
        public void IncreaseBalance(decimal amount)
        {
            lock (padlock)
            {                
                Balance += amount;
            }
        }
        public void DecreaseBalance(decimal amount)
        {
            lock (padlock)
            {
                Balance -= amount;
            }

        }

    }
}
