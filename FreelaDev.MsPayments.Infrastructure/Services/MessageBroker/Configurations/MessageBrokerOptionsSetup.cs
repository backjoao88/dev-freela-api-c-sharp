using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace FreelaDev.MsPayments.Infrastructure.Services.MessageBroker.Configurations;

/// <summary>
/// Sets up a <see cref="MessageBrokerOptions"/>
/// </summary>
public class MessageBrokerOptionsSetup : IConfigureOptions<MessageBrokerOptions>
{
    public readonly string MessageBrokerConfigurationSectionName = "MessageBroker";
    readonly IConfiguration _configuration;

    public MessageBrokerOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(MessageBrokerOptions options)
    {
        _configuration
            .GetSection(MessageBrokerConfigurationSectionName)
            .Bind(options);
    }
}