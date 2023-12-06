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
        return Ok(new CustomerDTO()
        {
            Id = 1,
            Type = 1,
            Name = "Test",
            CorporateName = "Test",
            FantasyName = "Test",
            Document = "111.111.111-11",
            Birth = "2000-01-01",
            Street = "Test",
            Number = "1",
            Neighborhood = "Test",
            Complement = "",
            Code = "01.001-000",
            City = "Test",
            State = "Test",
            Phone = "(11) 1111-1111",
            Cellphone = "(11) 11111-1111",
            Email = "teste@mail.com",
        });
    }

    [HttpPost("individual")]
    public ActionResult<CustomerDTO> Create([FromBody] CreateCustomerIndividualDTO createCustomerDto)
    {
        return Created("", new CustomerDTO());
    }

    [HttpPost("enterprise")]
    public ActionResult<CustomerDTO> Create([FromBody] CreateCustomerEnterpriseDTO createCustomerDto)
    {
        return Created("", new CustomerDTO());
    }

    [HttpPut("individual")]
    public ActionResult<CustomerDTO> Update([FromBody] UpdateCustomerIndividualDTO updateCustomerDto)
    {
        return Ok(new CustomerDTO());
    }

    [HttpPut("enterprise")]
    public ActionResult<CustomerDTO> Update([FromBody] UpdateCustomerEnterpriseDTO updateCustomerDto)
    {
        return Ok(new CustomerDTO());
    }

    [HttpDelete("id:int")]
    public ActionResult Delete(int id)
    {
        return NoContent();
    }
}