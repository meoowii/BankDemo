using System;

namespace FakeBank.Services;

public class RegisterDocumentRequest
{
    public string Hash { get; set; } = string.Empty;
    public string DocumentType { get; set; } = string.Empty;
    public string ExternalId { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public decimal Amount { get; set; }
    public string Currency { get; set; } = string.Empty;

    public string FromAccount { get; set; } = string.Empty;
    public string ToAccount { get; set; } = string.Empty;
}

public interface INoFakeryClient
{
    Task RegisterDocumentAsync(RegisterDocumentRequest request);
}