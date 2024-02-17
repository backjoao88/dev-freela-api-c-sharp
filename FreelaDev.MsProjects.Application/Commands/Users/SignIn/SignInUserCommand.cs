using FreelaDev.MsProjects.Application.ViewModels;
using FreelaDev.MsProjects.Core.Primitives.Result;
using MediatR;

namespace FreelaDev.MsProjects.Application.Commands.Users.SignIn;

/// <summary>
/// Represents a command to login.
/// </summary>
public class SignInUserCommand : IRequest<Result<SignInRequest>>
{
    public SignInUserCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }
    public string Email { get; set; }
    public string Password { get; set; }
}