using System.Net;
using System.Net.Mime;
using System.Text.Json;
using FreelaDev.MsProjects.Api.Abstractions;
using FreelaDev.MsProjects.Application.Exceptions;
using FreelaDev.MsProjects.Core.Primitives;

namespace FreelaDev.MsProjects.Api.Middlewares;

/// <summary>
/// Represents the global exception middleware.
/// </summary>
public class ExceptionMiddleware : IMiddleware
{

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (CustomValidationException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            var apiErrorResponse = new ApiErrorResponse(exception.Errors);
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            string apiErrorResponseStr = JsonSerializer.Serialize(apiErrorResponse, options);
            await context.Response.WriteAsync(apiErrorResponseStr);
        }
        catch (Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            var apiErrorResponse = new ApiErrorResponse(new []{new Error("Server.UnknownError", exception.Message)});
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            string apiErrorResponseStr = JsonSerializer.Serialize(apiErrorResponse, options);
            await context.Response.WriteAsync(apiErrorResponseStr);
        }
    }
}