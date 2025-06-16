using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TuApp.Application.Features.UserRoles.Commands.Create;
using TuApp.Application.Features.UserRoles.Commands.Delete;
using TuApp.Application.Features.UserRoles.Commands.Update;
using TuApp.Application.Features.UserRoles.Dtos;
using TuApp.Application.Features.UserRoles.Queries.GetAll;
using TuApp.Application.Features.UserRoles.Queries.GetById;

namespace TuApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserRolesController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserRolesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateUserRoleCommand command)
    {
        var userId = await _mediator.Send(command);
        return Ok(userId);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserRoleDto>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllUserRolesQuery());
        return Ok(result);
    }

    [HttpGet("{userId}/{roleId}")]
    public async Task<ActionResult<UserRoleDto>> GetById(int userId, int roleId)
    {
        var result = await _mediator.Send(new GetUserRoleByIdQuery 
        { 
            UserId = userId, 
            RoleId = roleId 
        });
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateUserRoleCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{userId}/{roleId}")]
    public async Task<ActionResult> Delete(int userId, int roleId)
    {
        await _mediator.Send(new DeleteUserRoleCommand 
        { 
            UserId = userId, 
            RoleId = roleId 
        });
        return NoContent();
    }
}