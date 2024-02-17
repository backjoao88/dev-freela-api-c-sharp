using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace FreelaDev.MsProjects.Infrastructure.Services.Payment.Configurations;

/// <summary>
/// Sets up a <see cref="PaymentOptions"/>
/// </summary>
public class PaymentOptionsSetup : IConfigureOptions<PaymentOptions>
{
    const string ServiceBaseUrlSectionName = "Payment";
    readonly IConfiguration _configuration;

    public PaymentOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(PaymentOptions options)
    {
        _configuration
            .GetSection(ServiceBaseUrlSectionName)
            .Bind(options);
    }
}