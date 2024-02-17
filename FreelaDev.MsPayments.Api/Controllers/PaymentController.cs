using FreelaDev.MsPayments.Application.Commands.Payments.Proccess;
using FreelaDev.MsPayments.Application.Queries.Payments.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FreelaDev.MsPayments.Api.Controllers;

/// <summary>
/// Represents the payment request handler.
/// </summary>
[ApiController]
[Route("/api/payments")]
public class PaymentController : ControllerBase
{
    readonly IMediator _mediator;

    public PaymentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Endpoint to proccess a new payment.
    /// </summary>
    /// <param name="proccessPaymentCommand"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProccessPaymentCommand proccessPaymentCommand)
    {
        Console.WriteLine(proccessPaymentCommand);
        await _mediator.Send(proccessPaymentCommand);
        return Created();
    }

    /// <summary>
    /// Endpoint to proccess a new payment.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var getAllPaymentsQuery = new GetAllPaymentsQuery();
        var payments = await _mediator.Send(getAllPaymentsQuery);
        return Ok(payments);
    }
}