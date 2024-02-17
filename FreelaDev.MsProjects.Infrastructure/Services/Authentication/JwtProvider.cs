using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using FreelaDev.MsProjects.Application.Services.Authentication;
using FreelaDev.MsProjects.Infrastructure.Services.Authentication.Configurations;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FreelaDev.MsProjects.Infrastructure.Services.Authentication;

/// <inheritdoc/>
public class JwtProvider : IJwtProvider
{
    readonly JwtOptions _jwtOptions;

    public JwtProvider(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
    }
    
    /// <inheritdoc/>
    public string Generate(Guid userId, string role)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
        var issuer = _jwtOptions.Issuer;
        var audience = _jwtOptions.Audience;
        var jwtHeader = new JwtHeader(new SigningCredentials(key, SecurityAlgorithms.HmacSha512));
        var claims = new List<Claim>()
        {
            new(JwtClaimTypes.Subject, userId.ToString()),
            new(ClaimTypes.Role, role),
        };
        var jwtPayload = new JwtPayload(issuer, audience, claims, new DateTime(), new DateTime().AddMinutes(240));
        var jwtSecurityToken = new JwtSecurityToken(jwtHeader, jwtPayload);
        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }

    /// <inheritdoc/>
    public string ComputeSha256(string input)
    {
        var crypt = SHA512.Create();
        var encryptedBytes = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
        StringBuilder stringBuilder = new StringBuilder();
        foreach(var chunk in encryptedBytes)
        {
            // x2 = hexadecimal
            stringBuilder.Append($"{chunk:X2}");
        }
        return stringBuilder.ToString();
    }
}