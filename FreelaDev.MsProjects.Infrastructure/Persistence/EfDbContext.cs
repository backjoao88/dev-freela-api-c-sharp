using FreelaDev.MsProjects.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FreelaDev.MsProjects.Infrastructure.Persistence;

/// <summary>
/// Represents the db context.
/// </summary>
public class EfDbContext : DbContext
{
    
    /// <summary>
    /// Required by EFCore.
    /// </summary>
    private EfDbContext(){}
    
    public EfDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Project> Projects { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;
    
    /// <summary>
    /// Sets up all configurations
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfDbContext).Assembly);
    }
}