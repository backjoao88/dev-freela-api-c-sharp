using FreelaDev.MsProjects.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreelaDev.MsProjects.Infrastructure.Persistence.Configurations.Entities;

/// <summary>
/// Represents a SQL Server <see cref="Project"/> configuration
/// </summary>
public class ProjectConfiguration : BaseConfiguration<Project>
{
    public override void Configure(EntityTypeBuilder<Project> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_Project");
        builder
            .HasOne<User>(o => o.Client)
            .WithMany()
            .HasForeignKey(o => o.IdClient)
            .OnDelete(DeleteBehavior.Restrict);
        builder
            .HasOne<User>(o => o.Freelancer)
            .WithMany()
            .HasForeignKey(o => o.IdFreelancer)
            .OnDelete(DeleteBehavior.Restrict);
        builder
            .HasMany<Comment>(o => o.Comments)
            .WithOne()
            .HasForeignKey(o => o.IdProject)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(o => o.Description).HasMaxLength(250);
    }
}