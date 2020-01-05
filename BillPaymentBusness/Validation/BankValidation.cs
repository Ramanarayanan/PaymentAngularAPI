using BillPaymentBusness.ExceptionHandler;
using BillPaymentBusness.Models;

namespace BillPaymentBusness.Validation
{
    /// <summary>
    /// This class represents BankVaidation
    /// </summary>
    public static class BankValidation
    {
        /// <summary>
        /// The method validate Bank model
        /// </summary>
        /// <param name="bankModel"></param>
        public static void Validate(BankModel bankModel)
        {
            //Validate bank model
            if (bankModel == null)
            {
                throw new BusinessException(Constants.BankModel);
            }
            //Validate username
            if (string.IsNullOrEmpty(bankModel.UserName))
            {
                throw new BusinessException(Constants.UserName);
            }
            //Validate password
            if (string.IsNullOrEmpty(bankModel.Password))
            {
                throw new BusinessException(Constants.Password);
            }
          }
    }
}
