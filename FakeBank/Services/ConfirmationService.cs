using FakeBank.Repositories;

namespace FakeBank.Services;

public class ConfirmationService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IConfirmationRepository _confirmationRepository;
    private readonly IPdfGenerator _pdfGenerator;
    private readonly IHashService _hashService;


    public ConfirmationService(
        ITransactionRepository transactionRepository,
        IConfirmationRepository confirmationRepository,
        IPdfGenerator pdfGenerator,
        IHashService hashService)
    {
        _transactionRepository = transactionRepository;
        _confirmationRepository = confirmationRepository;
        _pdfGenerator = pdfGenerator;
        _hashService = hashService;
    }


    public byte[]? GeneratePdf(Guid transactionId)
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

        var confirmationPdf = _pdfGenerator.GenerateTransactionConfirmation(transaction, confirmation);

        return confirmationPdf;
    }
}
