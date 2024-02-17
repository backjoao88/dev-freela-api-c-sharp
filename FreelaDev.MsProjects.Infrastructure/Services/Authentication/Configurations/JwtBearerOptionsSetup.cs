using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FreelaDev.MsProjects.Infrastructure.Services.Authentication.Configurations;

/// <summary>
/// Sets up a <see cref="JwtBearerOptions"/> and it's validations;
/// </summary>
public class JwtBearerOptionsSetup : IConfigureNamedOptions<JwtBearerOptions>
{
    readonly JwtOptions _jwtOptions;

    public JwtBearerOptionsSetup(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
    }

    public void Configure(JwtBearerOptions options)
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = false,
            ValidIssuer = _jwtOptions.Issuer,
            ValidAudience = _jwtOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key)),
        };
    }
    
    public void Configure(string? name, JwtBearerOptions options)
    {
        Configure(options);
    }
}