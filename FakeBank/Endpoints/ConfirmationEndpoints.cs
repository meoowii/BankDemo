using FakeBank.Services;

namespace FakeBank.Endpoints
{
    public static class ConfirmationEndpoints
    {
        public static void MapConfirmationEndpoints(this WebApplication app)
        {
            app.MapGet("/transactions/{id:guid}/confirmation",
                (Guid id, ConfirmationService service) =>
                {
                    var pdf = service.GenerateAndRegister(id);

                    if (pdf is null)
                    {
                        return Results.NotFound();
                    }

                    var fileName = $"confirmation-{id}.pdf";
                    return Results.File(pdf, "application/pdf", fileName);
                });
        }

    }
}
