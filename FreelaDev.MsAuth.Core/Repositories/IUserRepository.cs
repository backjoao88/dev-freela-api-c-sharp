using FreelaDev.MsAuth.Core.Abstractions;
using FreelaDev.MsAuth.Core.Abstractions.Repositories;

namespace FreelaDev.MsAuth.Core.Repositories;
using Entities;

/// <summary>
/// Represents the user data access layer.
/// </summary>
public interface IUserRepository : IWritableRepository<User>, IReadableRepository<User>;