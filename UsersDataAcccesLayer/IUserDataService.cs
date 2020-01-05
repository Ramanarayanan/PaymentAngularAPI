using PaymentWeb.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UsersDataAcccesLayer
{
    /// <summary>
    /// The IUserDataService
    /// </summary>
    public interface IUserDataService
    {
        /// <summary>
        /// The FindUserByName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<ApplicationUser> FindUserByName(string userName);

        /// <summary>
        /// Validates password
        /// </summary>
        /// <param name="applicationUser"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<bool> CheckPasswordAsync(ApplicationUser applicationUser, string password);

        /// <summary>
        /// Insert register
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<IdentityResult> RegisterUser(ApplicationUser user, string password);
    }
}
