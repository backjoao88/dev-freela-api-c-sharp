using FreelaDev.MsAuth.Core.Primitives;
namespace FreelaDev.MsAuth.Core.Entities;

/// <summary>
/// Represents the user entity.
/// </summary>
public class User : Entity
{
    public User(string email, string passwordHash)
    {
        Email = email;
        PasswordHash = passwordHash;
    }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}