using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace PaymentWeb.Data
{
    /// <summary>
    /// This is seed file for default setup
    /// </summary>
    public class SeedDB
    {
        /// <summary>
        /// This class initialize 
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            context.Database.EnsureCreated();         
            if (!context.Users.Any())
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = "Ramanarayanan@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "Ramanarayanan",
                    PhoneNumber = "967456783"
                };
                userManager.CreateAsync(user, "Ramanarayan@123");
            }
        }
    }
}
