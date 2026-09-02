using Application.Dtos;
using Application.Features.Questions.Commands;
using Application.Features.Questions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionsController : ControllerBase
{
    private readonly ISender _sender;

    public QuestionsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<List<QuestionDto>>> GetQuestions([FromQuery] string lang = "th")
    {
        var result = await _sender.Send(new GetQuestionsQuery(lang));
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateQuestion([FromBody] CreateQuestionCommand command)
    {
        var id = await _sender.Send(command);
        return CreatedAtAction(nameof(GetQuestions), new { id }, id);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteQuestion(Guid id)
    {
        var success = await _sender.Send(new DeleteQuestionCommand(id));
        return success ? NoContent() : NotFound();
    }
}