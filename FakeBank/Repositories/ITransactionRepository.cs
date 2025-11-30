using FakeBank.Models;

namespace FakeBank.Repositories
{
    public interface ITransactionRepository
    {
        List<Transaction> GetAll();
    }
}