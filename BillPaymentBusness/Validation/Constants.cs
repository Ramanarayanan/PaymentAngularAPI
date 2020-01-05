namespace BillPaymentBusness.Validation
{
    /// <summary>
    /// The constants for validation
    /// </summary>
    public static class Constants
    {
       public const string UserName = "UserName is mandatory";
        public const string Password = "Password is mandatory";
        public const string CardNumber = "CardNumber is mandatory";
        public const string CvvNumber = "CvvNumber is mandatory";
        public const string ExpiryDate = "ExpiryDate is mandatory";
        public const string Amount = "Amount is mandatory";
        public const string CardHolderName = "CardHolderName is mandatory";
        public const string OperaterName = "OperaterName is mandatory";
        public const string CardPaymentModel = "CardPayment details is null";
        public const string BankModel = "Bank details is null";
        public const string UserModel = "User details is null";
    } 
}
