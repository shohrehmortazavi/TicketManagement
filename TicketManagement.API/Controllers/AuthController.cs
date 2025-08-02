using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketManagement.Application.Domains.Users.DTOs;
using UserManagement.Application.Domains.Users.Commands;


namespace TicketManagement.API.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginUserRequestDto request)
    {
        var result = await _mediator.Send(new LoginUserCommand(request));

        return Ok(result);
    }
}

