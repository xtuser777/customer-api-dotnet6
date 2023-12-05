using CustomerApi.DTOs.Customer;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    // GET
    [HttpGet]
    public ActionResult<IEnumerable<CustomerDTO>> Index()
    {
        return Ok(new List<CustomerDTO>());
    }

    [HttpGet("{id:int}")]
    public ActionResult<CustomerDTO> Show(int id)
    {
        return Ok(new CustomerDTO());
    }

    [HttpPost]
    public ActionResult<CustomerDTO> Create([FromBody] CreateCustomerDTO createCustomerDto)
    {
        return Created("", new CustomerDTO());
    }

    [HttpPut]
    public ActionResult<CustomerDTO> Update([FromBody] UpdateCustomerDTO updateCustomerDto)
    {
        return Ok(new CustomerDTO());
    }

    [HttpDelete("id:int")]
    public ActionResult Delete(int id)
    {
        return NoContent();
    }
}