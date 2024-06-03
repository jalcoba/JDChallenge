using JDChallenge.Domain.Entities;
using MediatR;

namespace JDChallenge.Business.Employees.Querys;

public class GetEmployeeById(long id) : IRequest<Employee>
{
    public long Id { get; private set; } = id;
}
