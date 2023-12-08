using CustomerApi.Context;
using CustomerApi.Models;
using System.Linq.Expressions;

namespace CustomerApi.Repositories;

public interface IIndividualPersonRepository
{
    IQueryable<IndividualPerson> Find();
    IndividualPerson? FindOne(Expression<Func<IndividualPerson?, bool>> predicate);
    IndividualPerson Create(IndividualPerson entity);
    void Update(IndividualPerson entity);
    void Delete(IndividualPerson entity);
}