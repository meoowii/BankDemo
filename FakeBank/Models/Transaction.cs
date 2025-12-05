namespace FakeBank.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }

        public string FromAccount { get; set; } = string.Empty;
        public string ToAccount { get; set; } = string.Empty;

        public decimal Amount { get; set; }
        public string Currency { get; set; } = string.Empty;

        public DateTime BookingDate { get; set; }

        public string Title { get; set; } = string.Empty;
        public TransactionStatus Status { get; set; }

        public Confirmation? Confirmation { get; set; }
    }
}
