namespace FreelaDev.MsProjects.Infrastructure.Services.Authentication.Configurations;

/// <summary>
/// Represents the JWT options.
/// </summary>
public class JwtOptions
{
    public string Key { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
}