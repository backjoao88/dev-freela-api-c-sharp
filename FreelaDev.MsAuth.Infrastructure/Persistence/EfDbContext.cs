using FreelaDev.MsAuth.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FreelaDev.MsAuth.Infrastructure.Persistence;

/// <summary>
/// Represents the db context.
/// </summary>
public class EfDbContext : DbContext
{
    public EfDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    /// <summary>
    /// Sets up all configurations
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfDbContext).Assembly);
    }
}