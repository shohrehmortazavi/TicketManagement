using TicketManagement.Domain.Enums;

namespace TicketManagement.Application.Domains.Tickets.DTOs;

public class GetTicketsCountRequestDto
{
    public TicketStatusEnum Status { get;  set; } 
}
