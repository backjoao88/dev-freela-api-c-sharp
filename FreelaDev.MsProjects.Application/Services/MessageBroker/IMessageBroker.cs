namespace FreelaDev.MsProjects.Application.Services.MessageBroker;

/// <summary>
/// Represents a contract to implement a message broker.
/// </summary>
public interface IMessageBroker
{
    /// <summary>
    /// Publish a message into the message broker.
    /// </summary>
    /// <param name="queueName"></param>
    /// <param name="message"></param>
    public Task Publish(string queueName, byte[] message);
}