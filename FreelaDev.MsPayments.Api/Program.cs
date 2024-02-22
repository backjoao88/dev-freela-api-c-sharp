using FreelaDev.MsPayments.Application;
using FreelaDev.MsPayments.Infrastructure;

namespace FreelaDev.MsPayments.Api;

/// <summary>
/// MsPayments entrypoint
/// </summary>
public abstract class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddBroker();
        builder.Services.AddBackgroundServices();
        builder.Services.AddApplication();
        builder.Services.AddInfrastructure();
        var app = builder.Build();
        app.MapControllers();
        app.Services.ApplyMigrations();
        app.Run();
    }
}