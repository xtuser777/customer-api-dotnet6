using CustomerApi.Models;
using System.Linq.Expressions;

namespace CustomerApi.Repositories
{
    public interface ICustomerRepository
    {
        Task<IQueryable<Customer>> Find();
        Task<Customer?> FindOne(Expression<Func<Customer?, bool>> predicate);
        Task<Customer> Create(Customer entity);
        Task Delete(Customer entity);
        Task Update(Customer entity);
    }
}
