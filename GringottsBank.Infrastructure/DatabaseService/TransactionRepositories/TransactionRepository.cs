using AutoMapper;
using GringottsBank.Application.Interfaces;
using GringottsBank.Domain.Transactions;
using GringottsBank.Infrastructure.DatabaseService.TransactionRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GringottsBank.Infrastructure.DatabaseService
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public TransactionRepository(AppDbContext context,
                                     IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddTransaction(BankTransaction entity)
        {
            var dbModel = _mapper.Map<TransactionDbModel>(entity);
            await _context.TransactionTable.AddAsync(dbModel);
        }

        public async Task<List<BankTransaction>> GetAccountTranscation(Guid accountId)
        {

            var dbModelList =await _context.TransactionTable.Where(t=>t.AccountId==accountId).ToListAsync();

            return _mapper.Map<List<BankTransaction>>(dbModelList);
        }

        public async Task<List<BankTransaction>> GetAccountTranscationWithTime(Guid id, DateTime startDate, DateTime endDate)
        {
            var dbModelList = await _context.TransactionTable.Where(t => t.AccountId == id && t.Date >= startDate && t.Date <= endDate).ToListAsync();

            return _mapper.Map<List<BankTransaction>>(dbModelList);
        }

    }
}
