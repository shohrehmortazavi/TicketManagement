using TicketManagement.Application.Domains.Tickets.DTOs;
using MediatR;


namespace TicketManagement.Application.Domains.Tickets.Queries;
public record GetTicketsQuery : IRequest<List<TicketResponseDto>>;