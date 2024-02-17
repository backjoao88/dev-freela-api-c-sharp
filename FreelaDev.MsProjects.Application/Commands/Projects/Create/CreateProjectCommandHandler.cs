using System.Runtime.InteropServices.JavaScript;
using FreelaDev.MsProjects.Application.Services.Payment;
using FreelaDev.MsProjects.Core.Abstractions;
using FreelaDev.MsProjects.Core.Entities;
using FreelaDev.MsProjects.Core.Primitives;
using FreelaDev.MsProjects.Core.Primitives.Result;
using MediatR;

namespace FreelaDev.MsProjects.Application.Commands.Projects.Create;

/// <summary>
/// Represents the <see cref="CreateProjectCommand"/> handler
/// </summary>
public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Result>
{
    IUnitOfWork _unitOfWork;

    public CreateProjectCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        if (request.IdFreelancer == request.IdClient)
        {
            return Result.Fail(DomainErrors.User.UserClientAndFreelancerMustNotBeEqual);
        }
        var client = await _unitOfWork.UserRepository.GetByIdAsync(request.IdClient);
        if (client is null)
        {
            return Result.Fail(DomainErrors.User.UserNotFound);
        }
        var freelancer = await _unitOfWork.UserRepository.GetByIdAsync(request.IdFreelancer);
        if (freelancer is null)
        {
            return Result.Fail(DomainErrors.User.UserNotFound);
        }
        var project = new Project(request.Title, request.Description, request.IdClient, request.IdFreelancer, request.TotalCost,
            null!, null!);
        await _unitOfWork.ProjectRepository.SaveAsync(project);
        await _unitOfWork.CompleteAsync();
        return Result.Ok();
    }
}