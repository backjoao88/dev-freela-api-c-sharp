using FreelaDev.MsAuth.Application.Commands.User.Create;
using Microsoft.AspNetCore.Mvc;

namespace FreelaDev.MsAuth.Api.Controllers;

/// <summary>
/// Represents the user request handler.
/// </summary>
[ApiController]
[Route("/api/users")]
public class UserController : ControllerBase
{
    /// <summary>
    /// Endpoint used to save a new user.
    /// </summary>
    /// <param name="createUserCommand"></param>
    /// <returns>A status 204 Created</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Post([FromBody] CreateUserCommand createUserCommand)
    {
        Console.WriteLine("Oiieee");
        return await Task.FromResult(Ok());
    }
}