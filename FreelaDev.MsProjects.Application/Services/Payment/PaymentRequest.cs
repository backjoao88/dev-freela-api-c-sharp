namespace FreelaDev.MsProjects.Application.Services.Payment;

/// <summary>
/// Represents a payment input model.
/// </summary>
public class PaymentRequest
{
    public Guid IdProject { get; set; } = Guid.Empty;
    public string CreditCardNumber { get; set; } = string.Empty;
    public string Cvv { get; set; } = string.Empty;
    public string ExpiresAt { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public decimal Amount { get; set; } = 0M;
}