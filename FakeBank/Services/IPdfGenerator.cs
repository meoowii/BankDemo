using FakeBank.Models;

namespace FakeBank.Services
{
    public interface IPdfGenerator
    {
        byte[] GenerateTransactionConfirmation(Transaction transaction, Confirmation confirmation);
    }
}