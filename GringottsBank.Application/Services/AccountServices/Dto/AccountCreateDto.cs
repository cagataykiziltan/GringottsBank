using System;


namespace GringottsBank.Application.AccountServices.Dto
{
    public class AccountCreateDto
    {
        public Guid CustomerId { get; set; }
        public string Description { get; set; }
        public decimal Balance { get; set; }
    }
}
