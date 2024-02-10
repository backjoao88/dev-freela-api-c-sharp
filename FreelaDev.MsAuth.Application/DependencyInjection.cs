using FreelaDev.MsAuth.Application.Commands.User.Create;
using Microsoft.Extensions.DependencyInjection;

namespace FreelaDev.MsAuth.Application;

public static class DependencyInjection 
{
    /// <summary>
    /// Sets up all application layer dependencies.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(o => o.RegisterServicesFromAssemblies(typeof(CreateUserCommand).Assembly));
        return services;
    }
}