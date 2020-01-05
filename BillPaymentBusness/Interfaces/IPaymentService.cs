using BillPaymentBusness.Models;

namespace BillPaymentBusness.Interfaces
{
    /// <summary>
    /// The IPaymentService
    /// </summary>
    public interface IPaymentService
    {
        /// <summary>
        /// This method reprsents Make card Payment
        /// </summary>
        /// <param name="cardPaymentModel"></param>
        /// <returns></returns>
        PaymentStatus MakeCardPayment(CardPaymentModel cardPaymentModel);

        /// <summary>
        /// This method to represents bankModel
        /// </summary>
        /// <param name="bankModel"></param>
        /// <returns></returns>
        PaymentStatus MakeBankPayment(BankModel bankModel);
    }
}
