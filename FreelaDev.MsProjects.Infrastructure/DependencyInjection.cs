using FreelaDev.MsProjects.Application.Services.Authentication;
using FreelaDev.MsProjects.Application.Services.Payment;
using FreelaDev.MsProjects.Core.Abstractions;
using FreelaDev.MsProjects.Core.Repositories;
using FreelaDev.MsProjects.Infrastructure.Persistence;
using FreelaDev.MsProjects.Infrastructure.Persistence.Configurations;
using FreelaDev.MsProjects.Infrastructure.Persistence.Repositories;
using FreelaDev.MsProjects.Infrastructure.Services.Authentication;
using FreelaDev.MsProjects.Infrastructure.Services.Authentication.Configurations;
using FreelaDev.MsProjects.Infrastructure.Services.Payment;
using FreelaDev.MsProjects.Infrastructure.Services.Payment.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FreelaDev.MsProjects.Infrastructure;

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
                builder.UseMySql(options?.ConnectionString, new MySqlServerVersion(new Version(8,0,34)));
            }))
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IProjectRepository, ProjectRepository>()
            .AddScoped<IUnitOfWork, EfUnitOfWork>();
        return services;
    }

    public static IServiceCollection AddPayment(this IServiceCollection services)
    {
        services
            .ConfigureOptions<PaymentOptionsSetup>()
            .AddHttpClient<IPaymentService, PaymentService>(((provider, client) =>
            {
                var options = provider.GetService<IOptions<PaymentOptions>>();
                if (options is null) return;
                client.BaseAddress = new Uri(options.Value.BaseUrl);
            }));
        return services;
    }

    public static IServiceCollection AddJwt(this IServiceCollection services)
    {
        services
            .ConfigureOptions<JwtOptionsSetup>()
            .ConfigureOptions<JwtBearerOptionsSetup>()
            .AddScoped<IJwtProvider, JwtProvider>();
        return services;
    }

    public static IServiceProvider ApplyMigrations(this IServiceProvider provider)
    {
        var dbContext = provider.GetRequiredService<EfDbContext>();
        dbContext.Database.Migrate();
        return provider;
    }
}