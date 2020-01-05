using BillPaymentBusness.ExceptionHandler;
using BillPaymentBusness.Models;

namespace BillPaymentBusness.Validation
{
    /// <summary>
    /// The represents the payment validation
    /// </summary>
    public static class PaymentValidation
    {
        /// <summary>
        /// The validates card payment model
        /// </summary>
        /// <param name="cardPaymentModel"></param>
        public static void ValidateCardPayment(CardPaymentModel cardPaymentModel)
        {
            //Validates card payment model
            if(!(cardPaymentModel!=null))
            {
                throw new BusinessException(Constants.CardPaymentModel);
            }

            //Validate the Card number
            if (string.IsNullOrEmpty(cardPaymentModel.CardNumber))
            {
                throw new BusinessException(Constants.CardNumber);
            }

            //Validate Cvv number
            if (string.IsNullOrEmpty(cardPaymentModel.Cvvnumber))
            {
                throw new BusinessException(Constants.CvvNumber);
            }
            
            //Validater card holder name
            if (string.IsNullOrEmpty(cardPaymentModel.CardHolderName))
            {
                throw new BusinessException(Constants.CardHolderName);
            }
        }
    }
}
