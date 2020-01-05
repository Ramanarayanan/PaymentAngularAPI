using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace PaymentWeb
{
    /// <summary>
    /// Thismain method to intiates the call 
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// The CreateWebHostBuilder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
