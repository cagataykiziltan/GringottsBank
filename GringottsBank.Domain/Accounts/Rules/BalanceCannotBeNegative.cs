using GringottsBank.Domain.SeedWork;


namespace GringottsBank.Domain.Accounts.Rules
{
    public class BalanceCannotBeNegative : IBusinessRule
    {
        private readonly decimal _balance;
        public BalanceCannotBeNegative(decimal balance)
        {
            _balance = balance;
        }

        public string Message => MessageConstants.BalanceCannotBeNegative;

        public bool IsBroken() => _balance < 0;
    }
}
