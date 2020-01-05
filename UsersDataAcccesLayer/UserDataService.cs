using System;
using System.Threading.Tasks;
using PaymentWeb.Data;
using Microsoft.AspNetCore.Identity;

namespace UsersDataAcccesLayer
{
    /// <summary>
    /// The UserDataService
    /// </summary>
    public class UserDataService : IUserDataService
    {
        private UserManager<ApplicationUser> userManager;

        /// <summary>
        /// The Ctor UserDataService
        /// </summary>
        /// <param name="userManager">The userManager</param>
        public UserDataService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationUser"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<bool> CheckPasswordAsync(ApplicationUser applicationUser,string password)
        {
            return await userManager.CheckPasswordAsync(applicationUser, password);
        }

        /// <summary>
        /// This method represents to validate user name
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> FindUserByName(string userName)
        {
           return await userManager.FindByNameAsync(userName);
        }

        /// <summary>
        /// This method insert register details
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<IdentityResult> RegisterUser(ApplicationUser user,string password)
        {
           
            user.SecurityStamp = Guid.NewGuid().ToString();
            var identityResult= await userManager.CreateAsync(user, password);
            
            return identityResult;
        }
    }
}
