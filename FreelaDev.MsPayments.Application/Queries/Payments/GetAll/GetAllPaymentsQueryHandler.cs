using FreelaDev.MsPayments.Application.ViewModel;
using FreelaDev.MsPayments.Core.Repositories;
using MediatR;

namespace FreelaDev.MsPayments.Application.Queries.Payments.GetAll;

/// <summary>
/// Represents the <see cref="GetAllPaymentsQuery"/> handler.
/// </summary>
public class GetAllPaymentsQueryHandler : IRequestHandler<GetAllPaymentsQuery, List<PaymentViewModel>>
{

    readonly IPaymentRepository _paymentRepository;

    public GetAllPaymentsQueryHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<List<PaymentViewModel>> Handle(GetAllPaymentsQuery request, CancellationToken cancellationToken)
    {
        var payments = await _paymentRepository.GetAll();
        var paymentsViewModel = payments
            .Select(o => new PaymentViewModel(o.FullName, o.Amount))
            .ToList();
        return paymentsViewModel;
    }
}