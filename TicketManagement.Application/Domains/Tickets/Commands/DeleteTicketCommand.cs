using MediatR;

namespace TicketManagement.Application.Domains.Tickets.Commands;

public record DeleteTicketCommand(Guid Id) : IRequest<bool>;
