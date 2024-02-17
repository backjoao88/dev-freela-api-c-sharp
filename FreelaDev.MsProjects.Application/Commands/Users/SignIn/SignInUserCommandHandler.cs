using FreelaDev.MsProjects.Application.Services.Authentication;
using FreelaDev.MsProjects.Application.ViewModels;
using FreelaDev.MsProjects.Core.Abstractions;
using FreelaDev.MsProjects.Core.Enumerations;
using FreelaDev.MsProjects.Core.Primitives;
using FreelaDev.MsProjects.Core.Primitives.Result;
using MediatR;

namespace FreelaDev.MsProjects.Application.Commands.Users.SignIn;

/// <summary>
/// Represents the <see cref="SignInUserCommand"/> handler.
/// </summary>
public class SignInUserCommandHandler : IRequestHandler<SignInUserCommand, Result<SignInRequest>>
{
    readonly IUnitOfWork _unitOfWork;
    readonly IJwtProvider _jwtProvider;
    
    public SignInUserCommandHandler(IUnitOfWork unitOfWork, IJwtProvider jwtProvider)
    {
        _unitOfWork = unitOfWork;
        _jwtProvider = jwtProvider;
    }

    public async Task<Result<SignInRequest>> Handle(SignInUserCommand request, CancellationToken cancellationToken)
    {
        var encriptedPassword = _jwtProvider.ComputeSha256(request.Password);
        var user = await _unitOfWork.UserRepository.MatchEmailAndPassword(request.Email, encriptedPassword);
        Console.WriteLine(user?.Email);
        if (user is null)
        {
            return Result.Fail<SignInRequest>(DomainErrors.User.WrongCredentials);
        }
        var token = _jwtProvider.Generate(user.Id, Enum.GetName(typeof(ERole), user.Role)!.ToLower());
        return Result.Ok(new SignInRequest(user.Id, token));
    }
}