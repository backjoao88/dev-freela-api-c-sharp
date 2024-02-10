using FreelaDev.MsAuth.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreelaDev.MsAuth.Infrastructure.Persistence.Configurations;

/// <summary>
/// Represents a SQL Server <see cref="User"/> configuration
/// </summary>
public class UserConfiguration : BaseConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_User");
        builder.Property(o => o.Email).IsRequired().HasMaxLength(100);
        builder.Property(o => o.PasswordHash).IsRequired().HasMaxLength(100);
    }
}