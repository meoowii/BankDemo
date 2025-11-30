using FakeBank.Data;
using FakeBank.Models;

namespace FakeBank.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly AppDbContext _db;

    public TransactionRepository(AppDbContext db)
    {
        _db = db;
    }

    public List<Transaction> GetAll()
    {
        return _db.Transactions.ToList();
    }
}

