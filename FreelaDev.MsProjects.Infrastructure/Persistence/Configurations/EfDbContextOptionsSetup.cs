using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace FreelaDev.MsProjects.Infrastructure.Persistence.Configurations;

/// <summary>
/// Represents a EF Db Context setup.
/// </summary>
public class EfDbContextOptionsSetup : IConfigureOptions<EfDbContextOptions>
{
    private readonly IConfiguration _configuration;
    private const string DbConnectionSectionName  = "Database";

    public EfDbContextOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Bind the <see cref="EfDbContextOptions"/>
    /// </summary>
    /// <param name="options"></param>
    public void Configure(EfDbContextOptions options)
    {
        _configuration
            .GetSection(DbConnectionSectionName)
            .Bind(options);
    }
}