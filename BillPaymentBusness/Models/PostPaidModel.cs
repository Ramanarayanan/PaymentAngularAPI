using System;
using System.Collections.Generic;
using System.Text;

namespace BillPaymentBusness.Models
{
    /// <summary>
    /// The PostPaidModel
    /// </summary>
    public class PostPaidModel
    {
        public int ProductId { get; set; }
        public string Id { get; set; }
        public string MobileNumber { get; set; }
        public string ConsumerNo { get; set; }
        public string BillType { get; set; }
        public double? Amount { get; set; }
        public double? PaidAmount { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
