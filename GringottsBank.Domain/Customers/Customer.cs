using GringottsBank.Domain.Accounts.Rules;
using GringottsBank.Domain.Customers.Rules;
using GringottsBank.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace GringottsBank.Domain.Customers
{
    public class Customer : EntityObject
    {
        public string IdentificationNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public List<CustomerAccount> Accounts { get; set; }
    

        public static Customer Create(Guid id,string identificationNo,string name, string surname, string phoneNumber, string street, string city, string state)
        {
            CheckRule(new IdCannotBeNull(id));
            CheckRule(new IdentificationNumberLengthMushBe11(identificationNo));
            CheckRule(new NameCannotBeNull(name));
            CheckRule(new SurnameCannotBeNull(surname));
            CheckRule(new PhoneNumberCannotBeNull(phoneNumber));
            CheckRule(new StreetCannotBeNull(street));
            CheckRule(new CityCannotBeNull(city));
            CheckRule(new StateCannotBeNull(state));

            var customer = new Customer
            {
                Id = id,
                IdentificationNo =identificationNo,    
                Name = name,
                Surname = surname,
                PhoneNumber = phoneNumber,
                Street = street,
                City = city,
                State = state,

            };

            return customer;
        }
    }
}
