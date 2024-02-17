using FreelaDev.MsPayments.Core.Entities;
using FreelaDev.MsPayments.Core.Repositories;
using MediatR;

namespace FreelaDev.MsPayments.Application.Commands.Payments.Proccess;

/// <summary>
/// Represents the <see cref="ProccessPaymentCommand"/> handler.
/// </summary>
public class ProccessPaymentCommandHandler : IRequestHandler<ProccessPaymentCommand>
{
    readonly IPaymentRepository _paymentRepository;

    public ProccessPaymentCommandHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public Task Handle(ProccessPaymentCommand request, CancellationToken cancellationToken)
    {
        // saves the payment request
        var payment = new Payment(request.FullName, request.Amount);
        _paymentRepository.Save(payment);
        // calls the gateway
        // ..
        return Task.CompletedTask;
    }
}