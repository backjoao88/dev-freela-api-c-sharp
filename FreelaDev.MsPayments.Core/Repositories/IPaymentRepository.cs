using FreelaDev.MsPayments.Core.Entities;

namespace FreelaDev.MsPayments.Core.Repositories;

/// <summary>
/// Represents a contract to a payment repository.
/// </summary>
public interface IPaymentRepository
{
    /// <summary>
    /// Saves a new payment.
    /// </summary>
    /// <param name="payment"></param>
    public void Save(Payment payment);

    /// <summary>
    /// Retrieve all payments.
    /// </summary>
    /// <returns></returns>
    public Task<List<Payment>> GetAll();
}