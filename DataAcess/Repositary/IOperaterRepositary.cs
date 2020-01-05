using DataAcess.Models;
using System.Collections.Generic;

namespace BillPaymentDataAccess
{
    /// <summary>
    /// The IOperaterRepositary
    /// </summary>
    public interface IOperaterRepositary
    {
        IList<OperaterTable> GetOperatorList();
    }
}
