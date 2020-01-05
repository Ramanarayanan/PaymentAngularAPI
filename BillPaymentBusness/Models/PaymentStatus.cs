namespace BillPaymentBusness.Models
{
    /// <summary>
    /// This method reprsents payment completon details
    /// </summary>
    public class PaymentStatus
    {
        public string Error
        {
            get;set;
        }

        public bool Status
        {
            get; set;
        }
    }
}
