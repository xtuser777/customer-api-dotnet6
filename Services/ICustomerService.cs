using CustomerApi.DTOs.Customer;
using CustomerApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace CustomerApi.Services
{
    public interface ICustomerService
    {
        Task<ActionResult<IEnumerable<CustomerDTO>>> Find();
        Task<ActionResult<CustomerDTO?>> FindOne(int id);
        Task<ActionResult> Create(CreateCustomerIndividualDTO entity);
        Task<ActionResult> Update(int id, UpdateCustomerIndividualDTO entity);
        Task<ActionResult> Delete(int id);
    }
}
