using FreelaDev.MsProjects.Application.Services.Authentication;
using FreelaDev.MsProjects.Core.Abstractions;
using FreelaDev.MsProjects.Core.Entities;
using FreelaDev.MsProjects.Core.Primitives;
using FreelaDev.MsProjects.Core.Primitives.Result;
using MediatR;

namespace FreelaDev.MsProjects.Application.Commands.Users.Create;

/// <summary>
/// Represents the <see cref="CreateUserCommand"/> handler.
/// </summary>
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
{
    readonly IUnitOfWork _unitOfWork;
    readonly IJwtProvider _jwtProvider;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork, IJwtProvider jwtProvider)
    {
        _unitOfWork = unitOfWork;
        _jwtProvider = jwtProvider;
    }

    public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (!await _unitOfWork.UserRepository.IsEmailUnique(request.Email))
        {
            return Result.Fail(DomainErrors.User.EmailNotUnique);
        }
        var encryptedPassword = _jwtProvider.ComputeSha256(request.Password);
        var user = new User(request.FirstName, request.LastName, request.Email, encryptedPassword, request.Role, request.Skills);
        if (!user.HasAnySkills())
        {
            return Result.Fail(DomainErrors.User.SkillsIsEmpty);
        }
        await _unitOfWork.UserRepository.SaveAsync(user);
        await _unitOfWork.CompleteAsync();
        return Result.Ok();
    }
}