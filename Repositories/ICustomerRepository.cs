using CustomerApi.Models;
using System.Linq.Expressions;

namespace CustomerApi.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> Find();
        Task<Customer?> FindOne(Expression<Func<Customer?, bool>> predicate);
        Task<Customer> Create(Customer entity);
        void Delete(Customer entity);
        void Update(Customer entity);
    }
}
