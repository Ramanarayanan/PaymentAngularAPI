using BillPaymentBusness.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillPaymentBusness.Interfaces
{
    /// <summary>
    /// The ICardPaymentService
    /// </summary>
    public interface ICardPaymentService
    {
        /// <summary>
        /// This method represents get card details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         IList<CardPaymentModel> GetCardPayments(string id);

        /// <summary>
        /// This method to add card details
        /// </summary>
        /// <param name="cardPaymentModel">The cardPaymentModel</param>
        /// <returns>returns cardPaymentModel</returns>
        bool AddCardPaymentDetails(CardPaymentModel cardPaymentModel);
    }
}
