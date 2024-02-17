using FreelaDev.MsPayments.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreelaDev.MsPayments.Infrastructure.Persistence.Configurations.Entities;

/// <summary>
/// Represents the payment configuration.
/// </summary>
public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("tbl_Payment");
        builder.HasKey(o => o.Id);
    }
}