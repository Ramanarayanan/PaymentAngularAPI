using Newtonsoft.Json.Serialization;

namespace BillPaymentBusness.ExceptionHandler
{
    /// <summary>
    /// This class represesents Contract resolver
    /// </summary>
    internal class LowercaseContractResolver : DefaultContractResolver
    {
        /// <summary>
        /// This method resolve the Contract
        /// </summary>
        /// <param name="propertyName">The propertyName</param>
        /// <returns></returns>
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }
}
