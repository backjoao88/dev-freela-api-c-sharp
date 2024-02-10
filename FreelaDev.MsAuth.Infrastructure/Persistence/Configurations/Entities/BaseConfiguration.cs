using FreelaDev.MsAuth.Core.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreelaDev.MsAuth.Infrastructure.Persistence.Configurations;

/// <summary>
/// Represents a base entity configurations of all child configurations
/// </summary>
public class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(o => o.Id);
    }
}