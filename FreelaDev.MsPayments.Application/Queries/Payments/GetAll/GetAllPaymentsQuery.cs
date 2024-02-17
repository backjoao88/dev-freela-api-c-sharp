using FreelaDev.MsPayments.Application.ViewModel;
using MediatR;

namespace FreelaDev.MsPayments.Application.Queries.Payments.GetAll;

/// <summary>
/// Represents the get all payments request.
/// </summary>
public class GetAllPaymentsQuery : IRequest<List<PaymentViewModel>>;