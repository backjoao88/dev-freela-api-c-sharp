using FreelaDev.MsAuth.Core.Repositories;

namespace FreelaDev.MsAuth.Core.Abstractions;

/// <summary>
/// Represents the unit of work contract.
/// </summary>
public interface IUnitOfWork
{
    public IUserRepository UserRepository { get; set; }
 
    /// <summary>
    /// Completes a transaction to the database.
    /// </summary>
    /// <returns></returns>
    public Task<int> Complete();
}