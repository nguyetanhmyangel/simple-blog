namespace SimpleBlog.Core.Domain.Contracts;
public abstract class AuditableEntity<TId> : IAuditableEntity<TId>
{
    public TId Id { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? LastUpdatedBy { get; set; }
    public DateTime? LastUpdatedAt { get; set; }
}

public abstract class AuditableEntity : IAuditableEntity
{
    public string? CreatedBy { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? LastUpdatedBy { get; set; }
    public DateTime? LastUpdatedAt { get; set; }
}