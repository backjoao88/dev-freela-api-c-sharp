using FreelaDev.MsProjects.Api.Middlewares;
using FreelaDev.MsProjects.Application;
using FreelaDev.MsProjects.Application.Exceptions;
using FreelaDev.MsProjects.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Server.HttpSys;

namespace FreelaDev.MsProjects.Api;

public static class Program
{
    /// <summary>
    /// API main entrypoint.
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddScoped<ExceptionMiddleware>();
        builder.Services.AddDatabase();
        builder.Services.AddBroker();
        builder.Services.AddPayment();
        builder.Services.AddValidators();
        builder.Services.AddMediator();
        builder.Services.AddJwt();
        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();
        builder.Services.AddAuthorization();
        var app = builder.Build();
        app.MapControllers();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseMiddleware<ExceptionMiddleware>();
        app.Services.ApplyMigrations();
        app.Run();
    }
}