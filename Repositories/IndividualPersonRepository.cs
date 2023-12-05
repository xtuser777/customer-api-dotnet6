using CustomerApi.Context;
using CustomerApi.Models;

namespace CustomerApi.Repositories;

public class IndividualPersonRepository : Repository<IndividualPerson>
{
    public IndividualPersonRepository(CustomerApiContext context) : base(context)
    {
    }
}