using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartStatements.Core.Statements.Commands;
using SmartStatements.Core.Statements.Queries;

namespace MonthlyStatements.API.Controllers;

[ApiController]
[Route("api/statements")]
public class StatementsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StatementsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("GenerateStatmentMonthlyForAllCustomers")]
    public async Task<IActionResult> GenerateMonthlyForAllCustomers([FromQuery] DateOnly month)
    {
        var command = new GenerateMonthlyStatementsCommand(month);

        await _mediator.Send(command);

        return Ok("Monthly statements generated and sent to all customers");
    }

    [HttpPost("GenerateStatementWithRealSTMPEmail")]
    public async Task<IActionResult> Generate(GenerateStatementCommand command)
    {
        await _mediator.Send(command);
        return Ok("Statement generated and emailed");
    }

    [HttpGet("GetCustomer")]
    public async Task<IActionResult> Get(
        Guid customerId, int year, DateOnly month)
    {
        var result = await _mediator.Send(
            new GetStatementQuery(customerId, year, month));

        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost("generateStatementWithFakeEmail")]
    public async Task<IActionResult> Generate([FromQuery] DateOnly month)
    {
        await _mediator.Send(new GenerateMonthlyStatementsCommand(month));
        return Ok(new
        {
            Message = "Monthly statements generated and emails sent successfully.",
            Month = month.ToString("MMMM yyyy")
        });
    }
}
