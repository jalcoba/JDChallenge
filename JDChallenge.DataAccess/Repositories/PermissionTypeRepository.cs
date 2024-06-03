using JDChallenge.DataAccess.Interfaces;
using JDChallenge.Domain.Entities;

namespace JDChallenge.DataAccess.Repositories;

public class PermissionTypeRepository : Repository<PermissionType>, IPermissionTypeRepository
{
    public PermissionTypeRepository(ApplicationDbContext dbContext) : base(dbContext) { }
}
