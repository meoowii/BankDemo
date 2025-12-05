using FakeBank.Data;
using FakeBank.Models;


public static class DbSeeder
{
    public static void Seed(AppDbContext db)
    {
        if (db.Transactions.Any())
        {
            return;
        }

        var t1 = new Transaction
        {
            Guid = Guid.NewGuid(),
            FromAccount = "1111222233334444",
            ToAccount = "5555666677778888",
            Amount = 123.45m,
            Currency = "PLN",
            BookingDate = DateTime.UtcNow.AddDays(-1),
            Title = "Przelew środków",
            Status = TransactionStatus.Booked
        };

        var t2 = new Transaction
        {
            Guid = Guid.NewGuid(),
            FromAccount = "9999000011112222",
            ToAccount = "3333444455556666",
            Amount = 987.65m,
            Currency = "EUR",
            BookingDate = DateTime.UtcNow.AddDays(-2),
            Title = "Faktura 07/2025",
            Status = TransactionStatus.Booked
        };

        db.Transactions.AddRange(t1, t2);

        var c1 = new Confirmation
        {
            Guid = Guid.NewGuid(),
            TransactionId = 1,
            ConfirmationNumber = "CONF-" + t1.Guid.ToString("N")[..8],
            Amount = t1.Amount,
            Currency = ConfirmationCurrency.PLN,
            Sender = t1.FromAccount,
            Receiver = t1.ToAccount,
            CreatedAt = DateTime.UtcNow
        };

        var c2 = new Confirmation
        {
            Guid = Guid.NewGuid(),
            TransactionId = 2,
            ConfirmationNumber = "CONF-" + t2.Guid.ToString("N")[..8],
            Amount = t2.Amount,
            Currency = ConfirmationCurrency.EUR,
            Sender = t2.FromAccount,
            Receiver = t2.ToAccount,
            CreatedAt = DateTime.UtcNow
        };

        db.Confirmations.AddRange(c1, c2);

        db.SaveChanges();
    }
}
