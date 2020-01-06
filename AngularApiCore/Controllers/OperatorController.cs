using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BillPaymentBusness.ExceptionHandler;
using BillPaymentBusness.Interfaces;
using BillPaymentBusness.Models;
using Microsoft.AspNetCore.Authorization;

namespace PaymentWeb.Controllers
{
    /// <summary>
    /// The Operater Controller
    /// </summary>
    [Authorize]
    [ApiExceptionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorController : ControllerBase
    {
        private IOperatorService _operaterService;

        // private readonly ILogger _logger;
        public OperatorController(IOperatorService operaterService)
        {
            ///_logger = logger;
            _operaterService = operaterService;
        }

        /// <summary>
        /// Thsi method to get all recharge plans
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IEnumerable<RechargePlans> GetAllRechargePlans()
        {
            return _operaterService.GetAllPrepaidPlans();
        }

        /// <summary>
        /// This method to get operater plans
        /// </summary>
        /// <param name="operater">The operater</param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IEnumerable<RechargePlans> GetOperatorRechargePlans([FromQuery] string operater)
        {
          var operaterlist = (_operaterService.GetAllPrepaidPlans().FindAll(p => p.Operater == operater)).ToList<RechargePlans>() ;

            return operaterlist;
        }
    }
}