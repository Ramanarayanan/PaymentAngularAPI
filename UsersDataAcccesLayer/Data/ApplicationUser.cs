using Microsoft.AspNetCore.Identity;

namespace PaymentWeb.Data
{
    /// <summary>
    /// This ApplicationUser inherits default IdentityUser
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public string Password;
    }
}
