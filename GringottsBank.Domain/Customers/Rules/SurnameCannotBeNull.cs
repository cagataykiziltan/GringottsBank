using GringottsBank.Domain.SeedWork;

namespace GringottsBank.Domain.Customers.Rules
{
    public class SurnameCannotBeNull : IBusinessRule
    {
        private readonly string _surname;
        public SurnameCannotBeNull(string name)
        {
            _surname = name;
        }

        public string Message => MessageConstants.SurnameCannotBeNullMessage;

        public bool IsBroken() => _surname == null;
    }
}
