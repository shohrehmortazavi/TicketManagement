using MediatR;
using TicketManagement.Application.Domains.Tickets.DTOs;

namespace TicketManagement.Application.Domains.Tickets.Commands;

public record CreateTicketCommand(CreateTicketRequestDto Ticket) : IRequest<TicketResponseDto>;
