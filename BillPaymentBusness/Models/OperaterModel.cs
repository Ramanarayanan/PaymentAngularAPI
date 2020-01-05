namespace BillPaymentBusness.Models
{
    /// <summary>
    /// This method reprsents Recharge plans
    /// </summary>
    public class RechargePlans
    {
        public int Id { get; set; }
        public string Operater { get; set; }
        public decimal Mrp { get; set; }
        public int ValidateDays { get; set; }
        public string Descriptions { get; set; }
        public string Roaming { get; set; }
        public string Sms { get; set; }
        public string Data { get; set; }
    }
}
