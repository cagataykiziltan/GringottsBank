
using GringottsBank.Domain.Customers;
using System;
using System.Threading.Tasks;

namespace GringottsBank.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Guid> CreateCustomer(Customer entity);
        Task<Customer> GetCustomerById(Guid id);
        bool GetCustomerByIdentificationNo(string identificationNumber);
       
    }
}
