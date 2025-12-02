using FakeBank.Data;
using FakeBank.Endpoints;
using FakeBank.Repositories;
using FakeBank.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("FakeBankDb"));


builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IConfirmationRepository, ConfirmationRepository>();
builder.Services.AddScoped<TransactionService>();
builder.Services.AddScoped<ConfirmationService>();
builder.Services.AddScoped<IPdfGenerator, PdfGenerator>();
builder.Services.AddScoped<IHashService, HashService>();
builder.Services.AddHttpClient<INoFakeryClient, NoFakeryClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["NoFakery:BaseUrl"]!);
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DbSeeder.Seed(db);
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapTransactionEndpoints();
app.MapConfirmationEndpoints();
app.MapHashEndpoints();

app.Run();
