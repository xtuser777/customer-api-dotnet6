using CustomerApi.Context;
using CustomerApi.Models;

namespace CustomerApi.Repositories;

public class AddressRepository : Repository<Address>
{
    public AddressRepository(CustomerApiContext context) : base(context)
    {
    }
}