using MediatR;
using TicketManagement.Application.Domains.Tickets.DTOs;

namespace TicketManagement.Application.Domains.Tickets.Commands;

public record UpdateTicketCommand(Guid Id, UpdateTicketRequestDto Ticket) : IRequest<TicketResponseDto>;
