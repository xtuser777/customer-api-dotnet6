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
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Create(CreateCustomerIndividualDTO dto)
        {
            var entity = new Customer()
            {
                Id = 0,
                PersonId = 0,
                Person = new Person()
                {
                    Id = 0,
                    Type = 1,
                    IndividualPersonId = 0,
                    IndividualPerson = new IndividualPerson()
                    {
                        Id = 0,
                        Name = dto.Name,
                        Document = dto.Document,
                        Birth = DateTime.Parse(dto.Birth),
                    },
                    EnterprisePersonId = 0,
                    EnterprisePerson = null,
                    AddressId = 0,
                    Address = new Address()
                    {
                        Id = 0,
                        Street = dto.Street,
                        Number = dto.Number,
                        Neighborhood = dto.Neighborhood,
                        Complement = dto.Complement,
                        Code = dto.Code,
                        City = dto.City,
                        State = dto.State,
                    },
                    ContactId = 0,
                    Contact = new Contact()
                    {
                        Id = 0,
                        Phone = dto.Phone,
                        Cellphone = dto.Cellphone,
                        Email = dto.Email,
                    }
                }
            };

            try
            {
                var address = _unitOfWork.AddressRepository.Create(entity.Person.Address);
                var contact = _unitOfWork.ContactRepository.Create(entity.Person.Contact);
                var individual = _unitOfWork.IndividualPersonRepository.Create(entity.Person.IndividualPerson);
                entity.Person.Address = address;
                entity.Person.Contact = contact;
                entity.Person.IndividualPerson = individual;
                var parson = _unitOfWork.PersonRepository.Create(entity.Person);
                entity.Person = parson;
                var customer = _unitOfWork.CustomerRepository.Create(entity);
                return new CreatedResult($"/customers/{customer.Id}", customer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new BadRequestObjectResult(ex.Message);
            }
        }

        public ActionResult Create(CreateCustomerEnterpriseDTO dto)
        {
            var entity = new Customer()
            {
                Id = 0,
                PersonId = 0,
                Person = new Person()
                {
                    Id = 0,
                    Type = 1,
                    IndividualPersonId = 0,
                    IndividualPerson = null,
                    EnterprisePersonId = 0,
                    EnterprisePerson = new EnterprisePerson()
                    {
                        Id= 0,
                        CorporateName = dto.CorporateName,
                        FantasyName = dto.FantasyName,
                        Document = dto.Document,
                    },
                    AddressId = 0,
                    Address = new Address()
                    {
                        Id = 0,
                        Street = dto.Street,
                        Number = dto.Number,
                        Neighborhood = dto.Neighborhood,
                        Complement = dto.Complement,
                        Code = dto.Code,
                        City = dto.City,
                        State = dto.State,
                    },
                    ContactId = 0,
                    Contact = new Contact()
                    {
                        Id = 0,
                        Phone = dto.Phone,
                        Cellphone = dto.Cellphone,
                        Email = dto.Email,
                    }
                }
            };

            try
            {
                var address = _unitOfWork.AddressRepository.Create(entity.Person.Address);
                var contact = _unitOfWork.ContactRepository.Create(entity.Person.Contact);
                var enterprise = _unitOfWork.EnterprisePersonRepository.Create(entity.Person.EnterprisePerson);
                entity.Person.Address = address;
                entity.Person.Contact = contact;
                entity.Person.EnterprisePerson = enterprise;
                var parson = _unitOfWork.PersonRepository.Create(entity.Person);
                entity.Person = parson;
                var customer = _unitOfWork.CustomerRepository.Create(entity);
                return new CreatedResult($"/customers/{customer.Id}", customer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new BadRequestObjectResult(ex.Message);
            }
        }

        public ActionResult Update(int id, UpdateCustomerIndividualDTO dto)
        {
            if (id != dto.Id) return new BadRequestObjectResult("Id não confere.");
            var entity = _unitOfWork.CustomerRepository.FindOne(c => c.Id == dto.Id);
            if (entity is null) return new NotFoundObjectResult("Cliente não encontrado");

            entity.Person.IndividualPerson.Name = dto.Name;
            entity.Person.IndividualPerson.Document = dto.Document;
            entity.Person.IndividualPerson.Birth = DateTime.Parse(dto.Birth);
            entity.Person.Address.Street = dto.Street;
            entity.Person.Address.Number = dto.Number;
            entity.Person.Address.Neighborhood = dto.Neighborhood;
            entity.Person.Address.Complement = dto.Complement;
            entity.Person.Address.Code = dto.Code;
            entity.Person.Address.City = dto.City;
            entity.Person.Address.State = dto.State;
            entity.Person.Contact.Phone = dto.Phone;
            entity.Person.Contact.Cellphone = dto.Cellphone;
            entity.Person.Contact.Email = dto.Email;

            try
            {
                _unitOfWork.AddressRepository.Update(entity.Person.Address);
                _unitOfWork.ContactRepository.Update(entity.Person.Contact);
                _unitOfWork.IndividualPersonRepository.Update(entity.Person.IndividualPerson);
                _unitOfWork.PersonRepository.Update(entity.Person);
                _unitOfWork.CustomerRepository.Update(entity);

                return new OkObjectResult(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new BadRequestObjectResult(ex.Message);
            }
        }

        public ActionResult Update(int id, UpdateCustomerEnterpriseDTO dto)
        {
            if (id != dto.Id) return new BadRequestObjectResult("Id não confere.");
            var entity = _unitOfWork.CustomerRepository.FindOne(c => c.Id == dto.Id);
            if (entity is null) return new NotFoundObjectResult("Cliente não encontrado");

            entity.Person.EnterprisePerson.CorporateName = dto.CorporateName;
            entity.Person.EnterprisePerson.FantasyName = dto.CorporateName;
            entity.Person.EnterprisePerson.Document = dto.Document;
            entity.Person.Address.Street = dto.Street;
            entity.Person.Address.Number = dto.Number;
            entity.Person.Address.Neighborhood = dto.Neighborhood;
            entity.Person.Address.Complement = dto.Complement;
            entity.Person.Address.Code = dto.Code;
            entity.Person.Address.City = dto.City;
            entity.Person.Address.State = dto.State;
            entity.Person.Contact.Phone = dto.Phone;
            entity.Person.Contact.Cellphone = dto.Cellphone;
            entity.Person.Contact.Email = dto.Email;

            try
            {
                _unitOfWork.AddressRepository.Update(entity.Person.Address);
                _unitOfWork.ContactRepository.Update(entity.Person.Contact);
                _unitOfWork.EnterprisePersonRepository.Update(entity.Person.EnterprisePerson);
                _unitOfWork.PersonRepository.Update(entity.Person);
                _unitOfWork.CustomerRepository.Update(entity);

                return new OkObjectResult(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new BadRequestObjectResult(ex.Message);
            }
        }

        public ActionResult Delete(int id)
        {
            var entity = _unitOfWork.CustomerRepository.FindOne(c => c.Id == id);
            if (entity is null) return new NotFoundObjectResult("Cliente não encontrado");

            try
            {
                _unitOfWork.CustomerRepository.Delete(entity);
                _unitOfWork.PersonRepository.Delete(entity.Person);
                if (entity.Person.Type == 1) _unitOfWork.IndividualPersonRepository.Delete(entity.Person.IndividualPerson);
                else _unitOfWork.EnterprisePersonRepository.Delete(entity.Person.EnterprisePerson);
                _unitOfWork.AddressRepository.Delete(entity.Person.Address);
                _unitOfWork.ContactRepository.Delete(entity.Person.Contact);

                return new NoContentResult();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new BadRequestObjectResult(ex.Message);
            }
        }

        public ActionResult<IEnumerable<CustomerDTO>> Find()
        {
            var customers = _unitOfWork.CustomerRepository.Find().ToList();

            var dtos = new List<CustomerDTO>();

            foreach (var entity in customers)
            {
                dtos.Add(new CustomerDTO()
                {
                    Id = entity.Id,
                    Type = entity.Person.Type,
                    Name = entity.Person.Type == 1 ? entity.Person.IndividualPerson.Name : "",
                    Birth = entity.Person.Type == 1 ? entity.Person.IndividualPerson.Birth.ToShortDateString() : "",
                    CorporateName = entity.Person.Type == 2 ? entity.Person.EnterprisePerson.CorporateName : "",
                    FantasyName = entity.Person.Type == 2 ? entity.Person.EnterprisePerson.FantasyName : "",
                    Document = entity.Person.Type == 1 ? entity.Person.IndividualPerson.Document : entity.Person.EnterprisePerson.Document,
                    Street = entity.Person.Address.Street,
                    Number = entity.Person.Address.Number,
                    Neighborhood = entity.Person.Address.Neighborhood,
                    Complement = entity.Person.Address.Complement,
                    Code = entity.Person.Address.Code,
                    City = entity.Person.Address.City,
                    State = entity.Person.Address.State,
                    Phone = entity.Person.Contact.Phone,
                    Cellphone = entity.Person.Contact.Cellphone,
                    Email = entity.Person.Contact.Email,
                });
            }

            return new OkObjectResult(dtos);
        }

        public ActionResult<CustomerDTO?> FindOne(int id)
        {
            var entity = _unitOfWork.CustomerRepository.FindOne(c => c.Id == id);

            if (entity is null) return new NotFoundResult();

            var dto = new CustomerDTO()
            {
                Id = id,
                Type = entity.Person.Type,
                Name = entity.Person.Type == 1 ? entity.Person.IndividualPerson.Name : "",
                Birth = entity.Person.Type == 1 ? entity.Person.IndividualPerson.Birth.ToShortDateString() : "",
                CorporateName = entity.Person.Type == 2 ? entity.Person.EnterprisePerson.CorporateName : "",
                FantasyName = entity.Person.Type == 2 ? entity.Person.EnterprisePerson.FantasyName : "",
                Document = entity.Person.Type == 1 ? entity.Person.IndividualPerson.Document : entity.Person.EnterprisePerson.Document,
                Street = entity.Person.Address.Street,
                Number = entity.Person.Address.Number,
                Neighborhood = entity.Person.Address.Neighborhood,
                Complement = entity.Person.Address.Complement,
                Code = entity.Person.Address.Code,
                City = entity.Person.Address.City,
                State = entity.Person.Address.State,
                Phone = entity.Person.Contact.Phone,
                Cellphone = entity.Person.Contact.Cellphone,
                Email = entity.Person.Contact.Email,
            };

            return new OkObjectResult(dto);
        }
    }
}
