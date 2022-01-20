

namespace GringottsBank.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IAccountRepository AccountRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        void Complete();
        void Dipsose();

    }
}
