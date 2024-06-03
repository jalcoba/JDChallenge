using AutoMapper;
using JDChallenge.Business.Employees.Commands;
using JDChallenge.Business.Employees.Querys;
using JDChallenge.Domain.Entities;
using JDChallenge.Services.Interfaces;
using MediatR;

namespace JDChallenge.Business.Employees;

public class EmployeeHandler :
    IRequestHandler<GetEmployees, IEnumerable<Employee>>,
    IRequestHandler<GetEmployeeById, Employee?>,
    IRequestHandler<CreateEmployee, Employee>, 
    IRequestHandler<UpdateEmployee, Employee>

{
    private readonly IMapper _mapper;
    private readonly IEmployeesService _service;

    public EmployeeHandler(IMapper mapper, IEmployeesService service)
    {
        _mapper = mapper;
        _service = service;
    }

    public async Task<IEnumerable<Employee>> Handle(GetEmployees request, CancellationToken cancellationToken)
    {
        return await _service.Get();
    }

    public async Task<Employee?> Handle(GetEmployeeById request, CancellationToken cancellationToken)
    {
        return await _service.Get(request.Id);
    }

    public async Task<Employee> Handle(CreateEmployee request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<Employee>(request);
        return await _service.Update(data);
    }

    public async Task<Employee> Handle(UpdateEmployee request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<Employee>(request);
        return await _service.Update(data);
    }
}

