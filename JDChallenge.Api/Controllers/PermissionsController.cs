using JDChallenge.Business.Permissions.Commands;
using JDChallenge.Business.Permissions.Querys;
using JDChallenge.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Swashbuckle.AspNetCore.Annotations;

namespace JDChallenge.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PermissionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PermissionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [SwaggerOperation(summary: "Get all permissions", description: "Allow get all employee permissions")]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(IEnumerable<Permission>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAll()
    {
        Log.Information("Get all permissions");
        return Ok(await _mediator.Send(new GetPermissions()));
    }

    [HttpPost]
    [SwaggerOperation(summary: "Request employee permissions", description: "Allow create an employee permissions")]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Permission))]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreatePermission data)
    {
        Log.Information("Create permission {@data}", data);
        var result = await _mediator.Send(data);
        return Created(string.Empty, result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdatePermission data)
    {
        Log.Information("Update permission {@data}", data);
        var result = await _mediator.Send(data);
        return Ok(result);
    }
}
