using CustomerApi.DTOs.Customer;
using CustomerApi.Models;
using CustomerApi.Repositories;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop.Infrastructure;
using System.Linq.Expressions;

namespace CustomerApi.Services
{
    public class CustomerService : ICustomerService
    {
        private IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ActionResult> Create(CreateCustomerIndividualDTO dto)
        {
            var entity = new Customer()
            {
                Id = 0,
                Name = dto.Name,
                Document = dto.Document,
                Birth = DateTime.Parse(dto.Birth),
                Street = dto.Street,
                Number = dto.Number,
                Neighborhood = dto.Neighborhood,
                Complement = dto.Complement,
                Code = dto.Code,
                City = dto.City,
                State = dto.State,
                Phone = dto.Phone,
                Cellphone = dto.Cellphone,
                Email = dto.Email,
            };

            try
            {
                var customer = await _unitOfWork.CustomerRepository.Create(entity);
                await _unitOfWork.Commit();
                return new CreatedResult($"/customers/{1}", customer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new BadRequestObjectResult(ex.Message);
            }
        }

        public async Task<ActionResult> Update(int id, UpdateCustomerIndividualDTO dto)
        {
            if (id != dto.Id) return new BadRequestObjectResult("Id não confere.");

            var entity = await _unitOfWork.CustomerRepository.FindOne(c => c.Id == dto.Id);
            if (entity is null) return new NotFoundObjectResult("Cliente não encontrado");

            entity.Name = dto.Name;
            entity.Document = dto.Document;
            entity.Birth = DateTime.Parse(dto.Birth);
            entity.Street = dto.Street;
            entity.Number = dto.Number;
            entity.Neighborhood = dto.Neighborhood;
            entity.Complement = dto.Complement;
            entity.Code = dto.Code;
            entity.City = dto.City;
            entity.State = dto.State;
            entity.Phone = dto.Phone;
            entity.Cellphone = dto.Cellphone;
            entity.Email = dto.Email;

            try
            {
                _unitOfWork.CustomerRepository.Update(entity);
                await _unitOfWork.Commit();
                return new OkObjectResult(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new BadRequestObjectResult(ex.Message);
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            var entity = await _unitOfWork.CustomerRepository.FindOne(c => c.Id == id);
            if (entity is null) return new NotFoundObjectResult("Cliente não encontrado");

            try
            {
                _unitOfWork.CustomerRepository.Delete(entity); 
                await _unitOfWork.Commit();
                return new NoContentResult();
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new BadRequestObjectResult(ex.Message);
            }
        }

        public async Task<ActionResult<IEnumerable<CustomerDTO>>> Find()
        {
            var customers = await _unitOfWork.CustomerRepository.Find();

            var dtos = new List<CustomerDTO>();

            foreach (var entity in customers)
            {
                dtos.Add(new CustomerDTO()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Birth = entity.Birth.ToShortDateString(),
                    Document = entity.Document,
                    Street = entity.Street,
                    Number = entity.Number,
                    Neighborhood = entity.Neighborhood,
                    Complement = entity.Complement,
                    Code = entity.Code,
                    City = entity.City,
                    State = entity.State,
                    Phone = entity.Phone,
                    Cellphone = entity.Cellphone,
                    Email = entity.Email,
                });
            }

            return new OkObjectResult(dtos);
        }

        public async Task<ActionResult<CustomerDTO?>> FindOne(int id)
        {
            var entity = await _unitOfWork.CustomerRepository.FindOne(c => c.Id == id);

            if (entity is null) return new NotFoundResult();

            var dto = new CustomerDTO()
            {
                Id = id,
                Name = entity.Name,
                Birth = entity.Birth.ToShortDateString(),
                Document = entity.Document,
                Street = entity.Street,
                Number = entity.Number,
                Neighborhood = entity.Neighborhood,
                Complement = entity.Complement,
                Code = entity.Code,
                City = entity.City,
                State = entity.State,
                Phone = entity.Phone,
                Cellphone = entity.Cellphone,
                Email = entity.Email,
            };

            return new OkObjectResult(dto);
        }
    }
}
