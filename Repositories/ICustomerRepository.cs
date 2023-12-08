using CustomerApi.Models;
using System.Linq.Expressions;

namespace CustomerApi.Repositories;

public interface ICustomerRepository
{
    IQueryable<Customer> Find();
    Customer? FindOne(Expression<Func<Customer?, bool>> predicate);
    Customer Create(Customer entity);
    void Update(Customer entity);
    void Delete(Customer entity);
}