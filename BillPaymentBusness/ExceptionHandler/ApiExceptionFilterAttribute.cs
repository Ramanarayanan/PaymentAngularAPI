using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BillPaymentBusness.ExceptionHandler
{
    /// <summary>
    /// This  Exception attribute
    /// </summary>
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        //Overide Exception filter method 
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new JsonResult(new ErrorModel(context.Exception));
        }
    }
}
