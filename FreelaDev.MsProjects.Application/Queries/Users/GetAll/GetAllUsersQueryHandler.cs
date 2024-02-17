using FreelaDev.MsProjects.Application.ViewModels;
using FreelaDev.MsProjects.Core.Abstractions;
using MediatR;

namespace FreelaDev.MsProjects.Application.Queries.Users.GetAll;

/// <summary>
/// Represents the <see cref="GetAllUsersQuery"/> handler.
/// </summary>
public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserRequest>>
{
    readonly IUnitOfWork _unitOfWork;

    public GetAllUsersQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<UserRequest>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _unitOfWork.UserRepository.GetAllAsync();
        var usersViewModel = users
            .Select(o => new UserRequest(o.Id, o.FirstName, o.LastName, o.Email, o.Skills.ToList()))
            .ToList();
        return usersViewModel;
    }
}