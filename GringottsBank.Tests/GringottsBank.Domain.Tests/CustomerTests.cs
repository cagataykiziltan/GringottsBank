using GringottsBank.Domain.Customers;
using GringottsBank.Domain.SeedWork;
using System;
using Xunit;

namespace GringottsBank.Tests.GringottsBank.Domain.Tests
{
    public class CustomerTests
    {
       
        [Fact]
        public void CustomerDomainCreate_WithNullId_ThrowsError()
        {  
            //Arrange
            var id = Guid.Empty; 
            string identificationNo = "12345678900";
            string name = "cagatay";
            string surname = "kiziltan";
            string phoneNumber = "05396184808";
            string street = "istanbul";
            string city = "turkiye";
            string state = "esenyurt";

            //Act
            var exception = Assert.Throws<BusinessRuleValidationException>(() => Customer.Create(id, identificationNo, name, surname, phoneNumber, street, city, state));

            //Assert
            Assert.Equal(exception.Message, MessageConstants.IdCannotBeNull);

        }

      
        [Fact]
        public void CustomerDomainCreate_WithNullName_ThrowsError()
        {
            //Arrange
            var id = Guid.NewGuid();
            string identificationNo = "12345678900";
            string name = null;
            string surname = "kiziltan";
            string phoneNumber = "05396184909";
            string street = "istanbul";
            string city = "turkiye";
            string state = "esenyurt";

            //Act
            var exception = Assert.Throws<BusinessRuleValidationException>(() => Customer.Create(id, identificationNo, name, surname, phoneNumber, street, city, state));

            //Assert
            Assert.Equal(exception.Message, MessageConstants.NameCannotBeNullMessage);
        }


        [Fact]
        public void CustomerDomainCreate_WithNullSurname_ThrowsError()
        {
            //Arrange
            var id = Guid.NewGuid();
            string identificationNo = "12345678900";
            string name = "cagatay";
            string surname = null;
            string phoneNumber = "05396184909";
            string street = "istanbul";
            string city = "turkiye";
            string state = "esenyurt";

            //Act
            var exception = Assert.Throws<BusinessRuleValidationException>(() => Customer.Create(id, identificationNo, name, surname, phoneNumber, street, city, state));

            //Assert
            Assert.Equal(exception.Message, MessageConstants.SurnameCannotBeNullMessage);
        }


        [Fact]
        public void CustomerDomainCreate_WithNullPhoneNumber_ThrowsError()
        {
            //Arrange
            var id = Guid.NewGuid();
            string identificationNo = "12345678900";
            string name = "cagatay";
            string surname = "kiziltan";
            string phoneNumber = null;
            string street = "istanbul";
            string city = "turkiye";
            string state = "esenyurt";

            //Act
            var exception = Assert.Throws<BusinessRuleValidationException>(() => Customer.Create(id, identificationNo, name, surname, phoneNumber, street, city, state));

            //Assert
            Assert.Equal(exception.Message, MessageConstants.PhoneNoCannotBeNullMessage);
        }


        [Fact]
        public void CustomerDomainCreate_WithNullStreet_ThrowsError()
        {
            //Arrange
            var id = Guid.NewGuid();
            string identificationNo = "12345678901";
            string name = "cagatay";
            string surname = "kiziltan";
            string phoneNumber = "05396184909";
            string street =null;
            string city = "turkiye";
            string state = "esenyurt";

            //Act
            var exception = Assert.Throws<BusinessRuleValidationException>(() => Customer.Create(id, identificationNo, name, surname, phoneNumber, street, city, state));

            //Assert
            Assert.Equal(exception.Message, MessageConstants.StreetCannotBeNullMessage);
        }


        [Fact]
        public void CustomerDomainCreate_WithNullCity_ThrowsError()
        {
            //Arrange
            var id = Guid.NewGuid();
            string identificationNo = "12345678901";
            string name = "cagatay";
            string surname = "kiziltan";
            string phoneNumber = "05396194909";
            string street = "istanbul";
            string city = null;
            string state = "esenyurt";

            //Act
            var exception = Assert.Throws<BusinessRuleValidationException>(() => Customer.Create(id, identificationNo, name, surname, phoneNumber, street, city, state));

            //Assert
            Assert.Equal(exception.Message, MessageConstants.CityCannotBeNullMessage);
        }


        [Fact]
        public void CustomerDomainCreate_WithNullState_ThrowsError()
        {
            //Arrange
            var id = Guid.NewGuid();
            string identificationNo = "12345678900";
            string name = "cagatay";
            string surname = "kiziltan";
            string phoneNumber = "05396194909";
            string street = "istanbul";
            string city = "turkiye";
            string state = null;

            //Act
            var exception = Assert.Throws<BusinessRuleValidationException>(() => Customer.Create(id, identificationNo, name, surname, phoneNumber, street, city, state));

            //Assert
            Assert.Equal(exception.Message, MessageConstants.StateCannotBeNullMessage);
        }

        [Fact]
        public void CustomerDomainCreate_GivenCorrectValues_CreatesCorrectDomain()
        {
            //Arrange
            var id = Guid.NewGuid();
            string identificationNo = "12345678900";
            string name = "cagatay";
            string surname = "kiziltan";
            string phoneNumber = "05396184808";
            string street = "istanbul";
            string city = "turkiye";
            string state = "esenyurt";

            //Act
            var customer = Customer.Create(id, identificationNo, name, surname, phoneNumber, street, city, state);

            //Assert
            Assert.Equal(customer.Id, id);
            Assert.Equal(customer.Name, name);
            Assert.Equal(customer.Surname, surname);
            Assert.Equal(customer.PhoneNumber, phoneNumber);
            Assert.Equal(customer.Street, street);
            Assert.Equal(customer.City, city);
            Assert.Equal(customer.Street, street);
        }
    }
}
