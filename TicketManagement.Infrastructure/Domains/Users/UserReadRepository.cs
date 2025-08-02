using TicketManagement.Domain.Domains.Users;
using TicketManagement.Infrastructure.Base;

namespace TicketManagement.Infrastructure.Domains.Users;

public class UserReadRepository(TicketManagementDbContext context)
             : BaseReadRepository<User>(context), IUserReadRepository
{
}

