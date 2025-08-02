using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketManagement.Application.Domains.Users.DTOs;
using UserManagement.Application.Domains.Users.Commands;


namespace TicketManagement.API.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post(UserRequestDto request)
    {
        var result = await _mediator.Send(new CreateUserCommand(request));
        return Ok(result);
    }
}
