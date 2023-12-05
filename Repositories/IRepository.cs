using System.Linq.Expressions;

namespace CustomerApi.Repositories;

public interface IRepository<T>
{
    IQueryable<T> Find();
    T? FindOne(Expression<Func<T?, bool>> predicate);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);

}