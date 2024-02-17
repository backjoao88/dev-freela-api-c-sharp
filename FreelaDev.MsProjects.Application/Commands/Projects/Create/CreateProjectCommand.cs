using FreelaDev.MsProjects.Core.Primitives.Result;
using MediatR;

namespace FreelaDev.MsProjects.Application.Commands.Projects.Create;

/// <summary>
/// Represents the create project command.
/// </summary>
public class CreateProjectCommand : IRequest<Result>
{
    public CreateProjectCommand(string title, string description, Guid idClient, Guid idFreelancer, decimal totalCost)
    {
        Title = title;
        Description = description;
        IdClient = idClient;
        IdFreelancer = idFreelancer;
        TotalCost = totalCost;
    }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid IdClient { get; set; }
    public Guid IdFreelancer { get; set; }
    public decimal TotalCost { get; set; }
}