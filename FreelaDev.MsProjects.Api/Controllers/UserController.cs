using FreelaDev.MsProjects.Api.Abstractions;
using FreelaDev.MsProjects.Api.Attributes;
using FreelaDev.MsProjects.Application.Commands.Users.Create;
using FreelaDev.MsProjects.Application.Commands.Users.SignIn;
using FreelaDev.MsProjects.Application.Queries.Users.GetAll;
using FreelaDev.MsProjects.Core.Enumerations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FreelaDev.MsProjects.Api.Controllers;

/// <summary>
/// Represents the user request handler.
/// </summary>
[ApiController]
[Route("/api/users")]
public class UserController : ApiController
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Endpoint used to save a new user.
    /// </summary>
    /// <param name="createUserCommand"></param>
    /// <returns>A status 204 Created</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Post([FromBody] CreateUserCommand createUserCommand)
    {
        var result = await _mediator.Send(createUserCommand);
        return result.IsSuccess 
            ? Created() 
            : BadRequest(result.Error);
    }

    /// <summary>
    /// Endpoint used to retrieve all users.
    /// </summary>
    /// <returns>A status 200 Ok</returns>
    [HttpGet]
    [HasPermission(ERole.Admin)]
    public async Task<IActionResult> GetAll()
    {
        var users = await _mediator.Send(new GetAllUsersQuery());
        return Ok(users);
    }

    /// <summary>
    /// Endpoint used to handle the user sign in attempt.
    /// </summary>
    /// <param name="signInUserCommand"></param>
    [HttpPut("signin")]
    public async Task<IActionResult> SignIn([FromBody] SignInUserCommand signInUserCommand)
    {
        var result = await _mediator.Send(signInUserCommand);
        return result.IsSuccess 
            ? Ok(result.Data) 
            : BadRequest(result.Error);
    }
}