using FreelaDev.MsAuth.Core.Abstractions;
using FreelaDev.MsAuth.Core.Repositories;

namespace FreelaDev.MsAuth.Infrastructure.Persistence;

/// <inheritdoc/>
public class EfUnitOfWork : IUnitOfWork
{

    readonly EfDbContext _efDbContext;

    public EfUnitOfWork(EfDbContext efDbContext, IUserRepository userRepository)
    {
        _efDbContext = efDbContext;
        UserRepository = userRepository;
    }

    public IUserRepository UserRepository { get; set; }
    
    /// <inheritdoc/>
    public async Task<int> Complete()
    {
        return await _efDbContext.SaveChangesAsync();
    }
}