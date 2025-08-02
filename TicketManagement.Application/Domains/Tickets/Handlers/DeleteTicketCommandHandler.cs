using AutoMapper;
using MediatR;
using TicketManagement.Application.Domains.Tickets.Commands;
using TicketManagement.Application.Domains.Tickets.DTOs;
using TicketManagement.Application.Domains.Tickets.Queries;
using TicketManagement.Domain.Domains.Tickets;

namespace TicketManagement.Application.Domains.Tickets.Handlers;

public class DeleteTicketCommandHandler(ITicketReadRepository ticketReadRepository,
                                        ITicketWriteRepository tickettWriteRepository,
                                        IMapper mapper)
             : IRequestHandler<DeleteTicketCommand, bool>
{
    private readonly ITicketReadRepository _ticketReadRepository = ticketReadRepository;
    private readonly ITicketWriteRepository _tickettWriteRepository = tickettWriteRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<bool> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await _ticketReadRepository.GetByIdAsync(request.Id);

        if (ticket == null)
            throw new Exception("Ticket not found");

        _tickettWriteRepository.SoftDelete(ticket);
        await _tickettWriteRepository.SaveChangesAsync();
        return true;
    }
}
