using FreelaDev.MsProjects.Core.Enumerations;
using FreelaDev.MsProjects.Core.Primitives.Result;
using FreelaDev.MsProjects.Core.ValueObjects;
using MediatR;

namespace FreelaDev.MsProjects.Application.Commands.Users.Create;

/// <summary>
/// Represents the command to create an user.
/// </summary>
public class CreateUserCommand : IRequest<Result>
{
    public CreateUserCommand(string firstName, string lastName, string email, string password, ERole role, List<Skill> skills)
    {
        Email = email;
        Password = password;
        Skills = skills;
        FirstName = firstName;
        LastName = lastName;
        Role = role;
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ERole Role { get; set; }
    public List<Skill> Skills { get; set; }
}