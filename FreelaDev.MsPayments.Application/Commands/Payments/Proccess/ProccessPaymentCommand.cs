using MediatR;

namespace FreelaDev.MsPayments.Application.Commands.Payments.Proccess;

/// <summary>
/// Represents a command to init the payment gateway proccess.
/// </summary>
public class ProccessPaymentCommand : IRequest
{
    public ProccessPaymentCommand(Guid idProject, string creditCardNumber, string cvv, string expiresAt, string fullName, decimal amount)
    {
        IdProject = idProject;
        CreditCardNumber = creditCardNumber;
        Cvv = cvv;
        ExpiresAt = expiresAt;
        FullName = fullName;
        Amount = amount;
    }
    public Guid IdProject { get; set; }
    public string CreditCardNumber { get; set; } 
    public string Cvv { get; set; }
    public string ExpiresAt { get; set; } 
    public string FullName { get; set; }
    public decimal Amount { get; set; } 
}