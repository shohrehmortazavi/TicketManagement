using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using TicketManagement.Application.Domains.Tickets.Commands;
using TicketManagement.Application.Domains.Tickets.DTOs;
using TicketManagement.Application.Domains.Tickets.Queries;
using TicketManagement.Domain.Enums;


namespace TicketManagement.API.Controllers;

[Route("[controller]")]
[ApiController]
public class TicketsController(IMediator mediator, IHttpContextAccessor contextAccessor) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    private readonly IHttpContextAccessor _contextAccessor= contextAccessor;

    [Authorize(Roles = "Employee")]
    [HttpPost]
    public async Task<IActionResult> Post(CreateTicketRequestDto request)
    {
        
        var result = await _mediator.Send(new CreateTicketCommand(request));
        return Ok(result);
    }
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetTicketsQuery());
        return Ok(result);
    }

    [HttpGet("/tickets/my")]
    public async Task<IActionResult> GetUserTickets()
    {
        var userId = _contextAccessor.HttpContext?.Items["UserId"].ToString();

        var result = await _mediator.Send(new GetTicketsByUserIdQuery(Guid.Parse( userId)));
        return Ok(result);
    }
  
    [Authorize(Roles = "Admin")]
    [HttpGet("/tickets/stat")]
    public async Task<IActionResult> Get([FromQuery]GetTicketsCountRequestDto request)
    {
        var result = await _mediator.Send(new GetTicketsCountByStatusQuery(request));
        return Ok(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("/tickets/{Id}")]
    public async Task<IActionResult> Put(Guid Id,UpdateTicketRequestDto request)
    {
        var result = await _mediator.Send(new UpdateTicketCommand(Id,request));
        return Ok(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteTicketCommand(id));
        return Ok(result);
    }
}
