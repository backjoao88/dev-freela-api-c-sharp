using FreelaDev.MsPayments.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FreelaDev.MsPayments.Infrastructure.Persistence;

/// <summary>
/// Represents a EFCore db context.
/// </summary>
public class EfDbContext : DbContext
{
    private EfDbContext()
    {
    }
    
    public EfDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfDbContext).Assembly);
    }

    public DbSet<Payment> Payments { get; set; } = null!;
}