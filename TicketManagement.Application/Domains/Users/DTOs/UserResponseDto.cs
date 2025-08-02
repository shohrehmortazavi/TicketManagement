using TicketManagement.Domain.Enums;

namespace TicketManagement.Application.Domains.Users.DTOs
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public UserRoleEnum Role { get; set; }
    }
}