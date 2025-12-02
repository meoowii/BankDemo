using FakeBank.Services;

namespace FakeBank.Endpoints
{
    public static class ConfirmationEndpoints
    {
        public static void MapConfirmationEndpoints(this WebApplication app)
        {
            app.MapGet("/transactions/{id:guid}/confirmation",
                async (Guid id, ConfirmationService service, HttpResponse httpResponse) =>
                {
                    var result = await service.GeneratePdfAsync(id);

                    if (result is null)
                    {
                        return Results.NotFound();
                    }

                    var (pdfBytes, hash) = result.Value;

                    httpResponse.Headers.Append("X-Document-Hash", hash);

                    var fileName = $"confirmation-{id}.pdf";
                    return Results.File(pdfBytes, "application/pdf", fileName);
                });

        }
    }
}