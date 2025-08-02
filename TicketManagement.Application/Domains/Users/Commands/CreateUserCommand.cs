using MediatR;
using TicketManagement.Application.Domains.Users.DTOs;

namespace UserManagement.Application.Domains.Users.Commands;

public record CreateUserCommand(UserRequestDto User) : IRequest<UserResponseDto>;
