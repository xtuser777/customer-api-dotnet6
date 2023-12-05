using CustomerApi.Context;
using CustomerApi.Models;

namespace CustomerApi.Repositories;

public class ContactRepository : Repository<Contact>
{
    public ContactRepository(CustomerApiContext context) : base(context)
    {
    }
}