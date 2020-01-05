using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BillPaymentBusness.ExceptionHandler
{
    /// <summary>
    /// This class represents Custom exception
    /// </summary>
    public class Exception
    {
        /// <summary>
        /// The Constructer 
        /// </summary>
        /// <param name="code">The Code</param>
        /// <param name="message">The message</param>
        public Exception(String code, String message)
        {
            this.Code = code;
            this.Message = message;
        }

        [Required]
        public String Code { get; set; }

        [Required]
        public String Message { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public String Target { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Exception> Details { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public InnerException InnerError { get; set; }
    }
}
