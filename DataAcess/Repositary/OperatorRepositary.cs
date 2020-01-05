using System.Collections.Generic;
using System.Linq;
using DataAcess.Models;

namespace BillPaymentDataAccess.Repositary
{
    /// <summary>
    /// The OperatorRepositary
    /// </summary>
    public class OperatorRepositary:Repository<OperaterTable> , IOperaterRepositary
    {
        public OperatorRepositary(paymentsContext context) : base(context)
        {
        }

        /// <summary>
        /// Gets a list of artists
        /// </summary>
        /// <param name="page">Allows you to move between pages</param>
        /// <returns>List of artists</returns>
        public IList<OperaterTable> GetOperatorList()
        {           
            return Query(null, (qry) => qry.OrderByDescending(a => a.Id)).ToList();
        }
    }
}
