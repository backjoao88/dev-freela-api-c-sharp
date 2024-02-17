using System.Runtime.InteropServices.JavaScript;
using FreelaDev.MsProjects.Core.Primitives;
using FreelaDev.MsProjects.Core.Primitives.Result;

namespace FreelaDev.MsProjects.Core.Entities;

/// <summary>
/// Represents the project entity.
/// </summary>
public class Project : Entity
{
    private Project(){}
    public Project(string title, string description, Guid idClient, Guid idFreelancer, decimal totalCost, DateTime? startedAt, DateTime? finishedAt)
    {
        Title = title;
        Description = description;
        IdClient = idClient;
        IdFreelancer = idFreelancer;
        TotalCost = totalCost;
        StartedAt = startedAt;
        FinishedAt = finishedAt;
    }
    public string Title { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public Guid IdClient { get; private set; }
    public User Client { get; private set; } = null!;
    public Guid IdFreelancer { get; private set; }
    public User Freelancer { get; set; } = null!;
    public decimal TotalCost { get; private set; }
    public DateTime? StartedAt { get; private set; }
    public DateTime? FinishedAt { get; private set; }
    public List<Comment> Comments { get; private set; } = null!;
    
    /// <summary>
    /// Sets the start date to now of the current project.
    /// </summary>
    public Result Start()
    {
        if (FinishedAt is not null)
        {
            return Result.Fail(DomainErrors.Project.ProjectAlreadyFinished);
        }
        if (StartedAt is not null)
        {
            return Result.Fail(DomainErrors.Project.ProjectAlreadyStarted);
        }
        StartedAt = DateTime.Now;
        return Result.Ok();
    }

    /// <summary>
    /// Sets the finish date to now of the current project.
    /// </summary>
    public Result Finish()
    {
        if (StartedAt is null)
        {
            return Result.Fail(DomainErrors.Project.ProjectAlreadyStarted);
        }
        if (FinishedAt is not null)
        {
            return Result.Fail(DomainErrors.Project.ProjectAlreadyFinished);
        }
        FinishedAt = DateTime.Now;
        return Result.Ok();
    }
    
}