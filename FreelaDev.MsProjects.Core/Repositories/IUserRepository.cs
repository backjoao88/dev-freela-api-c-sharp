using FreelaDev.MsProjects.Core.Abstractions.Repositories;
using FreelaDev.MsProjects.Core.Entities;

namespace FreelaDev.MsProjects.Core.Repositories;

/// <summary>
/// Represents the user data access layer.
/// </summary>
public interface IUserRepository : IWritableRepository<User>, IReadableRepository<User>, IReadableAllRepository<User>
{
    /// <summary>
    /// Checks if the e-mail parameter value is unique in the database.
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public Task<bool> IsEmailUnique(string email);
    /// <summary>
    /// Checks if the e-mail and password matches.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public Task<User?> MatchEmailAndPassword(string email, string password);
    
}