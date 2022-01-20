using System;

namespace GringottsBank.Application.AccountServices.Dto
{
    public class AddMoneyDto
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }

    }
}
