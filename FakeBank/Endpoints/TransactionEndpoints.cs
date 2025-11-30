using FakeBank.Services;

namespace FakeBank.Endpoints
{
    public static class TransactionEndpoints
    {
        public static void MapTransactionEndpoints(this WebApplication app)
        {
            app.MapGet("/transactions", (TransactionService service) =>
            {
                var result = service.GetAll();
                return Results.Ok(result);
            });
        }
    }
}
