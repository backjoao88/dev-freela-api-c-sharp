using FreelaDev.MsProjects.Core.Primitives.Result;
using MediatR;

namespace FreelaDev.MsProjects.Application.Commands.Projects.CreateComment;

/// <summary>
/// Represents a command to create a new comment
/// </summary>
public class CreateCommentCommand : IRequest<Result>
{
    public CreateCommentCommand(Guid idUser, Guid idProject, string content)
    {
        IdUser = idUser;
        IdProject = idProject;
        Content = content;
    }
    public Guid IdUser { get; set; }
    public Guid IdProject { get; set; }
    public string Content { get; set; }
}