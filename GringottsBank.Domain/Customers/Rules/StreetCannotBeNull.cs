using GringottsBank.Domain.SeedWork;

namespace GringottsBank.Domain.Customers.Rules
{
    public class StreetCannotBeNull : IBusinessRule
    {
        private readonly string _street;
        public StreetCannotBeNull(string street)
        {
            _street = street;
        }

        public string Message => MessageConstants.StreetCannotBeNullMessage;

        public bool IsBroken() => _street == null;
    }
}
