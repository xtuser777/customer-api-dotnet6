using CustomerApi.Context;
using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CustomerApi.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private CustomerApiContext _context;

    public CustomerRepository(CustomerApiContext context)
    {
        _context = context;
    }

    public IQueryable<Customer> Find()
    {
        return _context
            .Set<Customer>().AsNoTracking();
    }

    public Customer? FindOne(Expression<Func<Customer?, bool>> predicate)
    {
        return _context.Set<Customer>().AsNoTracking().SingleOrDefault(predicate);
    }

    public Customer Create(Customer entity)
    {
        var result = _context.Set<Customer>().Add(entity);

        return result.Entity;
    }

    public void Delete(Customer entity)
    {
        _context.Set<Customer>().Remove(entity);
    }

    public void Update(Customer entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.Set<Customer>().Update(entity);
    }
}