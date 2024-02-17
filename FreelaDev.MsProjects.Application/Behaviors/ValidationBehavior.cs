using FluentValidation;
using FreelaDev.MsProjects.Application.Exceptions;
using FreelaDev.MsProjects.Core.Primitives;
using MediatR;

namespace FreelaDev.MsProjects.Application.Behaviors;

/// <summary>
/// Represents a validation behavior from MediatR.
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }
        var validationContext = new ValidationContext<TRequest>(request);
        var errors = _validators
            .Select(o => o.Validate(validationContext))
            .SelectMany(o => o.Errors)
            .Select(o => new Error(o.ErrorCode, o.ErrorMessage))
            .DistinctBy(o => o.Code)
            .ToArray();

        if (errors.Any())
        {
            throw new CustomValidationException(errors);
        }
        return await next();
    }
}