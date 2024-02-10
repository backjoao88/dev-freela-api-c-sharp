using FreelaDev.MsAuth.Core.Primitives;

namespace FreelaDev.MsAuth.Core.Abstractions.Repositories;

/// <summary>
/// Contract to represent an writable repository.
/// </summary>
public interface IWritableRepository<in T> where T : Entity
{
    /// <summary>
    /// Save an entity.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task SaveAsync(T entity);
}