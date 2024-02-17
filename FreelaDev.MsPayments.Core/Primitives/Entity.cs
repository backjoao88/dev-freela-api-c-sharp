namespace FreelaDev.MsPayments.Core.Primitives;

/// <summary>
/// Represents the base entity.
/// </summary>
public class Entity
{
    public Guid Id { get; protected set; } = Guid.Empty;
}