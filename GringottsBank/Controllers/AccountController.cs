using GringottsBank.Application.AccountServices.Dto;
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

    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

      
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpPost("CreateAccount")]
        [ProducesResponseType(typeof(HttpResponseObjectSuccess<string>), (int)HttpStatusCode.OK),
         ProducesResponseType(typeof(HttpResponseObjectError<string>), (int)HttpStatusCode.BadRequest)]
   
        public async Task<ActionResult<HttpResponseObject<string>>> CreateAccount(HttpRequestObject<AccountCreateDto> accountCreateRequest)
        {
            var accountCreateReq = accountCreateRequest.Items.First();

            var accountId = await _accountService.CreateAccount(accountCreateReq);

            return new HttpResponseObjectSuccess<string>(accountId.ToString());
        }

        [HttpPost("AddMoney")]
        [ProducesResponseType(typeof(HttpResponseObjectSuccess<string>), (int)HttpStatusCode.OK),
         ProducesResponseType(typeof(HttpResponseObjectError<string>), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<HttpResponseObject<string>>> AddMoney(HttpRequestObject<AddMoneyDto> addMoneyRequest)
        {
            var addMoneyReq = addMoneyRequest.Items.First();

           await _accountService.AddMoney(addMoneyReq);

            return new HttpResponseObjectSuccess<string>(addMoneyReq.AccountId.ToString());
        }

        [HttpPost("WithdrawMoney")]
        [ProducesResponseType(typeof(HttpResponseObjectSuccess<string>), (int)HttpStatusCode.OK),
         ProducesResponseType(typeof(HttpResponseObjectError<string>), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<HttpResponseObject<string>>> WithdrawMoney(HttpRequestObject<WithdrawMoneyDto> withdrawMoneyRequest)
        {
            var addMoneyReq = withdrawMoneyRequest.Items.First();

            await _accountService.WithDrawMoney(addMoneyReq);

            return new HttpResponseObjectSuccess<string>(addMoneyReq.AccountId.ToString());
        }

        [HttpGet("GetAllAccountTransactions")]
        [ProducesResponseType(typeof(HttpResponseObjectSuccess<BankTransactionDto>), (int)HttpStatusCode.OK),
        ProducesResponseType(typeof(HttpResponseObjectError<BankTransactionDto>), (int)HttpStatusCode.BadRequest)]
        public async Task<HttpResponseObject<List<BankTransactionDto>>> GetAllAccountTransactions(HttpRequestObject<GetAccountTransactionDto> getAccountTransactionRequest)
        {
            var getAccountTransactionReq = getAccountTransactionRequest.Items.First();

            var transactions = await _accountService.GetAccountAllTransaction(getAccountTransactionReq);

            return new HttpResponseObjectSuccess<List<BankTransactionDto>>(transactions);
        }

        [HttpGet("GetAccountTransactionBetweenPeriod")]
        [ProducesResponseType(typeof(HttpResponseObjectSuccess<BankTransactionDto>), (int)HttpStatusCode.OK),
        ProducesResponseType(typeof(HttpResponseObjectError<BankTransactionDto>), (int)HttpStatusCode.BadRequest)]
        public async Task<HttpResponseObject<List<BankTransactionDto>>> GetAccountTransactionBetweenPeriod(HttpRequestObject<GetAccountTransactionWithTimePeriodDto> GetAccountTransactionWithTimePerioRequest)
        {
            var GetAccountTransactionWithTimePerioReq = GetAccountTransactionWithTimePerioRequest.Items.First();

            var transactions = await _accountService.GetAccountTransactionBetweenPeriod(GetAccountTransactionWithTimePerioReq);

            return new HttpResponseObjectSuccess<List<BankTransactionDto>>(transactions);
        }
    }
}
