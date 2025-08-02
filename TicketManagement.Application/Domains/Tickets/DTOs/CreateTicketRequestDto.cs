using TicketManagement.Domain.Domains.Tickets;

namespace TicketManagement.Application.Domains.Tickets.DTOs;

public class CreateTicketRequestDto
{
    public string Title { get;  set; } 
    public string Description { get;  set; } 
}
