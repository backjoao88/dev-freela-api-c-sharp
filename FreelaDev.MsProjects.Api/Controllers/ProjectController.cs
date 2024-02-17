using FreelaDev.MsProjects.Api.Abstractions;
using FreelaDev.MsProjects.Api.Attributes;
using FreelaDev.MsProjects.Application.Commands.Projects.Create;
using FreelaDev.MsProjects.Application.Commands.Projects.CreateComment;
using FreelaDev.MsProjects.Application.Commands.Projects.Finish;
using FreelaDev.MsProjects.Application.Commands.Projects.Start;
using FreelaDev.MsProjects.Application.Queries.Projects.GetAll;
using FreelaDev.MsProjects.Core.Enumerations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FreelaDev.MsProjects.Api.Controllers;

/// <summary>
/// Represents the user request handler.
/// </summary>
[ApiController]
[Route("/api/projects")]
public class ProjectController : ApiController
{

    readonly IMediator _mediator;

    public ProjectController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Endpoint used to save a new project.
    /// </summary>
    /// <param name="createProjectCommand"></param>
    [HttpPost]
    [HasPermission(ERole.Admin, ERole.Client)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] CreateProjectCommand createProjectCommand)
    {
        var result = await _mediator.Send(createProjectCommand);
        return result.IsSuccess 
            ? Created() 
            : BadRequest(result.Error);
    }

    /// <summary>
    /// Endpoint used to save a new project comment.
    /// </summary>
    /// <param name="createCommentCommand"></param>
    [HttpPost("comments")]
    [HasPermission(ERole.Admin, ERole.Client, ERole.Freelancer)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostComment([FromBody] CreateCommentCommand createCommentCommand)
    {
        var result = await _mediator.Send(createCommentCommand);
        return result.IsSuccess 
            ? Created() 
            : BadRequest(result.Error);
    }
    
    /// <summary>
    /// Endpoint used to retrieve all projects.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [HasPermission(ERole.Admin)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var projectsRequest = await _mediator.Send(new GetAllProjectsQuery());
        return Ok(projectsRequest);
    }

    /// <summary>
    /// Endpoint used to start a project
    /// </summary>
    /// <returns></returns>
    [HttpPut("start")]
    [HasPermission(ERole.Admin, ERole.Client, ERole.Freelancer)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Start([FromBody] StartProjectCommand startProjectCommand)
    {
        var result = await _mediator.Send(startProjectCommand);
        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }

    /// <summary>
    /// Endpoint used to finish a project
    /// </summary>
    /// <returns></returns>
    [HttpPut("finish")]
    [HasPermission(ERole.Admin, ERole.Client, ERole.Freelancer)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Finish([FromBody] FinishProjectCommand finishProjectCommand)
    {
        var result = await _mediator.Send(finishProjectCommand);
        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }
}