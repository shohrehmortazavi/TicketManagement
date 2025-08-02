using TicketManagement.Domain.Enums;

namespace TicketManagement.Application.Domains.Users.DTOs
{
    public class UserRequestDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRoleEnum Role { get; set; }
    }
}