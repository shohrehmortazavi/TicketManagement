using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TicketManagement.Application.Domains.Tickets.DTOs;
using TicketManagement.Application.Domains.Tickets.Queries;
using TicketManagement.Domain.Domains.Tickets;

namespace TicketManagement.Application.Domains.Tickets.Handlers;
public class GetTicketsByUserIdQueryHandler(ITicketReadRepository repository, IMapper mapper)
             : IRequestHandler<GetTicketsByUserIdQuery, List<TicketResponseDto>>
{
    private readonly ITicketReadRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<TicketResponseDto>> Handle(GetTicketsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var tickets = await _repository.GetAll().Where(x => x.CreatedByUserId == request.UserId)
                                                .ToListAsync(cancellationToken);
        return _mapper.Map<List<TicketResponseDto>>(tickets);
    }
}

