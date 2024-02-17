using FluentValidation;
using FreelaDev.MsProjects.Application.Behaviors;
using FreelaDev.MsProjects.Application.Commands.Users.Create;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FreelaDev.MsProjects.Application;

public static class DependencyInjection 
{

    /// <summary>
    /// Sets up all validators.
    /// </summary>
    /// <param name="services"></param>
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        return services;
    }
    
    /// <summary>
    /// Sets up all application layer dependencies.
    /// </summary>
    /// <param name="services"></param>
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(o => o.RegisterServicesFromAssemblies(typeof(CreateUserCommand).Assembly));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }
}