using MediatR;
using TicketManagement.Application.Domains.Users.DTOs;

namespace UserManagement.Application.Domains.Users.Commands;

public record LoginUserCommand(LoginUserRequestDto User) : IRequest<string>;
