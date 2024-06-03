using JDChallenge.DataAccess.Interfaces;
using JDChallenge.Domain.Entities;

namespace JDChallenge.DataAccess.Repositories;

public class PermissionRepository : Repository<Permission>, IPermissionRepository
{
    public PermissionRepository(ApplicationDbContext dbContext) : base(dbContext) { }
}
