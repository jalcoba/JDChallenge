using JDChallenge.Domain.Entities;
using MediatR;

namespace JDChallenge.Business.Employees.Commands;

public class CreateEmployee : IRequest<Employee>
{
    public required string Name { get; set; }
    public required string SurName { get; set; }
}
