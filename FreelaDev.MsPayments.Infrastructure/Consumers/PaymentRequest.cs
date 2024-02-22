using System.Text.Json.Serialization;

namespace FreelaDev.MsPayments.Infrastructure.Consumers;

/// <summary>
/// Represents a payment request.
/// </summary>
public class PaymentRequest
{
    public PaymentRequest(string fullName, decimal amount)
    {
        FullName = fullName;
        Amount = amount;
    }
    [JsonPropertyName("fullName")]
    public string FullName { get; set; }
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }
}