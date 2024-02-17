using FreelaDev.MsPayments.Core.Repositories;
using FreelaDev.MsPayments.Infrastructure.Persistence;
using FreelaDev.MsPayments.Infrastructure.Persistence.Configurations;
using FreelaDev.MsPayments.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FreelaDev.MsPayments.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .ConfigureOptions<EfDbContextOptionsSetup>()
            .AddDbContext<EfDbContext>((provider, builder) =>
            {
                var options = provider.GetService<IOptions<EfDbContextOptions>>()!.Value;
                builder.UseMySql(options?.ConnectionString, new MySqlServerVersion(new Version(8, 0, 34)));
            })
            .AddScoped<IPaymentRepository, PaymentRepository>();
        return services;
    }
    
    public static IServiceProvider ApplyMigrations(this IServiceProvider provider)
    {
        var dbContext = provider.GetRequiredService<EfDbContext>();
        dbContext.Database.Migrate();
        return provider;
    }
}