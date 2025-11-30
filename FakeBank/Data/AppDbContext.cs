using FakeBank.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FakeBank.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<Confirmation> Confirmations => Set<Confirmation>();
}
