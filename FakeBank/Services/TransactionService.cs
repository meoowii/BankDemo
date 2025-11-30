using FakeBank.Models;
using FakeBank.Repositories;

namespace FakeBank.Services;

public class TransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public List<TransactionDto> GetAll()
    {
        var transactions = _transactionRepository.GetAll();

        var result = new List<TransactionDto>();

        foreach (var t in transactions)
        {
            var dto = new TransactionDto
            {
                Guid = t.Guid,
                FromAccount = t.FromAccount,
                ToAccount = t.ToAccount,
                Amount = t.Amount,
                Currency = t.Currency,
                BookingDate = t.BookingDate,
                Title = t.Title,
                Status = t.Status
            };

            result.Add(dto);
        }

        return result;
    }
}

