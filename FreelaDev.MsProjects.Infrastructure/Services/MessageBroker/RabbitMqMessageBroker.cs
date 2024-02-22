using FreelaDev.MsProjects.Application.Services.MessageBroker;
using FreelaDev.MsProjects.Infrastructure.Services.MessageBroker.Configurations;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace FreelaDev.MsProjects.Infrastructure.Services.MessageBroker;

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
    }

    /// <summary>
    /// Publish a message into a queue.
    /// </summary>
    /// <param name="queueName"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public Task Publish(string queueName, byte[] message)
    {
        using(var connection = _connectionFactory.CreateConnection())
        {
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue: queueName, exclusive: false);
            channel.BasicPublish(exchange:"", routingKey:queueName, body:message);
        }
        return Task.CompletedTask;
    }
}