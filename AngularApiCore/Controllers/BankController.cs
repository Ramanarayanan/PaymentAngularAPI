using Microsoft.AspNetCore.Mvc;
using BillPaymentBusness.Interfaces;
using BillPaymentBusness.Models;
using Microsoft.Extensions.Logging;
using BillPaymentBusness.ExceptionHandler;

namespace PaymentWeb.Controllers
{
    /// <summary>
    /// The Bankcontroller
    /// </summary>
    [ApiExceptionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private IBankService bankService;

       // private readonly ILogger _logger;
        public BankController(IBankService bankService)
        {
         //   _logger = logger;
            this.bankService = bankService;
        }

        /// <summary>
        /// This method to reprsents the Card details
        /// </summary>
        /// <param name="bankModel">ThebankModel</param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public BankModel GetAllCardDetails([FromBody] BankModel bankModel)
        {
            return this.bankService.GetBankModel(bankModel);
        }
    }
}