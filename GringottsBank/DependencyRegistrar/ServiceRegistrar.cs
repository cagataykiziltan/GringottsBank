using GringottsBank.Application.AccountServices;
using GringottsBank.Application.CustomerServices;
using GringottsBank.Application.Interfaces;
using GringottsBank.Application.TransactionEvents;
using GringottsBank.Infrastructure.DatabaseService;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GringottsBank.DependencyRegistrar
{
    public static class ServiceRegistrar
    {
        public static void RegisterCustomServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(TransactionCreatedEvent).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CustomerRepository).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(AccountRepository).GetTypeInfo().Assembly);

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();


        }
    }
}
