using CustomerApi.Context;
using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CustomerApi.Repositories;

public class ContactRepository : IContactRepository
{
    private CustomerApiContext _context;

    public ContactRepository(CustomerApiContext context)
    {
        _context = context;
    }

    public IQueryable<Contact> Find()
    {
        return _context.Set<Contact>().AsNoTracking();
    }

    public Contact? FindOne(Expression<Func<Contact?, bool>> predicate)
    {
        return _context.Set<Contact>().AsNoTracking().SingleOrDefault(predicate);
    }

    public Contact Create(Contact entity)
    {
        var result = _context.Set<Contact>().Add(entity);

        return result.Entity;
    }

    public void Delete(Contact entity)
    {
        _context.Set<Contact>().Remove(entity);
    }

    public void Update(Contact entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.Set<Contact>().Update(entity);
    }
}