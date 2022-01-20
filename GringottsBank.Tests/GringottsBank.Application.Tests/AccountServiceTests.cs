using AutoMapper;
using GringottsBank.Application.AccountServices;
using GringottsBank.Application.AccountServices.Dto;
using GringottsBank.Application.Interfaces;
using GringottsBank.Domain.Accounts;
using GringottsBank.Domain.Customers;
using GringottsBank.Domain.SeedWork;
using MediatR;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GringottsBank.Tests.GringottsBank.Application.Tests
{
    public class AccountServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMediator> _mediatoR;
        private readonly IAccountService _accountService;
        public AccountServiceTests()
        {

            _mediatoR = new Mock<IMediator>();

            var mockedCustomerRepository = new Mock<ICustomerRepository>();
            var mockedAccountRepository = new Mock<IAccountRepository>();

            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockUnitOfWork.Setup(x => x.CustomerRepository).Returns(mockedCustomerRepository.Object);
            _mockUnitOfWork.Setup(x => x.AccountRepository).Returns(mockedAccountRepository.Object);

            var mockMapper = new Mock<IMapper>();
            _accountService = new AccountService(_mockUnitOfWork.Object, _mediatoR.Object, mockMapper.Object);

        }

        [Fact]
        public async void CreateAccount_WithValidParameters_ReturnCorrectRecord()
        {
            //Arrange
            var expectedGuid = Guid.NewGuid();
            _mockUnitOfWork.Setup(x => x.CustomerRepository.GetCustomerById(It.IsAny<Guid>())).Returns(Task.FromResult(new Customer()));
            _mockUnitOfWork.Setup(x => x.AccountRepository.CreateAccount(It.IsAny<Account>())).Returns(Task.FromResult(expectedGuid));
            _mockUnitOfWork.Setup(x => x.Complete()).Verifiable();

            //Act
            var actualCustomerId = await _accountService.CreateAccount(new AccountCreateDto
            {
                CustomerId = Guid.NewGuid(),
                Description = "test",
                Balance = 100
            });

            //Assert
            Assert.Equal(expectedGuid, actualCustomerId);

        }

        [Fact]
        public async void CreateAccount_WithNullParameters_ReturnsException()
        {

            //Arrange
            var expectedGuid = Guid.NewGuid();
            _mockUnitOfWork.Setup(x => x.CustomerRepository.GetCustomerById(It.IsAny<Guid>())).Returns(Task.FromResult(new Customer()));
            _mockUnitOfWork.Setup(x => x.AccountRepository.CreateAccount(It.IsAny<Account>())).Returns(Task.FromResult(expectedGuid));
            _mockUnitOfWork.Setup(x => x.Complete()).Verifiable();

            //Act
            var exception = await Assert.ThrowsAsync<Exception>(() =>  _accountService.CreateAccount(null)); 

            //Assert
            Assert.Equal(exception.Message, MessageConstants.NullParemeter);
        }

        [Fact]
        public async void CreateAccount_WithNotExistingCustomer_ReturnsException()
        {

            //Arrange
            var expectedGuid = Guid.NewGuid();
            
            _mockUnitOfWork.Setup(x => x.CustomerRepository.GetCustomerById(It.IsAny<Guid>())).Returns(Task.FromResult<Customer>(null));
            _mockUnitOfWork.Setup(x => x.AccountRepository.CreateAccount(It.IsAny<Account>())).Returns(Task.FromResult(expectedGuid));
            _mockUnitOfWork.Setup(x => x.Complete()).Verifiable();

            //Act
            var exception = await Assert.ThrowsAsync<Exception>(() => _accountService.CreateAccount(new AccountCreateDto
            {
                CustomerId = Guid.NewGuid(),
                Description = "test",
                Balance = 100
            }));
        

            //Assert
            Assert.Equal(exception.Message, MessageConstants.CustomerNotFound);

        }

        [Fact]
        public async void CreateAccount_WithFailInsert_ReturnsException()
        {

            //Arrange
            var expectedGuid = Guid.NewGuid();
            _mockUnitOfWork.Setup(x => x.CustomerRepository.GetCustomerById(It.IsAny<Guid>())).Returns(Task.FromResult(new Customer()));
            _mockUnitOfWork.Setup(x => x.AccountRepository.CreateAccount(It.IsAny<Account>())).Returns(Task.FromResult(Guid.Empty));
            _mockUnitOfWork.Setup(x => x.Complete()).Verifiable();

            //Act
            var exception = await Assert.ThrowsAsync<Exception>(() => _accountService.CreateAccount(new AccountCreateDto
            {
                CustomerId = Guid.NewGuid(),
                Description = "test",
                Balance = 100
            }));


            //Assert
            Assert.Equal(exception.Message, MessageConstants.AccountCouldNotCreated);

        }

    }
}
