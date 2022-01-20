
using GringottsBank.Domain.SeedWork;

namespace GringottsBank.Domain.Customers.Rules
{
    public class CityCannotBeNull : IBusinessRule
    {
        private readonly string _city;
        public CityCannotBeNull(string city)
        {
            _city = city;
        }

        public string Message => MessageConstants.CityCannotBeNullMessage;

        public bool IsBroken() => _city == null;
    }
}
