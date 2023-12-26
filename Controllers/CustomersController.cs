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
    [Produces("application/json")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDTO>>> Index()
    {
        return await _customerService.Find();
    }

    [Produces("application/json")]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<CustomerDTO?>> Show(int id)
    {
        return await _customerService.FindOne(id);
    }

    [HttpPost()]
    public async Task<ActionResult<CustomerDTO>> Create([FromBody] CreateCustomerIndividualDTO createCustomerDto)
    {
        return await _customerService.Create(createCustomerDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update(int id, [FromBody] UpdateCustomerIndividualDTO updateCustomerDto)
    {
        return await  _customerService.Update(id, updateCustomerDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        return await _customerService.Delete(id);
    }
}