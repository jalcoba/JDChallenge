namespace JDChallenge.DataAccess.Interfaces;

public interface IUnitOfWork
{
    IEmployeeRepository EmployeeRepository { get; }
    IPermissionRepository PermissionRepository { get; }
    IPermissionTypeRepository PermissionTypeRepository { get; }
    Task Save();
}
