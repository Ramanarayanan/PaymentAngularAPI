using BillPaymentBusness.Models;
using System.Collections.Generic;

namespace BillPaymentBusness.Interfaces
{
    /// <summary>
    /// The IPostPaidService
    /// </summary>
    public interface IPostPaidService
    {
        /// <summary>
        /// This method get all post paid details
        /// </summary>
        /// <returns></returns>
        IList<PostPaidModel> GetAllPostPaidModel();
    }
}
