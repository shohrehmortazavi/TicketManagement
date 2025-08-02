using MediatR;
using TicketManagement.Application.Domains.Tickets.DTOs;


namespace TicketManagement.Application.Domains.Tickets.Queries;
public record GetTicketsCountByStatusQuery(GetTicketsCountRequestDto TicketsCountRequest) : IRequest<int>;