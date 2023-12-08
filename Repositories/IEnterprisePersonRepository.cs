using CustomerApi.Models;
using System.Linq.Expressions;

namespace CustomerApi.Repositories;

public interface IEnterprisePersonRepository
{
    IQueryable<EnterprisePerson> Find();
    EnterprisePerson? FindOne(Expression<Func<EnterprisePerson?, bool>> predicate);
    EnterprisePerson Create(EnterprisePerson entity);
    void Update(EnterprisePerson entity);
    void Delete(EnterprisePerson entity);
}