namespace FreelaDev.MsPayments.Application.Services.MessageBroker;

/// <summary>
/// Represents a contract to implement a message broker.
/// </summary>
public interface IMessageBroker
{
    /// <summary>
    /// Publish a message into the specified queue.
    /// </summary>
    /// <param name="queueName"></param>
    /// <param name="message"></param>
    public Task Publish(string queueName, byte[] message);

    /// <summary>
    /// Trigger an action when a packet is received in the specified queue.
    /// </summary>
    /// <param name="queueName"></param>
    /// <param name="cb"></param>
    public Task Consume(string queueName, Action<byte[]> cb);
}