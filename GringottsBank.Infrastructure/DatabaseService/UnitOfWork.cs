using GringottsBank.Application.Interfaces;


namespace GringottsBank.Infrastructure.DatabaseService
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        
        public IAccountRepository AccountRepository { get; }
        public ICustomerRepository CustomerRepository { get; }
        public ITransactionRepository TransactionRepository { get; }
      
        public UnitOfWork(IAccountRepository accountRepository,
                          ICustomerRepository customerRepository,
                          ITransactionRepository transactionRepository,
                          AppDbContext context)
        {
                     
            AccountRepository = accountRepository;
            CustomerRepository = customerRepository;
            TransactionRepository = transactionRepository;
            _context = context;
        }
  
        public void Complete()
        {           
            _context.SaveChanges();
        }

        public void Dipsose()
        {
            _context.Dispose();
        }
    }
}
