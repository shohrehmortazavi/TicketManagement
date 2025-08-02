using TicketManagement.Domain.Domains.Tickets;
using TicketManagement.Infrastructure.Base;

namespace TicketManagement.Infrastructure.Domains.Tickets;

public class TicketReadRepository(TicketManagementDbContext context) :
             BaseReadRepository<Ticket>(context), ITicketReadRepository
{
}

