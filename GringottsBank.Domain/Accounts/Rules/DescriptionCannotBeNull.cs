using GringottsBank.Domain.SeedWork;


namespace GringottsBank.Domain.Accounts.Rules
{
    public class DescriptionCannotBeNull : IBusinessRule
    {
        private readonly string _description;
        public DescriptionCannotBeNull(string description)
        {
            _description = description;
        }

        public string Message => MessageConstants.DescriptionCannotBeNull;

        public bool IsBroken() => _description == null;
    }
}
