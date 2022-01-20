using GringottsBank.Domain.Accounts;
using System;


namespace GringottsBank.Application.AccountServices.Dto
{
    public class AccountDto
    {
        public Guid CustomerId { get; set; }
        public string Description { get; set; }
        public decimal Balance { get; set; }
    }
}
