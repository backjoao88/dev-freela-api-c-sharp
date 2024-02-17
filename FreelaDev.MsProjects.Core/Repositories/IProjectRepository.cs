using FreelaDev.MsProjects.Core.Abstractions.Repositories;
using FreelaDev.MsProjects.Core.Entities;

namespace FreelaDev.MsProjects.Core.Repositories;

/// <summary>
/// Represents the project data access layer.
/// </summary>
public interface IProjectRepository : IWritableRepository<Project>, IReadableAllRepository<Project>, IReadableRepository<Project>
{
    /// <summary>
    /// Saves a new comment into the project.
    /// </summary>
    /// <param name="idProject"></param>
    /// <param name="comment"></param>
    public Task SaveCommentAsync(Comment comment);
    /// <summary>
    /// Gets all comments from a specific project.
    /// </summary>
    public Task<List<Comment>> GetAllCommentsAsync(Guid idProject);
}