using TicketManagement.Domain.Domains.Tickets;
using TicketManagement.Infrastructure.Base;

namespace TicketManagement.Infrastructure.Domains.Tickets;

public class TicketWriteRepository(TicketManagementDbContext context) :
             BaseWriteRepository<Ticket>(context), ITicketWriteRepository
{
}

