using Microsoft.Extensions.Options;
using PaymentWeb.business;

namespace BillPaymentWebTest
{
    public class Options : IOptions<AppSettings>
    {
        public AppSettings Value => new AppSettings
        {
            Secret = "Test",
            EmailPassword = "test",
            FromAdddress = "test",
            HostEmail = "test",
            Key = "test",
            SenderEmail = "test"


        };
     }
}
