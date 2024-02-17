using FreelaDev.MsProjects.Core.Entities;
using FreelaDev.MsProjects.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FreelaDev.MsProjects.Infrastructure.Persistence.Repositories;

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
    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _efDbContext.Users.SingleOrDefaultAsync(o => o != null && o.Id == id);
    }

    /// <inheritdoc/>
    public async Task<List<User>> GetAllAsync()
    {
        return await _efDbContext.Users.ToListAsync();
    }
    
    /// <inheritedoc/>
    public async Task<bool> IsEmailUnique(string email)
    {
        return !await _efDbContext.Users.AnyAsync(o => o.Email == email);
    }

    /// <inherittdoc/>
    public async Task<User?> MatchEmailAndPassword(string email, string password)
    {
        return await _efDbContext.Users.SingleOrDefaultAsync(o => o.Email == email && o.PasswordHash == password);
    }
    
}