using PaymentWeb.business;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace BillPaymentBusness
{
    /// <summary>
    /// Thsi method represents email helper
    /// </summary>
    public class EmailHelper
    {
        private readonly AppSettings _appSettings;
        /// <summary>
        ///    The email Helper
        /// </summary>
        /// <param name="appSettings"></param>
        public EmailHelper(IOptions<AppSettings> appSettings)
        {
            this._appSettings = appSettings.Value;
        }

        /// <summary>
        /// Thsi method is send mail functinality 
        /// </summary>
        /// <param name="name">The name </param>
        /// <param name="email"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public string SendEmail(string name, string email, string message)
        {
            try
            {   // Credentials
                var credentials = new NetworkCredential(this._appSettings.SenderEmail, this._appSettings.EmailPassword);
                // Mail message
                var mail = new MailMessage()
                {
                    From = new MailAddress(this._appSettings.FromAdddress),
                    Subject = "Payment Email ",
                    Body = message
                };
                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress(email));
                // Smtp client
                var client = new SmtpClient()
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = this._appSettings.HostEmail,
                    EnableSsl = true,
                    Credentials = credentials
                };
                client.Send(mail);
                return "Email Sent Successfully!";
            }
            catch (System.Exception e)
            {
                return e.Message;
            }
        }
      }
}
