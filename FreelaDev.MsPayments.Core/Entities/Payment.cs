using FreelaDev.MsPayments.Core.Primitives;

namespace FreelaDev.MsPayments.Core.Entities;

/// <summary>
/// Represents the payment entity.
/// </summary>
public class Payment : Entity
{
    public Payment()
    {
    }
    public Payment(string fullName, decimal amount)
    {
        FullName = fullName;
        Amount = amount;
    }
    public string FullName { get; private set; } = null!;
    public decimal Amount { get; private set; }
}