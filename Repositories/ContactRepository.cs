using CustomerApi.Context;
using CustomerApi.Models;

namespace CustomerApi.Repositories;

public class ContactRepository : Repository<Contact>, IContactRepository
{
    public ContactRepository(CustomerApiContext context) : base(context)
    {
    }
}