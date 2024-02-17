using FreelaDev.MsProjects.Core.Primitives;

namespace FreelaDev.MsProjects.Core.Abstractions.Repositories;

/// <summary>
/// Represents an readable all repository.
/// </summary>
public interface IReadableAllRepository<TEntity> where TEntity : Entity
{
    /// <summary>
    /// Reads all entities.
    /// </summary>
    /// <returns></returns>
    public Task<List<TEntity>> GetAllAsync();
}