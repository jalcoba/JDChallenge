using JDChallenge.Business.PermissionTypes.Querys;
using JDChallenge.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Swashbuckle.AspNetCore.Annotations;

namespace JDChallenge.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PermissionTypesController : ControllerBase
{
    private readonly IMediator _mediator;

    public PermissionTypesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [SwaggerOperation(summary: "Get all permissions types", description: "Allow get all permission types")]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(IEnumerable<PermissionType>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAll()
    {
        Log.Information("Get all permission types");
        return Ok(await _mediator.Send(new GetPermissionTypes()));
    }

}
