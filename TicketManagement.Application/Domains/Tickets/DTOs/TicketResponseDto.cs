using TicketManagement.Domain.Enums;

namespace TicketManagement.Application.Domains.Tickets.DTOs;

public class TicketResponseDto
{
    public Guid Id { get; set; }
    public string Title { get;  set; } 
    public string Description { get;  set; }
    public TicketStatusEnum Status { get;  set; }
    public TicketPriorityEnum Priority { get;  set; }
    public Guid CreatedByUserId { get;  set; }
    public Guid? AssignedToUserId { get;  set; }
    public bool IsDeleted { get; set; }

}
