using FreelaDev.MsProjects.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreelaDev.MsProjects.Infrastructure.Persistence.Configurations.Entities;

/// <summary>
/// Represents a SQL Server <see cref="Comment"/> configuration.
/// </summary>
public class CommentConfiguration : BaseConfiguration<Comment>
{
    public override void Configure(EntityTypeBuilder<Comment> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_Comment");
        builder
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(o => o.IdUser)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(o => o.Content).HasMaxLength(500);
    }
}