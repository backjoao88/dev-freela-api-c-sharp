using System.Text.Json;
using FreelaDev.MsProjects.Application.Services.MessageBroker;
using FreelaDev.MsProjects.Application.Services.Payment;
using FreelaDev.MsProjects.Infrastructure.Services.Payment.Configurations;
using Microsoft.Extensions.Options;

namespace FreelaDev.MsProjects.Infrastructure.Services.Payment;

/// <inheritdoc/>
public class PaymentService : IPaymentService
{
    readonly IMessageBroker _messageBroker;
    readonly PaymentOptions _paymentOptions;

    public PaymentService(IOptions<PaymentOptions> paymentOptions, IMessageBroker messageBroker)
    {
        _messageBroker = messageBroker;
        _paymentOptions = paymentOptions.Value!;
    }
    
    /// <summary>
    /// Process a payment request.
    /// </summary>
    /// <param name="paymentRequest"></param>
    public async Task Proccess(PaymentRequest paymentRequest)
    {
        var memoryStream = new MemoryStream();
        await JsonSerializer.SerializeAsync(memoryStream, paymentRequest, new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        await _messageBroker.Publish(_paymentOptions.QueueName, memoryStream.ToArray());
    }
}