using JDChallenge.DataAccess.Interfaces;
using JDChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JDChallenge.DataAccess.Repositories;

public class PermissionRepository : Repository<Permission>, IPermissionRepository
{
    public PermissionRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    public override async Task<IEnumerable<Permission>> GetAll()
    {
        return await _dbSet.Include(x => x.Employee).Include(x => x.PermissionType).ToListAsync();
    }

    public override async Task<Permission?> Get(Expression<Func<Permission, bool>> expression)
    {
        return await _dbSet.Include(x => x.Employee).Include(x => x.PermissionType).FirstOrDefaultAsync(expression);
    }

    public override Permission Update(Permission entity)
    {
        _context.Update(entity).Property(x => x.Id).IsModified = false;
        return entity;
    }
}
