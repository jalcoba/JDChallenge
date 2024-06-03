using JDChallenge.Domain.Entities;
using MediatR;

namespace JDChallenge.Business.PermissionTypes.Querys;

public class GetPermissionTypes : IRequest<IEnumerable<PermissionType>>
{
}
