namespace FreelaDev.MsAuth.Infrastructure.Persistence.Configurations;

/// <summary>
/// Represents a collection of EF context options
/// </summary>
public class EfDbContextOptions
{
    public string ConnectionString { get; set; } = string.Empty;
}