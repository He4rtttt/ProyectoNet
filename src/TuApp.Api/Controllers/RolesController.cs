using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TuApp.Application.Features.Roles.Commands.Create;
using TuApp.Application.Features.Roles.Commands.Delete;
using TuApp.Application.Features.Roles.Commands.Update;
using TuApp.Application.Features.Roles.Dtos;
using TuApp.Application.Features.Roles.Queries.GetAll;
using TuApp.Application.Features.Roles.Queries.GetById;

namespace TuApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Administrador")] 
public class RolesController : ControllerBase
{
    private readonly IMediator _mediator;

    public RolesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // POST api/roles
    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateRoleCommand command)
    {
        var roleId = await _mediator.Send(command);
        return Ok(roleId);
    }

    // GET api/roles
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoleDto>>> GetAll()
    {
        var roles = await _mediator.Send(new GetAllRolesQuery());
        return Ok(roles);
    }

    // GET api/roles/5
    [HttpGet("{id}")]
    public async Task<ActionResult<RoleDetailDto>> GetById(int id)
    {
        var role = await _mediator.Send(new GetRoleByIdQuery { RoleId = id });
        return Ok(role);
    }

    // PUT api/roles/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] UpdateRoleCommand command)
    {
        if (id != command.RoleId) return BadRequest();
        await _mediator.Send(command);
        return NoContent();
    }

    // DELETE api/roles/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteRoleCommand { RoleId = id });
        return NoContent();
    }
}