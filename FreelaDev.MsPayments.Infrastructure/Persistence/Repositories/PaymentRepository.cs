using FreelaDev.MsPayments.Core.Entities;
using FreelaDev.MsPayments.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FreelaDev.MsPayments.Infrastructure.Persistence.Repositories;

/// <inheritdoc/>>
public class PaymentRepository : IPaymentRepository
{
    readonly EfDbContext _dbContext;

    public PaymentRepository(EfDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc/>>
    public async Task Save(Payment payment)
    {
        await _dbContext.Payments.AddAsync(payment);
        await _dbContext.SaveChangesAsync();
    }

    /// <inheritdoc/>>
    public async Task<List<Payment>> GetAll()
    {
        return await _dbContext.Payments.ToListAsync();
    }
}