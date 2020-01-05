using System;
using System.Collections.Generic;
using System.Text;

namespace BillPaymentBusness.Models
{
    /// <summary>
    /// This method represents xard payment model
    /// </summary>
    public class CardPaymentModel
    {
        public string Id { get; set; }
        public string CardNumber { get; set; }
        public string Cvvnumber { get; set; }
        public string ExpiryDate { get; set; }
        public string CardHolderName { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
