using JDChallenge.DataAccess.Interfaces;
using JDChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JDChallenge.DataAccess.Repositories;

public class Repository<T> : IRepository<T> where T : Entity
{
    protected readonly ApplicationDbContext _context;
    public readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext dbContext)
    {
        _context = dbContext;
        _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> Get(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.FirstOrDefaultAsync(expression);
    }

    public async Task<T> Add(T entity)
    {
        await _context.AddAsync(entity);
        return entity;
    }

    public T Update(T entity)
    {
        _context.Update(entity);
        return entity;
    }

    public void Delete(T entity)
    {
        _context.Remove(entity);
    }
}
