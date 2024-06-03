using JDChallenge.Domain.Entities;
using MediatR;

namespace JDChallenge.Business.PermissionTypes.Commands;

public class CreatePermissionType : IRequest<PermissionType>
{
    public required string Name { get; set; }
    public required string Description { get; set; }    
}
