using CustomerApi.DTOs.Customer;
using CustomerApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace CustomerApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    // GET
    [HttpGet]
    public ActionResult<IEnumerable<CustomerDTO>> Index()
    {
        return _customerService.Find();
    }

    [HttpGet("{id:int}")]
    public ActionResult<CustomerDTO?> Show(int id)
    {
        return _customerService.FindOne(id);
    }

    [HttpPost("individual")]
    public ActionResult<CustomerDTO> Create([FromBody] CreateCustomerIndividualDTO createCustomerDto)
    {
        return _customerService.Create(createCustomerDto);
    }

    [HttpPost("enterprise")]
    public ActionResult<CustomerDTO> Create([FromBody] CreateCustomerEnterpriseDTO createCustomerDto)
    {
        return _customerService.Create(createCustomerDto);
    }

    [HttpPut("individual/{id:int}")]
    public ActionResult Update(int id, [FromBody] UpdateCustomerIndividualDTO updateCustomerDto)
    {
        return _customerService.Update(id, updateCustomerDto);
    }

    [HttpPut("enterprise/{id:int}")]
    public ActionResult<CustomerDTO> Update(int id, [FromBody] UpdateCustomerEnterpriseDTO updateCustomerDto)
    {
        return _customerService.Update(id, updateCustomerDto);
    }

    [HttpDelete("id:int")]
    public ActionResult Delete(int id)
    {
        return _customerService.Delete(id);
    }
}