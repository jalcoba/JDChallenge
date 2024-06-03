using JDChallenge.Domain.Entities;
using MediatR;

namespace JDChallenge.Business.Employees.Querys;

public class GetEmployees : IRequest<IEnumerable<Employee>>
{
}
