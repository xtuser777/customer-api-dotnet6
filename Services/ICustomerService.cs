using CustomerApi.DTOs.Customer;
using CustomerApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace CustomerApi.Services
{
    public interface ICustomerService
    {
        ActionResult<IEnumerable<CustomerDTO>> Find();
        ActionResult<CustomerDTO?> FindOne(int id);
        ActionResult Create(CreateCustomerIndividualDTO entity);
        ActionResult Create(CreateCustomerEnterpriseDTO entity);
        ActionResult Update(int id, UpdateCustomerIndividualDTO entity);
        ActionResult Update(int id, UpdateCustomerEnterpriseDTO entity);
        ActionResult Delete(int id);
    }
}
