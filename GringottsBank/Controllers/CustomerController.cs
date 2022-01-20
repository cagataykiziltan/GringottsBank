using GringottsBank.Application.AccountServices.Dto;
using GringottsBank.Application.CustomerServices.Dto;
using GringottsBank.Application.Interfaces;
using GringottsBank.Infrastructure.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GringottsBank.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("CreateCustomer")]
        [ProducesResponseType(typeof(HttpResponseObjectSuccess<string>), (int)HttpStatusCode.OK),
         ProducesResponseType(typeof(HttpResponseObjectError<string>), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<HttpResponseObject<string>>> CreateCustomer(HttpRequestObject<CustomerCreateDto> customerCreateRequest)
        {
            var customer = customerCreateRequest.Items.First();

            var customerId = await _customerService.CreateCustomer(customer);

            return new HttpResponseObjectSuccess<string>(customerId.ToString());
        }

        [HttpGet("GetAllCustomerAccounts")]
        [ProducesResponseType(typeof(HttpResponseObjectSuccess<List<AccountDto>>), (int)HttpStatusCode.OK),
         ProducesResponseType(typeof(HttpResponseObjectError<List<AccountDto>>), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<HttpResponseObject<List<AccountDto>>>> GetAllCustomerAccounts([FromBody]HttpRequestObject<GetCustomerAccountsDto> getCustomerAccountsRequest)
        {
            var customerId = getCustomerAccountsRequest.Items.First();

            var result = await _customerService.GetAllCustomerAccounts(customerId);

            return new HttpResponseObjectSuccess<List<AccountDto>>(result);
        }


        [HttpGet("GetCustomerAccountDetails")]
        [ProducesResponseType(typeof(HttpResponseObjectSuccess<AccountDto>), (int)HttpStatusCode.OK),
         ProducesResponseType(typeof(HttpResponseObjectError<AccountDto>), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<HttpResponseObject<AccountDto>>> GetCustomerAccountDetails([FromBody]HttpRequestObject<GetCustomerAccountDetailsDto> getCustomerAccountsRequest)
        {
            var getCustomerAccountsRequestParams = getCustomerAccountsRequest.Items.First();

            var result = await _customerService.GetCustomerAccountDetails(getCustomerAccountsRequestParams);

            return new HttpResponseObjectSuccess<AccountDto>(result);
        }
    }
}
