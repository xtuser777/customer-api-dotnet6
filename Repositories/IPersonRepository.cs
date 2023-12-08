using CustomerApi.Models;
using System.Linq.Expressions;

namespace CustomerApi.Repositories;

public interface IPersonRepository
{
    IQueryable<Person> Find();
    Person? FindOne(Expression<Func<Person?, bool>> predicate);
    Person Create(Person entity);
    void Update(Person entity);
    void Delete(Person entity);
}