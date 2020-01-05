using PaymentWeb.Data;
using BillPaymentBusness.ExceptionHandler;

namespace BillPaymentBusness.Validation
{
    /// <summary>
    /// The User validation
    /// </summary>
    public static class UserValidation
    {
        /// <summary>
        /// The validate user model
        /// </summary>
        /// <param name="applicationUser">The applicationUser</param>
        public static void ValidateUserDetails(ApplicationUser applicationUser)
        {
            //Validate application user
            if(applicationUser==null)
            {
                throw new BusinessException(Constants.UserModel);
            }

            //Validate user name
            ValidateUserName(applicationUser.UserName);
            //Validate password
            ValidateUserName(applicationUser.Password);
        }

        /// <summary>
        /// This validates user name
        /// </summary>
        /// <param name="userName"></param>
        public static void ValidateUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new BusinessException(Constants.UserName);
            }
        }

        /// <summary>
        /// Thsi validates Password
        /// </summary>
        /// <param name="password"></param>
        public static void ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new BusinessException(Constants.Password);
            }
        }
    }
}
