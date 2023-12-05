using CustomerApi.Context;
using CustomerApi.Models;

namespace CustomerApi.Repositories;

public class PersonRepository : Repository<Person>, IPersonRepository
{
    public PersonRepository(CustomerApiContext context) : base(context)
    {
    }
}