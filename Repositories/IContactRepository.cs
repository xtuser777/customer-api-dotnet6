using CustomerApi.Models;
using System.Linq.Expressions;

namespace CustomerApi.Repositories;

public interface IContactRepository
{
    IQueryable<Contact> Find();
    Contact? FindOne(Expression<Func<Contact?, bool>> predicate);
    Contact Create(Contact entity);
    void Update(Contact entity);
    void Delete(Contact entity);
}