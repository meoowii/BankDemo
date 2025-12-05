using System;
using System.Linq;
using FakeBank.Models;
using FakeBank.Repositories;

namespace FakeBank.Services;

public class ConfirmationService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IConfirmationRepository _confirmationRepository;
    private readonly IPdfGenerator _pdfGenerator;
    private readonly IHashService _hashService;
    private readonly INoFakeryClient _noFakeryClient;

    public ConfirmationService(
        ITransactionRepository transactionRepository,
        IConfirmationRepository confirmationRepository,
        IPdfGenerator pdfGenerator,
        IHashService hashService,
        INoFakeryClient noFakeryClient)
    {
        _transactionRepository = transactionRepository;
        _confirmationRepository = confirmationRepository;
        _pdfGenerator = pdfGenerator;
        _hashService = hashService;
        _noFakeryClient = noFakeryClient;
    }

    public async Task<(byte[] PdfBytes, string Hash)?> GeneratePdfAsync(Guid transactionId)
    {
        var transaction = _transactionRepository
            .GetAll()
            .SingleOrDefault(t => t.Guid == transactionId);

        if (transaction == null)
        {
            return null;
        }

        var confirmation = _confirmationRepository.GetByTransactionId(transactionId);

        if (confirmation == null)
        {
            return null;
        }

        var pdfBytes = _pdfGenerator.GenerateTransactionConfirmation(transaction, confirmation);

        var hash = _hashService.ComputeSha256(pdfBytes);

        try
        {
            await _noFakeryClient.RegisterDocumentAsync(new RegisterDocumentRequest
            {
                Hash = hash,
                DocumentType = "TRANSFER_CONFIRMATION",
                ExternalId = confirmation.ConfirmationNumber,
                CreatedAt = confirmation.CreatedAt,
                Amount = confirmation.Amount,
                Currency = confirmation.Currency.ToString(),
                FromAccount = confirmation.Sender,
                ToAccount = confirmation.Receiver
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"NoFakery error: {ex.Message}");
        }

        return (pdfBytes, hash);
    }
}
