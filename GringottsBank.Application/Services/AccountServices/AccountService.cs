using AutoMapper;
using GringottsBank.Application.AccountServices.Dto;
using GringottsBank.Application.Common;
using GringottsBank.Application.Interfaces;
using GringottsBank.Application.TransactionEvents;
using GringottsBank.Domain.Accounts;
using GringottsBank.Domain.SeedWork;
using GringottsBank.Domain.Transactions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GringottsBank.Application.AccountServices
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public AccountService(IUnitOfWork unitOfWork, 
                              IMediator mediator,
                              IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _mapper = mapper;
        }

    

        [LoggerAspect]
        public async Task<Guid> CreateAccount(AccountCreateDto accountDto)
        {
                       
            if (accountDto == null)
                throw new Exception(MessageConstants.NullParemeter);

            var customer = await _unitOfWork.CustomerRepository.GetCustomerById(accountDto.CustomerId);

            if (customer == null)
                throw new Exception(MessageConstants.CustomerNotFound);

            var account = Account.Create(Guid.NewGuid(), accountDto.CustomerId, accountDto.Description, accountDto.Balance);

            var accountId = await _unitOfWork.AccountRepository.CreateAccount(account);

            if (accountId == Guid.Empty)
                throw new Exception(MessageConstants.AccountCouldNotCreated);

            _unitOfWork.Complete();
        
            return accountId;

        }

        [LoggerAspect]
        public async Task AddMoney(AddMoneyDto addMoneyDto)
        {
            if (addMoneyDto == null)
                throw new Exception(MessageConstants.NullParemeter);

            var account = await _unitOfWork.AccountRepository.GetAccountDetails(addMoneyDto.AccountId);

            if (account == null)
                throw new Exception(MessageConstants.AccountNotFound);

            account.IncreaseBalance(addMoneyDto.Amount);
          
            _unitOfWork.AccountRepository.UpdateBalanceAccount(account);
            _unitOfWork.Complete();

             await _mediator.Publish(new TransactionCreatedEvent(new Guid(),account.Id,new DateTime(), TransactionType.AddMoney,account.Balance,addMoneyDto.Amount),new CancellationToken());

        }

        [LoggerAspect]
        public async Task WithDrawMoney(WithdrawMoneyDto withdrawMoneyDto)
        {
            if (withdrawMoneyDto == null)
                throw new Exception(MessageConstants.NullParemeter);

            var account =await  _unitOfWork.AccountRepository.GetAccountDetails(withdrawMoneyDto.AccountId);

            if (account == null)
                throw new Exception(MessageConstants.AccountNotFound);

            if (withdrawMoneyDto.Amount > account.Balance)
                throw new Exception(MessageConstants.InsufficientBalance);

            account.DecreaseBalance(withdrawMoneyDto.Amount);
           
             _unitOfWork.AccountRepository.UpdateBalanceAccount(account);
            _unitOfWork.Complete();

            await _mediator.Publish(new TransactionCreatedEvent(new Guid(), account.Id, new DateTime(), TransactionType.WithdrawMoney, account.Balance, withdrawMoneyDto.Amount), new CancellationToken());
        }

        [LoggerAspect]
        public async Task<List<BankTransactionDto>> GetAccountAllTransaction(GetAccountTransactionDto getAccountTransactionDto)
        {
            if (getAccountTransactionDto == null)
                throw new Exception(MessageConstants.NullParemeter);

            var transactions = await _unitOfWork.TransactionRepository.GetAccountTranscation(getAccountTransactionDto.AccountId);

            if (transactions == null)
                throw new Exception(MessageConstants.NullParemeter);

            if (transactions.Count == 0)
                throw new Exception(MessageConstants.ZeroCount);

            var transactionsDto = _mapper.Map<List<BankTransactionDto>>(transactions);

            return transactionsDto;
        }

        [LoggerAspect]
        public async Task<List<BankTransactionDto>> GetAccountTransactionBetweenPeriod(GetAccountTransactionWithTimePeriodDto transactionWithTimePeriodDto)
        {
            if (transactionWithTimePeriodDto == null)
                throw new Exception(MessageConstants.NullParemeter);

            var transactions = await _unitOfWork.TransactionRepository.GetAccountTranscationWithTime(transactionWithTimePeriodDto.AccountId,
                                                                                                     transactionWithTimePeriodDto.StartDate, 
                                                                                                    transactionWithTimePeriodDto.EndDate);
            if (transactions == null)
                throw new Exception(MessageConstants.NullParemeter);

            if (transactions.Count == 0)
                throw new Exception(MessageConstants.ZeroCount);

            var transactionsDto = _mapper.Map<List<BankTransactionDto>>(transactions);

            return transactionsDto;
        }

    }
}
