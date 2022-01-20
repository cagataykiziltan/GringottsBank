using System;

namespace GringottsBank.Application.AccountServices.Dto
{
    public class WithdrawMoneyDto
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }

    }
}
