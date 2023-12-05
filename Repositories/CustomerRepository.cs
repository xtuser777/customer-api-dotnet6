using CustomerApi.Context;
using CustomerApi.Models;

namespace CustomerApi.Repositories;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(CustomerApiContext context) : base(context)
    {
    }
}