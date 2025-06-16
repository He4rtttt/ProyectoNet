using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TuApp.Application.Features.Tickets.Commands.Create;
using TuApp.Application.Features.Tickets.Commands.Delete;
using TuApp.Application.Features.Tickets.Commands.Update;
using TuApp.Application.Features.Tickets.Dtos;
using TuApp.Application.Features.Tickets.Queries.GetAll;
using TuApp.Application.Features.Tickets.Queries.GetById;
using TuApp.Application.Interfaces;

namespace TuApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TicketsController : ControllerBase
{
    private readonly IBackgroundJobClient _backgroundJob;
    private readonly IMediator _mediator;

    public TicketsController(IMediator mediator, IBackgroundJobClient backgroundJob)
    {
        _mediator = mediator;
        _backgroundJob = backgroundJob;
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateTicketCommand command)
    {
        var ticketId = await _mediator.Send(command);
        return Ok(ticketId);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TicketDto>>> GetAll()
    {
        var tickets = await _mediator.Send(new GetAllTicketsQuery());
        return Ok(tickets);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TicketDetailDto>> GetById(int id)
    {
        var ticket = await _mediator.Send(new GetTicketByIdQuery { TicketId = id });
        return Ok(ticket);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] UpdateTicketCommand command)
    {
        if (id != command.TicketId) return BadRequest();
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteTicketCommand { TicketId = id });
        return NoContent();
    }
    [HttpPost("{id}/process")]
    public IActionResult ProcessInBackground(int id)
    {
        _backgroundJob.Enqueue<IMyBackgroundService>(x => x.ProcessTicketAsync(id));
        return Accepted(new { 
            Message = "El ticket se está procesando en segundo plano", 
            TicketId = id 
        });
    }

    [HttpPost("cleanup")]
    [Authorize(Roles = "Administrador")]
    public IActionResult CleanupOldTickets()
    {
        _backgroundJob.Enqueue<IMyBackgroundService>(x => x.CleanupOldData());
        return Accepted(new { 
            Message = "La limpieza de tickets antiguos se ha iniciado en segundo plano" 
        });
    }
}