using MediatR;
using Microsoft.EntityFrameworkCore;
using TicketManagement.Application.Domains.Tickets.Queries;
using TicketManagement.Domain.Domains.Tickets;

namespace TicketManagement.Application.Domains.Tickets.Handlers;
public class GetTicketsCountQueryHandler(ITicketReadRepository repository)
             : IRequestHandler<GetTicketsCountByStatusQuery, int>
{
    private readonly ITicketReadRepository _repository = repository;

    public async Task<int> Handle(GetTicketsCountByStatusQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAll().Where(x => x.Status == request.TicketsCountRequest.Status)
                                         .CountAsync(cancellationToken);
    }
}

