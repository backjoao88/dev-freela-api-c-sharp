using FreelaDev.MsProjects.Application.ViewModels;
using FreelaDev.MsProjects.Core.Entities;
using MediatR;

namespace FreelaDev.MsProjects.Application.Queries.Users.GetAll;

/// <summary>
/// Represents the get all query.
/// </summary>
public class GetAllUsersQuery : IRequest<List<UserRequest>>;