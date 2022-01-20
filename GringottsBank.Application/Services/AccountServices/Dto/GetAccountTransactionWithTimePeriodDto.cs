using System;

namespace GringottsBank.Application.AccountServices.Dto
{
    public class GetAccountTransactionWithTimePeriodDto
    {
        public Guid AccountId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
