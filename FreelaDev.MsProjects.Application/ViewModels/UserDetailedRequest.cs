using FreelaDev.MsProjects.Core.Entities;
using FreelaDev.MsProjects.Core.ValueObjects;

namespace FreelaDev.MsProjects.Application.ViewModels;


/// <summary>
/// Represents a <see cref="User"/> simple view model
/// </summary>
public class UserDetailedRequest
{
    public UserDetailedRequest(Guid id, string firstName, string lastName, string email, List<Skill> skills)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Skills = skills;
    }
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public List<Skill> Skills { get; set; }
}