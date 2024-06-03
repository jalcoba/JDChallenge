using JDChallenge.DataAccess.Interfaces;
using JDChallenge.Domain.Entities;

namespace JDChallenge.DataAccess.Repositories;

public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext) { }
}
