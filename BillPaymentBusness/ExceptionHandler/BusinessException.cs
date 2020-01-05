using System;
using System.Collections.Generic;
using System.Text;

namespace BillPaymentBusness.ExceptionHandler
{
    /// <summary>
    /// This class represents Business exception
    /// </summary>
    public class BusinessException : SystemException
    {
        /// <summary>
        /// Call base exception
        /// </summary>
        /// <param name="message"></param>
        public BusinessException(string message) : base(message)
        {
        }
    }
}
