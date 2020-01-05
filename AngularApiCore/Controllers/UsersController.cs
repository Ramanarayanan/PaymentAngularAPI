using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentWeb.Data;
using PaymentWeb.Model;
using PaymentWeb.Services;
using BillPaymentBusness.Interfaces;
using BillPaymentBusness.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BillPaymentBusness.ExceptionHandler;

namespace PaymentWeb.Controllers
{
    /// <summary>
    /// This UsersController
    /// </summary>
    [ApiExceptionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private const string ErrorMessage = "Username or password is incorrect,Please try again";
        private IUserService _userService;
        
        private readonly ILogger _logger;
        public UsersController(IUserService userService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(typeof(UsersController));
            _userService = userService;
        }

        /// <summary>
        /// This method Authenticate user details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticateModel model)
        {
            var user = await _userService.AuthenticateAsync(model.Username, model.Password);
            if (user == null)
                return BadRequest(new { message = ErrorMessage });

            return Ok(user);
        }

        /// <summary>
        /// This method represents User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<UsersResult> RegisterUser([FromBody] ApplicationUser user)
        {
            return await _userService.RegisterUser(user, user.Password);
        }
    }
}