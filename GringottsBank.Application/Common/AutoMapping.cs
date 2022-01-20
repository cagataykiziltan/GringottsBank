using AutoMapper;
using GringottsBank.Application.AccountServices.Dto;
using GringottsBank.Domain.Accounts;
using GringottsBank.Domain.Customers;
using GringottsBank.Domain.Transactions;
using GringottsBank.Infrastructure.DatabaseService.AccountRepositories;
using GringottsBank.Infrastructure.DatabaseService.CustomerRepositories;
using GringottsBank.Infrastructure.DatabaseService.TransactionRepositories;

namespace GringottsBank.Infrastructure.MappingProfile
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            ConfigureMappings();
        }

        private void ConfigureMappings()
        {
            CreateMap<Account, AccountDto>();
            CreateMap<BankTransaction, BankTransactionDto>();

            CreateMap<BankTransaction, TransactionDbModel>().ReverseMap();
            CreateMap<Customer, CustomerDbModel>().ReverseMap();
            CreateMap<Account, AccountDbModel>().ReverseMap();

            CreateMap<BankTransaction, BankTransactionDto>();
            CreateMap<BankTransaction, BankTransactionDto>();

        }

    }
}
