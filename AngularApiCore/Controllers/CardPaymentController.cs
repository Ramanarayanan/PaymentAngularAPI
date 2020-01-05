using System.Collections.Generic;
using BillPaymentBusness.ExceptionHandler;
using BillPaymentBusness.Interfaces;
using BillPaymentBusness.Models;
using Microsoft.AspNetCore.Mvc;

namespace PaymentWeb.Controllers
{
    /// <summary>
    /// The Card payment controller 
    /// </summary>
    [ApiExceptionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class CardPaymentController : ControllerBase
    {
        private ICardPaymentService cardPaymentWeb;

        // private readonly ILogger _logger;
        public CardPaymentController(ICardPaymentService cardPaymentWeb)
        {
            ///_logger = logger;
            this.cardPaymentWeb = cardPaymentWeb;
        }

        /// <summary>
        /// The Get Card details 
        /// </summary>
        /// <param name="id">The id </param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IEnumerable<CardPaymentModel> GetAllCardDetails(string id)
        {
            return this.cardPaymentWeb.GetCardPayments(id);
        }

        /// <summary>
        /// Insert carddetails 
        /// </summary>
        /// <param name="cardPaymentModel">The cardPaymentModel</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public bool AddCardDetails([FromBody] CardPaymentModel cardPaymentModel)
        {
            return cardPaymentWeb.AddCardPaymentDetails(cardPaymentModel);
        }
    }
}