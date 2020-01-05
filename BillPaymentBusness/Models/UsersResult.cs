using System.Collections.Generic;

namespace BillPaymentBusness.Models
{
    /// <summary>
    /// The UsersResult
    /// </summary>
    public class UsersResult
    {
       public List<Errors> ErrorList
        {
            get;set;
        }

        public bool Status
        {
            get;set;
        }
    }
}
