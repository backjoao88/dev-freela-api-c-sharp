using FreelaDev.MsProjects.Application.Commands.Projects.Start;
using FreelaDev.MsProjects.Application.Services.Payment;
using FreelaDev.MsProjects.Core.Abstractions;
using FreelaDev.MsProjects.Core.Primitives;
using FreelaDev.MsProjects.Core.Primitives.Result;
using MediatR;

namespace FreelaDev.MsProjects.Application.Commands.Projects.Finish;

public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, Result>
{
    readonly IUnitOfWork _unitOfWork;
    readonly IPaymentService _paymentService;

    public FinishProjectCommandHandler(IUnitOfWork unitOfWork, IPaymentService paymentService)
    {
        _unitOfWork = unitOfWork;
        _paymentService = paymentService;
    }

    public async Task<Result> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _unitOfWork.ProjectRepository.GetByIdAsync(request.IdProject);
        if (project is null)
        {
            return Result.Fail(DomainErrors.Project.ProjectNotFound);
        }
        var finishResult = project.Finish();
        if (finishResult.IsFailure)
        {
            return finishResult;
        }
        await _unitOfWork.CompleteAsync();
        // proccess payment
        var paymentRequest = new PaymentRequest
        {
            IdProject = project.Id,
            CreditCardNumber = "123",
            Cvv = "20",
            ExpiresAt = "1132 days",
            FullName = project.Client.FirstName+" "+project.Client.LastName,
            Amount = project.TotalCost
        };
        await _paymentService.Proccess(paymentRequest);
        return Result.Ok();
    }
}