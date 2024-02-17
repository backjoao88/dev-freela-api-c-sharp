using FreelaDev.MsProjects.Core.Primitives.Result;
using MediatR;

namespace FreelaDev.MsProjects.Application.Commands.Projects.Finish;

/// <summary>
/// Represents a command to finish a project.
/// </summary>
public class FinishProjectCommand : IRequest<Result>
{
    public FinishProjectCommand(Guid idProject)
    {
        IdProject = idProject;
    }
    public Guid IdProject { get; set; }
}