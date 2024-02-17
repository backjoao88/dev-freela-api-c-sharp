namespace FreelaDev.MsPayments.Application.ViewModel;

/// <summary>
/// Represents a payment response view model.
/// </summary>
public class PaymentViewModel
{
    public PaymentViewModel(string fullName, decimal amount)
    {
        FullName = fullName;
        Amount = amount;
    }
    public string FullName { get; set; }
    public decimal Amount { get; set; }
}