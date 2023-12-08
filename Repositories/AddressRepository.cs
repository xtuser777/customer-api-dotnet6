using CustomerApi.Context;
using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CustomerApi.Repositories;

public class AddressRepository : IAddressRepository
{
    private CustomerApiContext _context;

    public AddressRepository(CustomerApiContext context)
    {
        _context = context;
    }

    public IQueryable<Address> Find()
    {
        return _context.Set<Address>().AsNoTracking();
    }

    public Address? FindOne(Expression<Func<Address?, bool>> predicate)
    {
        return _context.Set<Address>().AsNoTracking().SingleOrDefault(predicate);
    }

    public Address Create(Address entity)
    {
        var result = _context.Set<Address>().Add(entity);

        return result.Entity;
    }

    public void Delete(Address entity)
    {
        _context.Set<Address>().Remove(entity);
    }

    public void Update(Address entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.Set<Address>().Update(entity);
    }
}