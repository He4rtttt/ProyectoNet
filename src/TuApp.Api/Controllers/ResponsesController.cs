using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TuApp.Application.Features.Responses.Commands.Create;
using TuApp.Application.Features.Responses.Commands.Delete;
using TuApp.Application.Features.Responses.Commands.Update;
using TuApp.Application.Features.Responses.Dtos;
using TuApp.Application.Features.Responses.Queries.GetAll;
using TuApp.Application.Features.Responses.Queries.GetById;

namespace TuApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ResponsesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ResponsesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateResponseCommand command)
    {
        var responseId = await _mediator.Send(command);
        return Ok(responseId);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ResponseDto>>> GetAll()
    {
        var responses = await _mediator.Send(new GetAllResponsesQuery());
        return Ok(responses);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ResponseDetailDto>> GetById(int id)
    {
        var response = await _mediator.Send(new GetResponseByIdQuery { ResponseId = id });
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] UpdateResponseCommand command)
    {
        if (id != command.ResponseId) return BadRequest();
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteResponseCommand { ResponseId = id });
        return NoContent();
    }
}