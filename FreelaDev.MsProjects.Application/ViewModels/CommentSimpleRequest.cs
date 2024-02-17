using FreelaDev.MsProjects.Core.Entities;

namespace FreelaDev.MsProjects.Application.ViewModels;

/// <summary>
/// Represents a simple <see cref="Comment"/> view model
/// </summary>
public class CommentSimpleRequest
{
    public CommentSimpleRequest(Guid idUser, string content)
    {
        IdUser = idUser;
        Content = content;
    }
    public Guid IdUser { get; set; }
    public string Content { get; set; }
}