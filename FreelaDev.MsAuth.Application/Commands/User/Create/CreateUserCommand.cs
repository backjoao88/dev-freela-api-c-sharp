using MediatR;

namespace FreelaDev.MsAuth.Application.Commands.User.Create;

/// <summary>
/// Represents the command to create an user.
/// </summary>
public class CreateUserCommand : IRequest
{
    public CreateUserCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }
    public string Email { get; set; }
    public string Password { get; set; }
}