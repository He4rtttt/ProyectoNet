using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TuApp.Application.Features.User.Commands.DeleteUser;
using TuApp.Application.Features.User.Commands.UpdateUser;
using TuApp.Application.Features.User.Dtos;
using TuApp.Application.Features.User.Queries.GetAll;
using TuApp.Application.Features.User.Queries.GetUserById;
using TuApp.Application.Interfaces;
using TuApp.Domain.Entities;

namespace TuApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController( IMediator _mediator) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllUserQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery
            {
                UserId = id
            });
            return Ok(result);
        }
        

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateUserCommand command)
        {
            if (id != command.UserId) return BadRequest();
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteUserCommand { UserId = id });
            return NoContent();
        }
    }

 
}
