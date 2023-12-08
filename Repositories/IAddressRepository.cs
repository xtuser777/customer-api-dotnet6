using CustomerApi.Models;
using System.Linq.Expressions;

namespace CustomerApi.Repositories;

public interface IAddressRepository
{
    IQueryable<Address> Find();
    Address? FindOne(Expression<Func<Address?, bool>> predicate);
    Address Create(Address entity);
    void Update(Address entity);
    void Delete(Address entity);
}