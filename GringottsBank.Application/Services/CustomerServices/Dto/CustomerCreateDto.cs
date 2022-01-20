

namespace GringottsBank.Application.CustomerServices.Dto
{
    public class CustomerCreateDto
    {
        public string IdentificationNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
