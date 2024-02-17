using FreelaDev.MsProjects.Core.Abstractions;
using FreelaDev.MsProjects.Core.Entities;
using FreelaDev.MsProjects.Core.Primitives;
using FreelaDev.MsProjects.Core.Primitives.Result;
using MediatR;

namespace FreelaDev.MsProjects.Application.Commands.Projects.CreateComment;

/// <summary>
/// Represents the <see cref="CreateCommentCommand"/> handler
/// </summary>
public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Result>
{
    private IUnitOfWork _unitOfWork;

    public CreateCommentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var project = await _unitOfWork.ProjectRepository.GetByIdAsync(request.IdProject);
        if (project is null)
        {
            return Result.Fail(DomainErrors.Project.ProjectNotFound);
        }
        var user = await _unitOfWork.UserRepository.GetByIdAsync(request.IdUser);
        if (user is null)
        {
            return Result.Fail(DomainErrors.User.UserNotFound);
        }
        var comment = new Comment(request.IdProject, request.IdUser, request.Content);
        await _unitOfWork.ProjectRepository.SaveCommentAsync(comment);
        await _unitOfWork.CompleteAsync();
        return Result.Ok();
    }
}