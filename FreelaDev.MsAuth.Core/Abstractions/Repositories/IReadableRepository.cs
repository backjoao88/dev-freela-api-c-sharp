namespace FreelaDev.MsAuth.Core.Abstractions.Repositories;

/// <summary>
/// Represents an readable repository.
/// </summary>
public interface IReadableRepository<T> where T : class
{
    /// <summary>
    /// Gets an entity by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The requested entity.</returns>
    public Task<T?> GetById(Guid id);
}