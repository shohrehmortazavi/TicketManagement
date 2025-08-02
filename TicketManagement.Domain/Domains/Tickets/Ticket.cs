using TicketManagement.Domain.Base;
using TicketManagement.Domain.Enums;

namespace TicketManagement.Domain.Domains.Tickets;

public class Ticket : BaseEntity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public TicketStatusEnum Status { get; private set; }
    public TicketPriorityEnum Priority { get; private set; }
    public Guid CreatedByUserId { get; private set; }
    public Guid? AssignedToUserId { get; private set; }

    private Ticket()
    {
        
    }
    public Ticket(string title, string description, TicketStatusEnum status,
                        TicketPriorityEnum priority, Guid createdByUserId,
                        Guid? assignedToUserId)
    {
        Title = title;
        Description = description;
        Status = status;
        Priority = priority;
        CreatedByUserId = createdByUserId;
        AssignedToUserId = assignedToUserId;
    }

    public void SetStatus(TicketStatusEnum status)
    {
        Status = status;
    }
    public void SetPriority(TicketPriorityEnum priority)
    {
        Priority = priority;
    }
    public void SetAssignedToUserId(Guid assignedToUserId)
    {
        AssignedToUserId = assignedToUserId;
    }
    public void SetCreatedByUserId(Guid createdByUserId)
    {
        CreatedByUserId = createdByUserId;
    }

}
