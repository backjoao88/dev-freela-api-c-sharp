using FreelaDev.MsPayments.Application.Services.MessageBroker;
using FreelaDev.MsPayments.Infrastructure.Services.MessageBroker.Configurations;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace FreelaDev.MsPayments.Infrastructure.Services.MessageBroker;

/// <summary>
/// Configures a RabbitMQ message broker instance.
/// </summary>
public class RabbitMqMessageBroker : IMessageBroker
{
    readonly ConnectionFactory _connectionFactory;

    public RabbitMqMessageBroker(IOptions<MessageBrokerOptions> messageBrokerOptions)
    {
        _connectionFactory = new ConnectionFactory();
        _connectionFactory.HostName = messageBrokerOptions.Value.Hostname;
        Console.WriteLine(_connectionFactory.HostName);
    }

    /// <summary>
    /// Publish a message into a queue.
    /// </summary>
    /// <param name="queueName"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public Task Publish(string queueName, byte[] message)
    {
        using (var connection = _connectionFactory.CreateConnection())
        {
            var channel = connection.CreateModel();
            channel.QueueDeclare(queueName, exclusive: false);
            channel.BasicPublish("", queueName, body: message);
        }
        return Task.CompletedTask;
    }

    /// <summary>
    /// Consumes a message from a specific queue.
    /// </summary>
    /// <param name="queueName"></param>
    /// <param name="cb"></param>
    /// <returns></returns>
    public Task Consume(string queueName, Action<byte[]> cb)
    {
        var connection = _connectionFactory.CreateConnection();
        var channel = connection.CreateModel();
        channel.QueueDeclare(queueName, exclusive: false);
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (sender, args) =>
        {
            Console.WriteLine($"Received packet {args.Body.Length}");
            var bytesReceived = args.Body.ToArray();
            cb(bytesReceived);
        };
        channel.BasicConsume(queue: queueName, autoAck:true,consumer: consumer);
        return Task.CompletedTask;
    }
}