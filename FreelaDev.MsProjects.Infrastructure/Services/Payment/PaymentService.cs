using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using FreelaDev.MsProjects.Application.Services.Payment;
using FreelaDev.MsProjects.Infrastructure.Services.Payment.Configurations;
using Microsoft.Extensions.Options;

namespace FreelaDev.MsProjects.Infrastructure.Services.Payment;

/// <inheritdoc/>
public class PaymentService : IPaymentService
{
    readonly PaymentOptions _paymentOptions;
    readonly HttpClient _httpClient;

    public PaymentService(HttpClient httpClient, IOptions<PaymentOptions> paymentOptions)
    {
        _httpClient = httpClient;
        _paymentOptions = paymentOptions.Value!;
    }
    
    /// <summary>
    /// Process a payment request.
    /// </summary>
    /// <param name="paymentRequest"></param>
    public async Task Proccess(PaymentRequest paymentRequest)
    {
        var paymentRequestJson = JsonSerializer.Serialize(paymentRequest, new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        var payload = new StringContent(paymentRequestJson, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_paymentOptions.Resource, payload);
        Console.WriteLine("Response from service: " + response.StatusCode);
        Console.WriteLine("Content: " + await response.Content.ReadAsStringAsync());
    }
}