using FreelaDev.MsProjects.Core.Primitives;

namespace FreelaDev.MsProjects.Core.Entities;

/// <summary>
/// Represents the project comment entity.
/// </summary>
public class Comment : Entity
{
    Comment(){}
    public Comment(Guid idProject, Guid idUser, string content)
    {
        IdProject = idProject;
        IdUser = idUser;
        Content = content;
    }
    public Guid IdProject { get; private set; }
    public Guid IdUser { get; private set; }
    public string Content { get; private set; } = null!;
}