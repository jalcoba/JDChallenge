using JDChallenge.Domain.Entities;
using MediatR;

namespace JDChallenge.Business.Employees.Commands;

public class UpdateEmployee : IRequest<Employee>
{
    public required long Id { get; set; }
    public required string Name { get; set; }
    public required string SurName { get; set; }
}
