using AutoMapper;
using GringottsBank.Application.Interfaces;
using GringottsBank.Domain.Accounts;
using GringottsBank.Infrastructure.DatabaseService.AccountRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GringottsBank.Infrastructure.DatabaseService
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public AccountRepository(AppDbContext context,
                                 IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAccount(Account entity)
        {
            var dbModel = _mapper.Map<AccountDbModel>(entity);
            dbModel.CreatedDate = DateTime.Now;

            await _context.AccountTable.AddAsync(dbModel);

            return dbModel.Id;
        }

        public async Task<Account> GetAccountDetails(Guid id)
        {
            var accountDbTable =await _context.AccountTable.FindAsync(id);

            return  _mapper.Map<Account>(accountDbTable); 
        }

        public void UpdateBalanceAccount(Account entity)
        {
                      
            var account =  _context.AccountTable.FirstOrDefault(x=>x.Id==entity.Id);
            account.Balance = entity.Balance;
            account.CreatedDate = DateTime.Now;
        }

        public async Task<List<Account>> GetCustomersAllAccount(Guid customerId)
        {
            var dbModelList = await _context.AccountTable.Where(a => a.CustomerId == customerId).ToListAsync(); 

            return _mapper.Map<List<Account>>(dbModelList);
        }


     

   

    }
}
