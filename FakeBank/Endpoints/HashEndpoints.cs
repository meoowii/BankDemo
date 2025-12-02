using FakeBank.Services;

namespace FakeBank.Endpoints;

public static class HashEndpoints
{
    public static void MapHashEndpoints(this WebApplication app)
    {
        app.MapPost("/hash/file", async (IFormFile file, IHashService hashService) =>
        {
            if (file == null || file.Length == 0)
            {
                return Results.BadRequest("File is empty.");
            }

            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            var bytes = ms.ToArray();

            var hash = hashService.ComputeSha256(bytes);

            return Results.Text(hash, "text/plain");
        })
        .DisableAntiforgery()
        .Accepts<IFormFile>("multipart/form-data")
        .WithDescription("Upload a file and receive its SHA-256 hash")
        .WithSummary("Returns SHA-256 hash of uploaded file");
    }
}
