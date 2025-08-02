using TicketManagement.Domain.Domains.Users;
using TicketManagement.Infrastructure.Base;

namespace TicketManagement.Infrastructure.Domains.Users;

public class UserWriteRepository(TicketManagementDbContext context) 
             : BaseWriteRepository<User>(context), IUserWriteRepository
{
}

