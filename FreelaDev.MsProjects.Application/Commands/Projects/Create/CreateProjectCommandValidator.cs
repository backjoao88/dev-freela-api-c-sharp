using FluentValidation;

namespace FreelaDev.MsProjects.Application.Commands.Projects.Create;

/// <summary>
/// Represents the <see cref="CreateProjectCommand"/> validator.
/// </summary>
public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(o => o.Title).NotEmpty();
        RuleFor(o => o.Description).NotEmpty();
    }
}