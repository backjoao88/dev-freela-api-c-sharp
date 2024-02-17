using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace FreelaDev.MsProjects.Infrastructure.Services.Authentication.Configurations;

/// <summary>
/// Sets up a <see cref="JwtOptions"/>
/// </summary>
public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
{
    private readonly string JwtConfigurationSectioName = "Authentication";
    readonly IConfiguration _configuration;

    public JwtOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtOptions options)
    {
        _configuration
            .GetSection(JwtConfigurationSectioName)
            .Bind(options);
    }
}