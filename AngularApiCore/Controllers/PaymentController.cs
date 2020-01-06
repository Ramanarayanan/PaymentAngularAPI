using BillPaymentBusness.ExceptionHandler;
using BillPaymentBusness.Interfaces;
using BillPaymentBusness.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PaymentWeb.Controllers
{
    /// <summary>
    /// This method reprsents the payment controller
    /// </summary>
    [Authorize]
    [ApiExceptionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        private IPaymentService paymentService;

        // private readonly ILogger _logger;
        public PaymentController(IPaymentService paymentService)
        {
            ///_logger = logger;
            this.paymentService = paymentService;
        }


        /// <summary>
        /// This method represents card payment 
        /// </summary>
        /// <param name="cardPaymentModel">Th cardPaymentModel</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public PaymentStatus MakeCardPayment([FromBody] CardPaymentModel cardPaymentModel)
        {
           return this.paymentService.MakeCardPayment(cardPaymentModel);
        }

        /// <summary>
        /// Thismethod reprsents Bank payment
        /// </summary>
        /// <param name="bankModel">The bankModel</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public PaymentStatus MakeBankPayment([FromBody] BankModel bankModel)
        {
            return this.paymentService.MakeBankPayment(bankModel);
        }
    }
}