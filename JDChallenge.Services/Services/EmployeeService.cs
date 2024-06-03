using JDChallenge.Domain.Entities;
using JDChallenge.DataAccess.Interfaces;
using JDChallenge.Services.Interfaces;

namespace JDChallenge.Services.Services;

public class EmployeeService : IEmployeesService
{
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Employee>> Get()
    {
        return await _unitOfWork.EmployeeRepository.GetAll();
    }

    public async Task<Employee?> Get(long id)
    {
        return await _unitOfWork.EmployeeRepository.Get(p => p.Id == id);
    }

    public async Task<Employee> Add(Employee request)
    {
        var data = await _unitOfWork.EmployeeRepository.Add(request);
        await _unitOfWork.Save();
        return data;
    }

    public async Task<Employee> Update(Employee request)
    {
        var data = _unitOfWork.EmployeeRepository.Update(request);
        await _unitOfWork.Save();
        return data;
    }
}
