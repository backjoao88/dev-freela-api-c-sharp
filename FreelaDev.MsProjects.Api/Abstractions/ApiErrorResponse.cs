using FreelaDev.MsProjects.Core.Primitives;

namespace FreelaDev.MsProjects.Api.Abstractions;

/// <summary>
/// Represents the base api error response.
/// </summary>
public class ApiErrorResponse
{
    public ApiErrorResponse(Error[] errors)
    {
        Errors = errors;
    }
    public Error[] Errors { get; set; }
}