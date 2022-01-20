using AutoMapper;
using GringottsBank.Application.AccountServices.Dto;
using GringottsBank.Application.Common;
using GringottsBank.Application.CustomerServices.Dto;
using GringottsBank.Application.Interfaces;
using GringottsBank.Domain.Customers;
using GringottsBank.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GringottsBank.Application.CustomerServices
{
    
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
      
           public CustomerService(IUnitOfWork unitOfWork,
                                  IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        [LoggerAspect]
        public async Task<Guid> CreateCustomer(CustomerCreateDto customerDto)
        {
            if (customerDto == null)
                throw new Exception(MessageConstants.NullParemeter);

            var isCustomerAlreadyExist = _unitOfWork.CustomerRepository.GetCustomerByIdentificationNo(customerDto.IdentificationNo);

            if(isCustomerAlreadyExist)
                throw new Exception(MessageConstants.CustomerAlreadyExist);

            var customer = Customer.Create(Guid.NewGuid(), customerDto.IdentificationNo, customerDto.Name, customerDto.Surname, customerDto.PhoneNumber, customerDto.Street, customerDto.City, customerDto.State);

            var customerId =  await _unitOfWork.CustomerRepository.CreateCustomer(customer);

            if (customerId == Guid.Empty)
                throw new Exception(MessageConstants.AccountCouldNotCreated);

            _unitOfWork.Complete();

            return customerId;
        }

        [LoggerAspect]     
        public async Task<List<AccountDto>> GetAllCustomerAccounts(GetCustomerAccountsDto getCustomerAccountsDto)
        {
            if (getCustomerAccountsDto == null)
                throw new Exception(MessageConstants.NullParemeter);

            var customer = await _unitOfWork.CustomerRepository.GetCustomerById(getCustomerAccountsDto.CustomerId);

            if (customer == null)
                throw new Exception(MessageConstants.CustomerNotFound);

            var accounts = await _unitOfWork.AccountRepository.GetCustomersAllAccount(getCustomerAccountsDto.CustomerId);

            if (accounts == null)
                throw new Exception(MessageConstants.NullParemeter);

            if (accounts.Count == 0)
                throw new Exception(MessageConstants.ZeroCount);

            var accountsDto = _mapper.Map<List<AccountDto>>(accounts);

            return accountsDto;

        }
       
        [LoggerAspect]
        public async Task<AccountDto> GetCustomerAccountDetails(GetCustomerAccountDetailsDto getCustomerAccountDetailsDto)
        {
            if (getCustomerAccountDetailsDto == null)
                throw new Exception(MessageConstants.NullParemeter);

            var customer =await _unitOfWork.CustomerRepository.GetCustomerById(getCustomerAccountDetailsDto.CustomerId);

            if (customer==null)
                throw new Exception(MessageConstants.CustomerNotFound);

            var account = await _unitOfWork.AccountRepository.GetAccountDetails(getCustomerAccountDetailsDto.AccountId);

            if (account == null)
                throw new Exception(MessageConstants.NullParemeter);

            var accountDto = _mapper.Map<AccountDto>(account);

            return accountDto;
        }
    }
}
