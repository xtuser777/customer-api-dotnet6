using CustomerApi.Context;
using CustomerApi.Models;

namespace CustomerApi.Repositories;

public class EnterprisePersonRepository : Repository<EnterprisePerson>, IEnterprisePersonRepository
{
    public EnterprisePersonRepository(CustomerApiContext context) : base(context)
    {
    }
}