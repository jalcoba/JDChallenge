using JDChallenge.Domain.Entities;
using MediatR;

namespace JDChallenge.Business.PermissionTypes.Commands;

public class UpdatePermissionType : IRequest<PermissionType>
{
    public required string Name { get; set; }
    public required string Description { get; set; }
}
