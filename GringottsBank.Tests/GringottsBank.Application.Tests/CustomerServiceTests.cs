using AutoMapper;
using GringottsBank.Application.CustomerServices;
using GringottsBank.Application.CustomerServices.Dto;
using GringottsBank.Application.Interfaces;
using GringottsBank.Domain.Customers;
using GringottsBank.Domain.SeedWork;
using MediatR;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GringottsBank.Tests.GringottsBank.Application.Tests
{
    public class CustomerServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly CustomerService _customerService;
        public CustomerServiceTests()
        {
           
            var mockedCustomerRepository = new Mock<ICustomerRepository>();
            var mockedAccountRepository = new Mock<IAccountRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();

            _mockUnitOfWork.Setup(x => x.CustomerRepository).Returns(mockedCustomerRepository.Object);
            _mockUnitOfWork.Setup(x => x.AccountRepository).Returns(mockedAccountRepository.Object);
       

            var mockMapper = new Mock<IMapper>();

             _customerService = new CustomerService(_mockUnitOfWork.Object, mockMapper.Object);
         }

        [Fact]
        public async void CreateCustomer_WithValidParameters_ReturnCorrectDomain()
        {
            //Arrange
            _mockUnitOfWork.Setup(x => x.CustomerRepository.GetCustomerByIdentificationNo(It.IsAny<string>())).Returns(false);
            _mockUnitOfWork.Setup(x => x.CustomerRepository.CreateCustomer(It.IsAny<Customer>())).Returns(Task.FromResult(Guid.NewGuid()));
            _mockUnitOfWork.Setup(x => x.Complete()).Verifiable();

            //Act
           var actualCustomerId =await  _customerService.CreateCustomer(new CustomerCreateDto { Name = "testName", 
                                                                                                Surname = "testSurname",
                                                                                                PhoneNumber = "0596184829", 
                                                                                                State = "test", 
                                                                                                City = "testCity",
                                                                                                Street = "testStreet", 
                                                                                                IdentificationNo = "11111111111" });

            //Assert
            Assert.NotEqual(Guid.Empty, actualCustomerId);

        }

        [Fact]
        public async void CreateCustomer_WithNullParameters_ReturnsException()
        {

            //Arrange
            _mockUnitOfWork.Setup(x => x.CustomerRepository.GetCustomerByIdentificationNo(It.IsAny<string>())).Returns(true);
            _mockUnitOfWork.Setup(x => x.CustomerRepository.CreateCustomer(It.IsAny<Customer>())).Returns(Task.FromResult(Guid.NewGuid()));
            _mockUnitOfWork.Setup(x => x.Complete()).Verifiable();

            //Act
            var exception = await Assert.ThrowsAsync<Exception>(() => _customerService.CreateCustomer(null));



            //Assert
            Assert.Equal(exception.Message, MessageConstants.NullParemeter);
        }

        [Fact]
        public async void CreateCustomer_WithExistingCustomer_ReturnsException()
        { 
            //Arrange
            _mockUnitOfWork.Setup(x => x.CustomerRepository.GetCustomerByIdentificationNo(It.IsAny<string>())).Returns(true);
            _mockUnitOfWork.Setup(x => x.CustomerRepository.CreateCustomer(It.IsAny<Customer>())).Returns(Task.FromResult(Guid.NewGuid()));
            _mockUnitOfWork.Setup(x => x.Complete()).Verifiable();

            //Act
            var exception = await Assert.ThrowsAsync<Exception>(() => _customerService.CreateCustomer(new CustomerCreateDto
            {
                Name = "testName",
                Surname = "testSurname",
                PhoneNumber = "0596184829",
                State = "test",
                City = "testCity",
                Street = "testStreet",
                IdentificationNo = "12345678911"
            }));

            //Assert
            Assert.Equal(exception.Message, MessageConstants.CustomerAlreadyExist);

        }


        [Fact]
        public async void CreateCustomer_WithFailCreated_ReturnsException()
        {
            //Arrange
            _mockUnitOfWork.Setup(x => x.CustomerRepository.GetCustomerByIdentificationNo(It.IsAny<string>())).Returns(false);
            _mockUnitOfWork.Setup(x => x.CustomerRepository.GetCustomerById(It.IsAny<Guid>())).Returns(Task.FromResult<Customer>(default));
            _mockUnitOfWork.Setup(x => x.Complete()).Verifiable();

            //Act
            var exception = await Assert.ThrowsAsync<Exception>(() => _customerService.CreateCustomer(new CustomerCreateDto
            {
                Name = "testName",
                Surname = "testSurname",
                PhoneNumber = "0596184829",
                State = "test",
                City = "testCity",
                Street = "testStreet",
                IdentificationNo = "12345678911"
            }));

            //Assert
            Assert.NotEqual(exception.Message, MessageConstants.CustomerAlreadyExist);
        }

    }
}
