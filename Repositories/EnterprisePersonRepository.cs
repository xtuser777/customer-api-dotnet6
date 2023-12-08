using CustomerApi.Context;
using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CustomerApi.Repositories;

public class EnterprisePersonRepository : IEnterprisePersonRepository
{
    private CustomerApiContext _context;

    public EnterprisePersonRepository(CustomerApiContext context)
    {
        _context = context;
    }

    public IQueryable<EnterprisePerson> Find()
    {
        return _context.Set<EnterprisePerson>().AsNoTracking();
    }

    public EnterprisePerson? FindOne(Expression<Func<EnterprisePerson?, bool>> predicate)
    {
        return _context.Set<EnterprisePerson>().AsNoTracking().SingleOrDefault(predicate);
    }

    public EnterprisePerson Create(EnterprisePerson entity)
    {
        var result = _context.Set<EnterprisePerson>().Add(entity);

        return result.Entity;
    }

    public void Delete(EnterprisePerson entity)
    {
        _context.Set<EnterprisePerson>().Remove(entity);
    }

    public void Update(EnterprisePerson entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.Set<EnterprisePerson>().Update(entity);
    }
}