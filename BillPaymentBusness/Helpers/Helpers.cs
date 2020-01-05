namespace PaymentWeb.business
{
    /// <summary>
    /// This class represents AppSettings
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// The secret key for user details 
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// The Key for card and Bank details
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The Sender email Informatiomn
        /// </summary>
        public string SenderEmail { get; set; }

        /// <summary>
        /// The EmailPassword for mail
        /// </summary>
        public string EmailPassword { get; set; }

        /// <summary>
        /// The FromAddress 
        /// </summary>
        public string FromAdddress { get; set; }

        /// <summary>
        /// The Host Email config details
        /// </summary>
        public string HostEmail { get; set; }
    }
}
