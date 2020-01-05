using System;

namespace DataAcess.Models
{
    /// <summary>
    /// This model table CardPayment
    /// </summary>
    public partial class CardPayment
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
