namespace TicketManagement.Domain.Base;

public class BaseEntity
{
    public Guid Id { get; protected set; }
    public bool IsDeleted { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime UpdatedAt { get; protected set; }
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetUpdateTime()
    {
        UpdatedAt = DateTime.Now;
    }
    public void Activate()
    {
        IsActive = true;
    }
    public void Deactivate()
    {
        IsActive = false;
    }
    public void SetAsDeleted()
    {
        IsDeleted = true;
    }
    public void Restore()
    {
        IsDeleted = false;
    }
}
