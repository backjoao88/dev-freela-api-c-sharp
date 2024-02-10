using FreelaDev.MsAuth.Core.Abstractions;
using FreelaDev.MsAuth.Core.Repositories;
using FreelaDev.MsAuth.Infrastructure.Persistence;
using FreelaDev.MsAuth.Infrastructure.Persistence.Configurations;
using FreelaDev.MsAuth.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FreelaDev.MsAuth.Infrastructure;

/// <summary>
/// Sets all dependencies defined in the Infrastructure layer
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services
            .ConfigureOptions<EfDbContextOptionsSetup>()
            .AddDbContext<EfDbContext>(((provider, builder) =>
            {
                var options = provider.GetService<IOptions<EfDbContextOptions>>()!.Value;
                builder.UseSqlServer(options?.ConnectionString);
            }));
        return services;
    }
    
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, EfUnitOfWork>();
        return services;
    }
}