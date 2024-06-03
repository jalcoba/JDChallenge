using JDChallenge.Business.Employees.Commands;
using JDChallenge.Business.Employees.Querys;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace JDChallenge.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        Log.Information("Get all employees");
        return Ok(await _mediator.Send(new GetEmployees()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        Log.Information("Get employee {@id}", id);
        return Ok(await _mediator.Send(new GetEmployeeById(id)));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployee data)
    {
        Log.Information("Create employee {@data}", data);
        var result = await _mediator.Send(data);
        return Created(string.Empty, result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateEmployee data)
    {
        Log.Information("Update employee {@data}", data);
        var result = await _mediator.Send(data);
        return Ok(result);
    }

}
