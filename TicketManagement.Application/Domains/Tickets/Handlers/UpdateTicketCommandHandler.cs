using AutoMapper;
using MediatR;
using TicketManagement.Application.Domains.Tickets.Commands;
using TicketManagement.Application.Domains.Tickets.DTOs;
using TicketManagement.Domain.Domains.Tickets;

namespace TicketManagement.Application.Domains.Tickets.Handlers;

public class UpdateTicketCommandHandler(ITicketReadRepository ticketReadRepository,
                                        ITicketWriteRepository ticketWriteRepository,
                                        IMapper mapper)
             : IRequestHandler<UpdateTicketCommand, TicketResponseDto>
{
    private readonly ITicketReadRepository _ticketReadRepository = ticketReadRepository;
    private readonly ITicketWriteRepository _ticketWriteRepository = ticketWriteRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<TicketResponseDto> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket =await _ticketReadRepository.GetByIdAsync(request.Id);

        if (ticket == null)
            throw new Exception("Ticket not found");

        ticket.SetStatus(request.Ticket.Status);
        ticket.SetPriority(request.Ticket.Priority);
        ticket.SetAssignedToUserId((Guid)request.Ticket.AssignedToUserId);
        _ticketWriteRepository.Update(ticket);
       await _ticketWriteRepository.SaveChangesAsync();
        return _mapper.Map<TicketResponseDto>(ticket);
    }
}
