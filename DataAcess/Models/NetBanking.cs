using System;

namespace DataAcess.Models
{
    /// <summary>
    /// The NetBanking DB model
    /// </summary>
    public partial class NetBanking
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
