using PaymentWeb.Data;
using BillPaymentBusness.Models;
using System.Threading.Tasks;
using UsersDataAcccesLayer;

namespace BillPaymentBusness.Interfaces
{
    /// <summary>
    /// This IUserService
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// This method Autneticate the login 
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        /// <returns></returns>
        Task<User> AuthenticateAsync(string username, string password);

        /// <summary>
        /// This method represents to store user details
        /// </summary>
        /// <param name="user">The user</param>
        /// <param name="password">The password</param>
        /// <returns></returns>
        Task<UsersResult> RegisterUser(ApplicationUser user, string password);
    }
}
