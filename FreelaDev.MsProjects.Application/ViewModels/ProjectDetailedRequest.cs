using FreelaDev.MsProjects.Core.Entities;

namespace FreelaDev.MsProjects.Application.ViewModels;

/// <summary>
/// Represents a detailed view model of <see cref="Project"/>
/// </summary>
public class ProjectDetailedRequest
{
    public ProjectDetailedRequest(Guid id, string title, string description, Guid idClient, UserDetailedRequest client, Guid idFreelancer, UserDetailedRequest freelancer, DateTime? startedAt, DateTime? finishedAt, decimal totalCost, List<CommentSimpleRequest>? comments)
    {
        Id = id;
        Title = title;
        Description = description;
        IdClient = idClient;
        IdFreelancer = idFreelancer;
        TotalCost = totalCost;
        Comments = comments;
        Client = client;
        Freelancer = freelancer;
        StartedAt = startedAt;
        FinishedAt = finishedAt;
    }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid IdClient { get; set; }
    public UserDetailedRequest Client { get; set; }
    public Guid IdFreelancer { get; set; }
    public UserDetailedRequest Freelancer { get; set; }
    public decimal TotalCost { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? FinishedAt { get; set; }
    public List<CommentSimpleRequest>? Comments { get; set; }
}