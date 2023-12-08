using CustomerApi.Context;
using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CustomerApi.Repositories;

public class PersonRepository : IPersonRepository
{
    private CustomerApiContext _context;

    public PersonRepository(CustomerApiContext context)
    {
        _context = context;
    }

    public IQueryable<Person> Find()
    {
        return _context.Set<Person>().AsNoTracking();
    }

    public Person? FindOne(Expression<Func<Person?, bool>> predicate)
    {
        return _context.Set<Person>().AsNoTracking().SingleOrDefault(predicate);
    }

    public Person Create(Person entity)
    {
        var result = _context.Set<Person>().Add(entity);

        return result.Entity;
    }

    public void Delete(Person entity)
    {
        _context.Set<Person>().Remove(entity);
    }

    public void Update(Person entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.Set<Person>().Update(entity);
    }
}