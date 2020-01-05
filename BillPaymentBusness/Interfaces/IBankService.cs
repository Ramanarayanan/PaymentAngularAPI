using BillPaymentBusness.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillPaymentBusness.Interfaces
{
    /// <summary>
    /// The IBankService
    /// </summary>
    public interface IBankService
    {
        /// <summary>
        /// The get bank details
        /// </summary>
        /// <param name="BankModel">The BankModel</param>
        /// <returns>returns bankmodel</returns>
        BankModel GetBankModel(BankModel BankModel);
            
    }
}
