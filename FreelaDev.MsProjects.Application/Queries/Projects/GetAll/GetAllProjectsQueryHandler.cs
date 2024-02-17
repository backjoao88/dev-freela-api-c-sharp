using FreelaDev.MsProjects.Application.ViewModels;
using FreelaDev.MsProjects.Core.Abstractions;
using MediatR;

namespace FreelaDev.MsProjects.Application.Queries.Projects.GetAll;

/// <summary>
/// Represents the <see cref="GetAllProjectsQuery"/> handler
/// </summary>
public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectDetailedRequest>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllProjectsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<ProjectDetailedRequest>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        var projects = await _unitOfWork.ProjectRepository.GetAllAsync();
        var projectsViewModel = projects.Select(
            o =>
            {
                var clientViewModel = new UserDetailedRequest(o.Client.Id, o.Client.FirstName, o.Client.LastName,
                    o.Client.Email, o.Client.Skills);
                var freelancerViewModel = new UserDetailedRequest(o.Freelancer.Id, o.Freelancer.FirstName,
                    o.Freelancer.LastName, o.Freelancer.Email, o.Freelancer.Skills);
                var commentsViewModel =
                    o.Comments?.Select(c => new CommentSimpleRequest(c.IdUser, c.Content)).ToList();
                return new ProjectDetailedRequest(
                    o.Id,
                    o.Title,
                    o.Description,
                    o.IdClient,
                    clientViewModel,
                    o.IdFreelancer,
                    freelancerViewModel,
                    o.StartedAt,
                    o.FinishedAt,
                    o.TotalCost,
                    commentsViewModel
                );
            }
        ).ToList();
        return projectsViewModel;
    }
}