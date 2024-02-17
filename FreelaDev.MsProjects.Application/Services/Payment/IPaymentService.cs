namespace FreelaDev.MsProjects.Application.Services.Payment;

/// <summary>
/// Represents a payment service contract.
/// </summary>
public interface IPaymentService
{
    /// <summary>
    /// Connects to the payment service gateway.
    /// </summary>
    public Task Proccess(PaymentRequest paymentRequest);
}