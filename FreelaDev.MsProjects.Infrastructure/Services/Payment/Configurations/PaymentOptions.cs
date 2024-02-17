namespace FreelaDev.MsProjects.Infrastructure.Services.Payment.Configurations;

/// <summary>
/// Represents a set of configurations to payment service.
/// </summary>
public class PaymentOptions
{
    public string BaseUrl { get; set; } = string.Empty;
    public string Resource { get; set; } = string.Empty;
}