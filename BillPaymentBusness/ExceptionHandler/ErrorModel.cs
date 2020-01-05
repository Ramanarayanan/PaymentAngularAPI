using Newtonsoft.Json;
using System;

namespace BillPaymentBusness.ExceptionHandler
{
    /// <summary>
    /// Thsi class represents error model
    /// </summary>
    public class ErrorModel
    {
        /// <summary>
        /// The constructer to create exception
        /// </summary>
        /// <param name="exception"></param>
        public ErrorModel(System.Exception exception)
        {
            this.Error = new Exception(exception.GetType().Name, exception.Message);
            this.Error.Target = $"{exception.TargetSite.ReflectedType.FullName}.{exception.TargetSite.Name}";
            if (exception.InnerException != null)
            {
                this.Error.InnerError = new InnerException(exception.InnerException);
            }
        }

        public Exception Error { get; set; }

        /// <summary>
        /// This method serialize the object
        /// </summary>
        /// <returns></returns>
        public String ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings() { ContractResolver = new LowercaseContractResolver() });
        }
    }
}
