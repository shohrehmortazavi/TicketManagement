using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TicketManagement.Application.Domains.Tickets.DTOs;
using TicketManagement.Application.Domains.Tickets.Queries;
using TicketManagement.Domain.Domains.Tickets;

namespace TicketManagement.Application.Domains.Tickets.Handlers;
public class GetTicketsQueryHandler(ITicketReadRepository repository, IMapper mapper)
             : IRequestHandler<GetTicketsQuery, List<TicketResponseDto>>
{
    private readonly ITicketReadRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<TicketResponseDto>> Handle(GetTicketsQuery request, CancellationToken cancellationToken)
    {
        var tickets = await _repository.GetAll().ToListAsync(cancellationToken);
        return _mapper.Map<List<TicketResponseDto>>(tickets);
    }
}

