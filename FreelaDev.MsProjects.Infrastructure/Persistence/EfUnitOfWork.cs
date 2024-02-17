using FreelaDev.MsProjects.Core.Abstractions;
using FreelaDev.MsProjects.Core.Repositories;

namespace FreelaDev.MsProjects.Infrastructure.Persistence;

/// <inheritdoc/>
public class EfUnitOfWork : IUnitOfWork
{

    readonly EfDbContext _efDbContext;

    public EfUnitOfWork(EfDbContext efDbContext, IUserRepository userRepository, IProjectRepository projectRepository)
    {
        _efDbContext = efDbContext;
        UserRepository = userRepository;
        ProjectRepository = projectRepository;
    }

    public IUserRepository UserRepository { get; set; }
    public IProjectRepository ProjectRepository { get; set; }
    
    /// <inheritdoc/>
    public async Task<int> CompleteAsync()
    {
        return await _efDbContext.SaveChangesAsync();
    }
}