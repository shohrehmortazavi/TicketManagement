using Microsoft.EntityFrameworkCore;
using TicketManagement.Domain.Domains.Tickets;
using TicketManagement.Domain.Domains.Users;

namespace TicketManagement.Infrastructure;

public class TicketManagementDbContext(DbContextOptions<TicketManagementDbContext> options) : DbContext(options)
{
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<User> Users { get; set; }
}
