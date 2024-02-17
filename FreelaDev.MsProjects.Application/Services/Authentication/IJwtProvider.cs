namespace FreelaDev.MsProjects.Application.Services.Authentication;

/// <summary>
/// Represents a contract to define functionalities related to Authentication and Authorization.
/// </summary>
public interface IJwtProvider
{
    /// <summary>
    /// Generates a JWT Token based on an e-mail and a role.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="role"></param>
    /// <returns>A JWT token string format</returns>
    public string Generate(Guid userId, string role);

    /// <summary>
    /// Computes a HS256 string based on a string passed as parameter.
    /// </summary>
    /// <returns>A HS256 string</returns>
    public string ComputeSha256(string input);
}