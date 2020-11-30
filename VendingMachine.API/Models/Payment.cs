namespace VendingMachine.API.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Cash { get; set; }
        public int CardNumber { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int SecurityCode { get; set; }
    }
}