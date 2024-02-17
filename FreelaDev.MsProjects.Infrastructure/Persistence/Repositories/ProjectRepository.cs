using FreelaDev.MsProjects.Core.Abstractions.Repositories;
using FreelaDev.MsProjects.Core.Entities;
using FreelaDev.MsProjects.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FreelaDev.MsProjects.Infrastructure.Persistence.Repositories;

/// <inheriteddoc/>
public class ProjectRepository : IProjectRepository
{
    EfDbContext _dbContext;

    public ProjectRepository(EfDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheriteddoc/>
    public async Task SaveAsync(Project entity)
    {
        await _dbContext.Projects.AddAsync(entity);
    }

    /// <inheriteddoc/>
    public async Task<List<Project>> GetAllAsync()
    {
        return await _dbContext.Projects
            .Include(o => o.Client)
            .Include(o => o.Freelancer)
            .Include(o => o.Comments)
            .ToListAsync();
    }

    /// <inheriteddoc/>
    public async Task<Project?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Projects
            .Include(o => o.Client)
            .Include(o => o.Freelancer)
            .Include(o => o.Comments)
            .SingleOrDefaultAsync(o => o.Id == id);
    }

    /// <inheriteddoc/>
    public async Task SaveCommentAsync(Comment comment)
    {
        await _dbContext.Comments.AddAsync(comment);
    }

    /// <inheriteddoc/>
    public async Task<List<Comment>> GetAllCommentsAsync(Guid idProject)
    {
        return await _dbContext.Comments.ToListAsync();
    }
}