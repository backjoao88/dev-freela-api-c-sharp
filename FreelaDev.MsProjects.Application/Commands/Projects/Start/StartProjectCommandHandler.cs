using System.Runtime.InteropServices.JavaScript;
using FreelaDev.MsProjects.Application.Commands.Projects.Finish;
using FreelaDev.MsProjects.Core.Abstractions;
using FreelaDev.MsProjects.Core.Primitives;
using FreelaDev.MsProjects.Core.Primitives.Result;
using MediatR;

namespace FreelaDev.MsProjects.Application.Commands.Projects.Start;

public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public StartProjectCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(StartProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _unitOfWork.ProjectRepository.GetByIdAsync(request.IdProject);
        if (project is null)
        {
            return Result.Fail(DomainErrors.Project.ProjectNotFound);
        }
        var startResult = project.Start();
        if (startResult.IsFailure)
        {
            return startResult; 
        }
        await _unitOfWork.CompleteAsync();
        return Result.Ok();
    } 
}