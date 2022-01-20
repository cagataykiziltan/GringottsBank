using GringottsBank.Domain.SeedWork;

namespace GringottsBank.Domain.Customers.Rules
{
    public class NameCannotBeNull : IBusinessRule
    {
        private readonly string _name;
        public NameCannotBeNull(string name)
        {
            _name = name;
        }

        public string Message => MessageConstants.NameCannotBeNullMessage;

        public bool IsBroken() => _name == null;
    }
}
