
using GringottsBank.Domain.Accounts;
using GringottsBank.Domain.SeedWork;
using System;
using Xunit;

namespace GringottsBank.Tests.GringottsBank.Domain.Tests
{
    public class AccountTests
    {
      

        [Fact]
        public void AccounDomainCreate_WithNullId_ThrowsError()
        {
            //Arrange
            var id = Guid.Empty;
            var customerId = Guid.NewGuid();
            var description = "test";
            var balance = 100;

            //Act
            var exception = Assert.Throws<BusinessRuleValidationException>(() => Account.Create(id, customerId, description, balance));

            //Assert
            Assert.Equal(exception.Message, MessageConstants.IdCannotBeNull);

        }

        [Fact]
        public void AccounDomainCreate_WithNullCustomerId_ThrowsError()
        {
            //Arrange
            var id = Guid.NewGuid();
            var customerId = Guid.Empty;
            string description = "test";
            decimal balance = 100;

            //Act
            var exception = Assert.Throws<BusinessRuleValidationException>(() => Account.Create(id, customerId, description, balance));

            //Assert
            Assert.Equal(exception.Message, MessageConstants.IdCannotBeNull);
        }


        [Fact]
        public void AccounDomainCreate_WithNullDescription_ThrowsError()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            Guid customerId = Guid.NewGuid();
            string description = null;
            decimal balance = 100;

            //Act
            var exception = Assert.Throws<BusinessRuleValidationException>(() => Account.Create(id, customerId, description, balance));

            //Assert
            Assert.Equal(exception.Message, MessageConstants.DescriptionCannotBeNull);
        }


        [Fact]
        public void CustomerDomainCreate_WithNegativeBalance_ThrowsError()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            Guid customerId = Guid.NewGuid();
            string description = "test";
            decimal balance = -100;

            //Act
            var exception = Assert.Throws<BusinessRuleValidationException>(() => Account.Create(id, customerId, description, balance));

            //Assert
            Assert.Equal(exception.Message, MessageConstants.BalanceCannotBeNegative);
        }

        [Fact]
        public void AccountDomainCreate_GivenCorrectValues_CreatesCorrectDomain()
        {
            //Arrange
            var id = Guid.NewGuid();
            var customerId = Guid.NewGuid();
            var description = "test";
            var balance = 100;


            //Act
            var account = Account.Create(id, customerId, description, balance);

            //Assert
            Assert.Equal(account.Id, id);
            Assert.Equal(account.CustomerId, customerId);
            Assert.Equal(account.Description, description);
            Assert.Equal(account.Balance, balance);

        }
    }
}
