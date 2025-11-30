using FakeBank.Models;

namespace FakeBank.Repositories
{
    public interface IConfirmationRepository
    {
        Confirmation? GetByTransactionId(Guid transactionId);
    }
}