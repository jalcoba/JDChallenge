using JDChallenge.DataAccess.Interfaces;
using JDChallenge.Domain.Entities;

namespace JDChallenge.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IPermissionRepository _permission;
    private readonly IPermissionTypeRepository _permissionType;

    public UnitOfWork(ApplicationDbContext context,
        IEmployeeRepository employeeRepository,
        IPermissionRepository permissionRepository,
        IPermissionTypeRepository permissionTypeRepository)
    {
        _context = context;
        _employeeRepository = employeeRepository;
        _permission = permissionRepository;
        _permissionType = permissionTypeRepository;
    }

    public IEmployeeRepository EmployeeRepository => _employeeRepository;
    public IPermissionRepository PermissionRepository => _permission;
    public IPermissionTypeRepository PermissionTypeRepository => _permissionType;

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}