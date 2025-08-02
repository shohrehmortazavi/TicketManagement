using TicketManagement.Domain.Enums;

namespace TicketManagement.Application.Domains.Tickets.DTOs;

public class UpdateTicketRequestDto
{
    public TicketStatusEnum Status { get;  set; } 
    public TicketPriorityEnum Priority { get;  set; } 
    public Guid? AssignedToUserId { get;  set; } 
}
