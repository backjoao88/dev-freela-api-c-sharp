using FreelaDev.MsAuth.Core.Entities;
using FreelaDev.MsAuth.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FreelaDev.MsAuth.Infrastructure.Persistence.Repositories;

/// <inheritdoc/>
public class UserRepository : IUserRepository
{
    readonly EfDbContext _efDbContext;

    public UserRepository(EfDbContext efDbContext)
    {
        _efDbContext = efDbContext;
    }

    /// <inheritdoc/>
    public async Task SaveAsync(User entity)
    {
        await _efDbContext.Users.AddAsync(entity);
    }

    /// <inheritdoc/>
    public async Task<User?> GetById(Guid id)
    {
        return await _efDbContext.Users.SingleOrDefaultAsync(o => o != null && o.Id == id);
    }
}