using TicketManagement.Domain.Base;
using TicketManagement.Domain.Enums;

namespace TicketManagement.Domain.Domains.Users;

public class User : BaseEntity
{
    private User()
    {
        
    }
    public User(string fullName, string email, string passwordHash, UserRoleEnum role)
    {
        FullName = fullName;
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
    }

    public string FullName { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public UserRoleEnum Role { get; private set; }

    public void SetPasswordHash(string passwordHash)
    {
        PasswordHash = passwordHash;
    }
}
