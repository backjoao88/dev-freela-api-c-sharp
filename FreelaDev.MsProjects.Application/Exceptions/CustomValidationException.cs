using FreelaDev.MsProjects.Core.Primitives;

namespace FreelaDev.MsProjects.Application.Exceptions;

/// <summary>
/// Represents a validation exception from application layer.
/// </summary>
public class CustomValidationException : Exception
{
    public readonly Error[] Errors;

    public CustomValidationException(Error[] errors)
    {
        Errors = errors;
    }
}