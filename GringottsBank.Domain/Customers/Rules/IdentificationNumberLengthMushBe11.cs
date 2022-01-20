using GringottsBank.Domain.SeedWork;


namespace GringottsBank.Domain.Customers.Rules
{
   
    public class IdentificationNumberLengthMushBe11 : IBusinessRule
    {
        private readonly string _idN;
        public IdentificationNumberLengthMushBe11(string idNo)
        {
            _idN = idNo;
        }

        public string Message => MessageConstants.IdentificationNumberLengthMushBe11;

        public bool IsBroken() => _idN.Length != 11;
    }
}
