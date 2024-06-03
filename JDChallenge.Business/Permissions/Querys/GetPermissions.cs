using JDChallenge.Domain.Entities;
using MediatR;

namespace JDChallenge.Business.Permissions.Querys;

public class GetPermissions : IRequest<IEnumerable<Permission>>
{
}
