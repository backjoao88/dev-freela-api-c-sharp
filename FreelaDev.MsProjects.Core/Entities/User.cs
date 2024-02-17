using FreelaDev.MsProjects.Core.Enumerations;
using FreelaDev.MsProjects.Core.Primitives;
using FreelaDev.MsProjects.Core.ValueObjects;

namespace FreelaDev.MsProjects.Core.Entities;

/// <summary>
/// Represents the user entity.
/// </summary>
public class User : Entity
{
    /// <summary>
    /// Required by EFCore.
    /// </summary>
    private User(){}
    public User(string firstName, string lastName, string email, string passwordHash, ERole role, List<Skill> skills)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
        Skills = skills;
        Role = role;
    }
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public ERole Role { get; private set; }
    public List<Skill> Skills { get; private set; } = null!;

    /// <summary>
    /// Checks if this user has any skills.
    /// </summary>
    /// <returns>A bool value.</returns>
    public bool HasAnySkills()
    {
        return Skills.Count() > 0;
    }
    
}