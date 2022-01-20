using System;

namespace GringottsBank.Application.CustomerServices.Dto
{
    public class GetCustomerAccountDetailsDto
    {
        public Guid CustomerId { get; set; }
        public Guid AccountId { get; set; }
    }
}
