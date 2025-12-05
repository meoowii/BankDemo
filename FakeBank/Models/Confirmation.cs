namespace FakeBank.Models
{
    public class Confirmation
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }

        // 🔹 Klucz obcy i nawigacja do Transaction
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; } = null!;

        public string ConfirmationNumber { get; set; } = string.Empty;
        public TransactionStatus Status { get; set; }

        public decimal Amount { get; set; }
        public ConfirmationCurrency Currency { get; set; }

        public string Sender { get; set; } = string.Empty;
        public string Receiver { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }
}
