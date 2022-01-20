using GringottsBank.Application.Interfaces;
using GringottsBank.Domain.Transactions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GringottsBank.Application.TransactionEvents
{
    public class TransactionOccuredHandler : INotificationHandler<TransactionCreatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        public TransactionOccuredHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Handle(TransactionCreatedEvent notification, CancellationToken cancellationToken)
        {

            _unitOfWork.TransactionRepository.AddTransaction(new BankTransaction(notification.AccountId,
                                                                                 notification.Amount,
                                                                                 notification.Balance,
                                                                                 DateTime.Now,
                                                                                 notification.Type,
                                                                                 notification.Description));
            _unitOfWork.Complete();
            return Task.CompletedTask;
        }


    }
}
