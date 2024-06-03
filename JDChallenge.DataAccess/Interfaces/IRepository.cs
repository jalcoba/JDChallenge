using System.Linq.Expressions;

namespace JDChallenge.DataAccess.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T?> Get(Expression<Func<T, bool>> expression);
    Task<IEnumerable<T>> GetAll();
    Task<T> Add(T entity);
    T Update(T entity);
    void Delete(T entity);
}
