using Microsoft.Extensions.DependencyInjection;

namespace FreelaDev.MsPayments.Application;

/// <summary>
/// Sets up application dependencies.
/// </summary>
public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(o => o.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
    }
}