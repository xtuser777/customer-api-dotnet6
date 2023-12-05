using System.Linq.Expressions;
using CustomerApi.Context;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected CustomerApiContext _context;

    public Repository(CustomerApiContext context)
    {
        _context = context;
    }

    public IQueryable<T> Find()
    {
        return _context.Set<T>().AsNoTracking();
    }

    public T? FindOne(Expression<Func<T?, bool>> predicate)
    {
        return _context.Set<T>().AsNoTracking().SingleOrDefault(predicate);
    }

    public void Create(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.Set<T>().Update(entity);
    }
}