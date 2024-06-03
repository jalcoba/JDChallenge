using JDChallenge.Api.Controllers;
using JDChallenge.Business.Permissions.Commands;
using JDChallenge.Business.Permissions.Querys;
using JDChallenge.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace JDChallenge.Tests;

public class UnitTest
{
    private Mock<IMediator> _mediator;
    private PermissionsController _permissionController;

    [SetUp]
    public void Setup()
    {
        _mediator = new Mock<IMediator>();
        _permissionController = new PermissionsController(_mediator.Object);
    }

    [Test]
    public async Task GetPermissions()
    {
        var data = new List<Permission>
            {
                new() {
                    EmployeeId = 1,
                    PermissionTypeId = 1,
                    ValidFrom = DateTime.UtcNow,
                },
            };

        _mediator.Setup(m => m.Send(It.IsAny<GetPermissions>(), default)).ReturnsAsync(data);
        var result = await _permissionController.GetAll();
        Assert.That(result, Is.Not.Null);
        var dataResult = ((OkObjectResult)result).Value as IEnumerable<Permission>;
        CollectionAssert.AreEqual(data, dataResult);
    }

    [Test]
    public async Task RequestPermission()
    {
        var data = new CreatePermission() { EmployeeId = 1, PermissionTypeId = 1 };
        _mediator.Setup(m => m.Send(It.IsAny<CreatePermission>(), default));
        var result = await _permissionController.Create(data);
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf<CreatedResult>());
    }

    [Test]
    public async Task ModifyPermission()
    {
        var data = new UpdatePermission() { Id = 1, EmployeeId = 1, PermissionTypeId = 1 };
        _mediator.Setup(m => m.Send(It.IsAny<UpdatePermission>(), default));
        var result = await _permissionController.Update(data);
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf<OkObjectResult>());
    }
}