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

    public async Task<IQueryable<Customer>> Find()
    {
        return _context.Customers.AsNoTracking();
    }

    public async Task<Customer?> FindOne(Expression<Func<Customer?, bool>> predicate)
    {
        return _context.Customers.AsNoTracking().SingleOrDefault(predicate);
    }

    public async Task<Customer> Create(Customer entity)
    {
        var result = await _context.Set<Customer>().AddAsync(entity);

        return result.Entity;
    }

    public async Task Delete(Customer entity)
    {
        _context.Customers.Remove(entity);
    }

    public async Task Update(Customer entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.Customers.Update(entity);
    }
}