using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PaymentWeb.business;
using PaymentWeb.Data;
using BillPaymentBusness.Interfaces;
using BillPaymentBusness.Models;
using BillPaymentBusness.Validation;
using UsersDataAcccesLayer;

namespace PaymentWeb.Services
{
    /// <summary>
    /// The UserService
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// The appsettings
        /// </summary>
        private readonly AppSettings _appSettings;
    
        /// <summary>
        /// The user service
        /// </summary>
        private IUserDataService userDataService;

        /// <summary>
        /// The user Service constructer
        /// </summary>
        /// <param name="userDataService">The userDataService</param>
        /// <param name="appSettings">The appSettings</param>
        public UserService(IUserDataService userDataService, IOptions<AppSettings> appSettings)
        {
            this.userDataService = userDataService;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// This method Authenticate user and password details
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        /// <returns></returns>
        public async Task<User> AuthenticateAsync(string username, string password)
        {
            UserValidation.ValidateUserName(username);
            UserValidation.ValidatePassword(password);
             // return null if user not found
             var applicationUser = await userDataService.FindUserByName(username);
            if (applicationUser != null && await userDataService.CheckPasswordAsync(applicationUser, password))
            {
                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name,applicationUser.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                User user = new User();
                user.Token = tokenHandler.WriteToken(token);
                user.Username = applicationUser.UserName;
                user.email = applicationUser.Email;
                return user;
            }
            return null;
        }

        /// <summary>
        /// This method user register details 
        /// </summary>
        /// <param name="user">The user</param>
        /// <param name="password">The password</param>
        /// <returns></returns>
        public async Task<UsersResult> RegisterUser(ApplicationUser user, string password)
        {
            UserValidation.ValidateUserDetails(user);
            List<Errors> errorsList = new List<Errors>();
            var identityResult = await this.userDataService.RegisterUser(user, password);
            if(identityResult.Errors!=null )
            {
                foreach (var identity in identityResult.Errors)
                {
                    var error = new Errors();
                    error.Code = identity.Code;
                    error.Description = identity.Description;
                    errorsList.Add(error);
                }
            }
            var useResult = new UsersResult { ErrorList = errorsList, Status = identityResult.Succeeded };
            return useResult;
        }
      }
    }
