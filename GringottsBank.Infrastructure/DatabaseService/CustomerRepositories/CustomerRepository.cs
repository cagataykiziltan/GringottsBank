using AutoMapper;
using GringottsBank.Application.Interfaces;
using GringottsBank.Domain.Customers;
using GringottsBank.Infrastructure.DatabaseService.CustomerRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GringottsBank.Infrastructure.DatabaseService
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CustomerRepository(AppDbContext context,
                                 IMapper mapper)
        {
      
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> CreateCustomer(Customer entity)
        {
            var dbModel = _mapper.Map<CustomerDbModel>(entity);
            dbModel.CreatedDate = DateTime.Now;

            await _context.Customer.AddAsync(dbModel);

            return dbModel.Id;

        }

        public async Task<Customer> GetCustomerById(Guid id)
        {
            var dbModel = await _context.Customer.FindAsync(id); 

            return _mapper.Map<Customer>(dbModel);
        }

        public bool GetCustomerByIdentificationNo(string identificationNumber)
        {
            return _context.Customer.Any(c => c.IdentificationNo == identificationNumber);
        }



    }
}
