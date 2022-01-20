
using GringottsBank.Domain.SeedWork;

namespace GringottsBank.Domain.Customers.Rules
{
    public class StateCannotBeNull : IBusinessRule
    {
        private readonly string _state;
        public StateCannotBeNull(string state)
        {
            _state = state;
        }

        public string Message => MessageConstants.StateCannotBeNullMessage;

        public bool IsBroken() => _state == null;
    }
}
