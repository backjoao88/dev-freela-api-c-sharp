using FreelaDev.MsProjects.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreelaDev.MsProjects.Infrastructure.Persistence.Configurations.Entities;

/// <summary>
/// Represents a SQL Server <see cref="User"/> configuration
/// </summary>
public class UserConfiguration : BaseConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_User");
        builder.OwnsMany(o => o.Skills, config =>
        {
            config.ToTable("tbl_Skills");
            config.Property(o => o.Description).HasMaxLength(250);
        });
        builder.Property(o => o.Email).IsRequired().HasMaxLength(1000);
        builder.Property(o => o.PasswordHash).HasColumnType("LONGTEXT");
    }
}