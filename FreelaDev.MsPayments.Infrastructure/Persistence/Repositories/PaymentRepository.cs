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
    public void Save(Payment payment)
    {
        _dbContext.Payments.Add(payment);
        _dbContext.SaveChanges();
    }

    /// <inheritdoc/>>
    public async Task<List<Payment>> GetAll()
    {
        return await _dbContext.Payments.ToListAsync();
    }
}