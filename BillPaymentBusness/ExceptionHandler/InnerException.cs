using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BillPaymentBusness.ExceptionHandler
{
    /// <summary>
    /// This class InnerException 
    /// </summary>
    public class InnerException
    {
        /// <summary>
        /// The constructer InnerException
        /// </summary>
        /// <param name="exception"></param>
        public InnerException(System.Exception exception)
        {
            this.Code = exception.GetType().Name;
            if (exception.InnerException != null)
            {
                this.InnerError = new InnerException(exception.InnerException);
            }
        }

        [Required]
        public String Code { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public InnerException InnerError { get; set; }
    }
}
