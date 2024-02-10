using FreelaDev.MsAuth.Core.Abstractions;
using MediatR;

namespace FreelaDev.MsAuth.Application.Commands.User.Create;

/// <summary>
/// Represents the <see cref="CreateUserCommand"/> handler.
/// </summary>
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine("Entrou no create user!!");
        await Task.Delay(2000);
    }
}