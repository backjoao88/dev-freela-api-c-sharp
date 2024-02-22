using System.Text;
using System.Text.Json;
using FreelaDev.MsPayments.Application.Services.MessageBroker;
using FreelaDev.MsPayments.Core.Entities;
using FreelaDev.MsPayments.Core.Repositories;
using Microsoft.Extensions.Hosting;

namespace FreelaDev.MsPayments.Infrastructure.Consumers;

/// <summary>
/// Represents a consumer that processes payment messages.
/// </summary>
public class PaymentConsumer : BackgroundService
{
    public const string QueueName = "Payments";
    readonly IPaymentRepository _paymentRepository;
    readonly IMessageBroker _broker;

    public PaymentConsumer(IMessageBroker broker, IPaymentRepository paymentRepository)
    {
        _broker = broker;
        _paymentRepository = paymentRepository;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("CONSUMING MESSAGE...");
        _broker.Consume(QueueName, (body) =>
        {
            var paymentRequestString = Encoding.UTF8.GetString(body);
            Console.WriteLine(paymentRequestString);
            var paymentRequest = JsonSerializer.Deserialize<PaymentRequest>(paymentRequestString);
            if (paymentRequest is null) return;
            _paymentRepository.Save(new Payment(paymentRequest.FullName, paymentRequest.Amount));
        });
        return Task.CompletedTask;
    }
}