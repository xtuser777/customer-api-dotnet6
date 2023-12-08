using CustomerApi.Context;
using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CustomerApi.Repositories;

public class IndividualPersonRepository : IIndividualPersonRepository
{
    private CustomerApiContext _context;

    public IndividualPersonRepository(CustomerApiContext context)
    {
        _context = context;
    }

    public IQueryable<IndividualPerson> Find()
    {
        return _context.Set<IndividualPerson>().AsNoTracking();
    }

    public IndividualPerson? FindOne(Expression<Func<IndividualPerson?, bool>> predicate)
    {
        return _context.Set<IndividualPerson>().AsNoTracking().SingleOrDefault(predicate);
    }

    public IndividualPerson Create(IndividualPerson entity)
    {
        var result = _context.Set<IndividualPerson>().Add(entity);

        return result.Entity;
    }

    public void Delete(IndividualPerson entity)
    {
        _context.Set<IndividualPerson>().Remove(entity);
    }

    public void Update(IndividualPerson entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.Set<IndividualPerson>().Update(entity);
    }
}