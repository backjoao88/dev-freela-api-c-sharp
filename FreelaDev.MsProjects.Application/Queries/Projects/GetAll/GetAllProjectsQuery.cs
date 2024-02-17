using FreelaDev.MsProjects.Application.ViewModels;
using MediatR;

namespace FreelaDev.MsProjects.Application.Queries.Projects.GetAll;

/// <summary>
/// Represents a query to retrieve all projects
/// </summary>
public class GetAllProjectsQuery : IRequest<List<ProjectDetailedRequest>>;