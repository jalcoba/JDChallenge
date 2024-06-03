using JDChallenge.Domain.Entities;
using MediatR;

namespace JDChallenge.Business.Permissions.Commands;

public class UpdatePermission : IRequest<Permission>
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public int PermissionTypeId { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidUntil { get; set; }
}
