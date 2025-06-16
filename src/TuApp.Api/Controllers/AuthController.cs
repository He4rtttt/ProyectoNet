using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TuApp.Application.Auth.Commands.Login;
using TuApp.Application.Features.Dtos;
using TuApp.Application.Users.Commands;

namespace TuApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IMediator mediator) : ControllerBase
{

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult<AuthResponseDto>> Login([FromBody] LoginCommand command)
    {
        return await mediator.Send(command);
    }
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterCommand resquest)
    {
        await mediator.Send(resquest);
        return Ok();
    }
}