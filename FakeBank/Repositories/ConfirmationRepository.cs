using FakeBank.Data;
using FakeBank.Models;

namespace FakeBank.Repositories;

public class ConfirmationRepository : IConfirmationRepository
{
    private readonly AppDbContext _db;

    public ConfirmationRepository(AppDbContext db)
    {
        _db = db;
    }

    public Confirmation? GetByTransactionId(Guid transactionId)
    {
        return _db.Confirmations
            .SingleOrDefault(c => c.TransactionGuid == transactionId);
    }
}
