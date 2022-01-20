using GringottsBank.Domain.SeedWork;


namespace GringottsBank.Domain.Customers.Rules
{
    public class PhoneNumberCannotBeNull : IBusinessRule
    {
        private readonly string _phone;
        public PhoneNumberCannotBeNull(string phone)
        {
            _phone = phone;
        }

        public string Message => MessageConstants.PhoneNoCannotBeNullMessage;

        public bool IsBroken() => _phone == null;
    }
}
