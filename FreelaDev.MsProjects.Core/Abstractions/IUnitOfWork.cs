using FreelaDev.MsProjects.Core.Repositories;

namespace FreelaDev.MsProjects.Core.Abstractions;

/// <summary>
/// Represents the unit of work contract.
/// </summary>
public interface IUnitOfWork
{
    public IUserRepository UserRepository { get; set; }
    public IProjectRepository ProjectRepository { get; set; } 
    /// <summary>
    /// Completes a transaction to the database.
    /// </summary>
    /// <returns></returns>
    public Task<int> CompleteAsync();
}