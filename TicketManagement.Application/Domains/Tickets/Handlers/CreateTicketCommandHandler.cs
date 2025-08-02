using AutoMapper;
using MediatR;
using TicketManagement.Application.Common;
using TicketManagement.Application.Domains.Tickets.Commands;
using TicketManagement.Application.Domains.Tickets.DTOs;
using TicketManagement.Domain.Domains.Tickets;
using TicketManagement.Domain.Enums;

namespace TicketManagement.Application.Domains.Tickets.Handlers;

public class CreateTicketCommandHandler(ITicketWriteRepository tickettWriteRepository, ICurrentUserService currentUser,
                                        IMapper mapper) : IRequestHandler<CreateTicketCommand, TicketResponseDto>
{
    private readonly ITicketWriteRepository _tickettWriteRepository = tickettWriteRepository;
    private readonly ICurrentUserService _currentUser = currentUser;
    private readonly IMapper _mapper = mapper;

    public async Task<TicketResponseDto> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var newTicket = _mapper.Map<Ticket>(request.Ticket);
        newTicket.SetStatus(TicketStatusEnum.Open);
        newTicket.SetPriority(TicketPriorityEnum.Low);
        newTicket.SetCreatedByUserId(Guid.Parse(_currentUser.UserId));
     
        var result = await _tickettWriteRepository.AddAsync(newTicket);
        await _tickettWriteRepository.SaveChangesAsync();
        return _mapper.Map<TicketResponseDto>(result);
    }
}
