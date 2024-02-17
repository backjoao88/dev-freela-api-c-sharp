using FreelaDev.MsProjects.Core.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace FreelaDev.MsProjects.Api.Abstractions;

/// <summary>
/// Represents the base controller.
/// </summary>
public class ApiController : ControllerBase
{
    [NonAction]
    public IActionResult BadRequest(Error error) => BadRequest(new ApiErrorResponse(new[] { error }));
}