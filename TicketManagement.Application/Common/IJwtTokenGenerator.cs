using TicketManagement.Domain.Domains.Users;

namespace TicketManagement.Application.Common;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}