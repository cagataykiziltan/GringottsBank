
using GringottsBank.Application.AccountServices.Dto;
using GringottsBank.Application.CustomerServices.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GringottsBank.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<Guid> CreateCustomer(CustomerCreateDto customerDto);

        Task<List<AccountDto>> GetAllCustomerAccounts(GetCustomerAccountsDto getCustomerAccountsDto);

        Task<AccountDto> GetCustomerAccountDetails(GetCustomerAccountDetailsDto getCustomerAccountDetailsDto);
    }
}
