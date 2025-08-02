using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TicketManagement.Application.Domains.Tickets.DTOs;
using TicketManagement.Application.Domains.Tickets.Queries;
using TicketManagement.Domain.Domains.Tickets;

namespace TicketManagement.Application.Domains.Tickets.Handlers;
public class GetTicketByIdQueryHandler(ITicketReadRepository repository, IMapper mapper)
             : IRequestHandler<GetTicketByIdQuery, TicketResponseDto>
{
    private readonly ITicketReadRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<TicketResponseDto> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
    {
        var ticket = await _repository.GetAll()
                    .SingleOrDefaultAsync(x => x.Id == request.TicketId, cancellationToken);
        return _mapper.Map<TicketResponseDto>(ticket);
    }
}

