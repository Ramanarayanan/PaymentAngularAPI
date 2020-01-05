using System;

namespace BillPaymentBusness.Models
{
    /// <summary>
    /// This model represents bankModel
    /// </summary>
    public class BankModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? DateModified
        {
            get; set;
        }
    }
}
