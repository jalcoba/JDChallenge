using AutoMapper;
using JDChallenge.Business.Employees.Commands;
using JDChallenge.Domain.Entities;

namespace JDChallenge.Business.Mappers;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<CreateEmployee, Employee>();
        CreateMap<UpdateEmployee, Employee>();
    }
}
