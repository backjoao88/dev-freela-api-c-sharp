using FreelaDev.MsProjects.Core.Primitives.Result;
using MediatR;

namespace FreelaDev.MsProjects.Application.Commands.Projects.Start;

/// <summary>
/// Represents a command to start a new project.
/// </summary>
public class StartProjectCommand : IRequest<Result>
{
    public StartProjectCommand(Guid idProject)
    {
        IdProject = idProject;
    }
    public Guid IdProject { get; set; }
}